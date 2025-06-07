package br.com.educacaocriativa.mentor_leitor_facial.sdk;

import br.com.educacaocriativa.mentor_leitor_facial.model.Pessoa;
import br.com.educacaocriativa.mentor_leitor_facial.model.TipoPessoa;
import br.com.educacaocriativa.mentor_leitor_facial.sdk.model.*;
import br.com.educacaocriativa.mentor_leitor_facial.sdk.util.ImagemUtil;

import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.WebSocket;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.CompletionStage;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicInteger;
import java.util.concurrent.TimeUnit;

public class LeitorFacialSdkImpl implements LeitorFacialSdk {

    private static final String WEBSOCKET_URL = "ws://localhost:7792/pub/chat";
    private static final ObjectMapper objectMapper = new ObjectMapper();
    private static final AtomicInteger sequence = new AtomicInteger(0);

    private HttpClient httpClient;
    private WebSocket webSocket;
    private boolean conectado = false;

    private final ConcurrentHashMap<String, CompletableFuture<Object>> responseFutures = new ConcurrentHashMap<>();
    private final ConcurrentHashMap<String, CacheEntry<Pessoa>> cacheUsuarios = new ConcurrentHashMap<>();
    private final long CACHE_TIMEOUT_MINUTES = 15;
    private final long CACHE_TIMEOUT_MS = TimeUnit.MINUTES.toMillis(CACHE_TIMEOUT_MINUTES);

    private class CacheEntry<T> {
        private final T value;
        private final long creationTime;

        public CacheEntry(T value) {
            this.value = value;
            this.creationTime = System.currentTimeMillis();
        }

        public T getValue() {
            return value;
        }

        public boolean isExpired() {
            return System.currentTimeMillis() - creationTime > CACHE_TIMEOUT_MS;
        }
    }

    public LeitorFacialSdkImpl() {
        this.httpClient = HttpClient.newHttpClient();
    }

    public LeitorFacialSdkImpl(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public LeitorFacialSdkImpl(WebSocket webSocket) {
        this.webSocket = webSocket;
        this.httpClient = HttpClient.newHttpClient();
    }

    private void limparCache() {
        cacheUsuarios.clear();
        responseFutures.clear();
    }

    private void atualizarCache(String codigo, Pessoa pessoa) {
        cacheUsuarios.put(codigo, new CacheEntry<>(pessoa));
    }

    private Pessoa obterDoCache(String codigo) {
        CacheEntry<Pessoa> entry = cacheUsuarios.get(codigo);
        if (entry != null && !entry.isExpired()) {
            return entry.getValue();
        }
        // Remove do cache se estiver expirado
        if (entry != null) {
            cacheUsuarios.remove(codigo);
        }
        return null;
    }

    private boolean validarSequencia(String seq) {
        try {
            int seqNum = Integer.parseInt(seq);
            return seqNum > 0;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    private void handleResponse(String response) {
        try {
            Mensagem mensagem = objectMapper.readValue(response, Mensagem.class);
            String seq = mensagem.getSequence();
            
            if (responseFutures.containsKey(seq)) {
                CompletableFuture<Object> future = responseFutures.get(seq);
                future.complete(mensagem);
                responseFutures.remove(seq);
            }
        } catch (Exception e) {
            System.err.println("Erro ao processar resposta: " + e.getMessage());
        }
    }

    private boolean sendCommand(Cmd cmd) throws IOException {
        if (webSocket == null || !conectado) {
            throw new IOException("Não conectado ao leitor facial");
        }

        String seq = cmd.getSequence();
        if (!validarSequencia(seq)) {
            throw new IOException("Sequência inválida");
        }

        try {
            String json = objectMapper.writeValueAsString(cmd);
            webSocket.sendText(json, true).join();
            
            CompletableFuture<Object> future = new CompletableFuture<>();
            responseFutures.put(seq, future);
            
            return future.get() instanceof Mensagem && ((Mensagem) future.get()).isResult();
        } catch (Exception e) {
            throw new IOException("Erro ao enviar comando: " + e.getMessage(), e);
        }
    }

    @Override
    public boolean conectar() throws IOException {
        if (webSocket != null && conectado) {
            return true;
        }

        try {
            URI uri = URI.create(WEBSOCKET_URL);
            webSocket = httpClient.newWebSocketBuilder()
                    .buildAsync(uri, new WebSocket.Listener() {
                        @Override
                        public void onOpen(WebSocket webSocket) {
                            System.out.println("Conectado ao leitor facial");
                            conectado = true;
                            webSocket.request(1);
                            limparCache(); // Limpar cache ao reconectar
                        }

                        @Override
                        public CompletionStage<?> onText(WebSocket webSocket, CharSequence data, boolean last) {
                            handleResponse(data.toString());
                            webSocket.request(1);
                            return CompletableFuture.completedFuture(null);
                        }

                        @Override
                        public void onError(WebSocket webSocket, Throwable error) {
                            conectado = false;
                            System.err.println("Erro na conexão: " + error.getMessage());
                            limparCache(); // Limpar cache em erro
                        }

                        @Override
                        public CompletionStage<?> onClose(WebSocket webSocket, int statusCode, String reason) {
                            conectado = false;
                            System.out.println("Conexão encerrada: " + reason);
                            limparCache(); // Limpar cache ao desconectar
                            return CompletableFuture.completedFuture(null);
                        }
                    })
                    .join();

            return conectado;
        } catch (Exception e) {
            throw new IOException("Erro ao conectar ao leitor facial: " + e.getMessage(), e);
        }
    }

    @Override
    public boolean desconectar() throws IOException {
        if (webSocket != null) {
            webSocket.sendClose(WebSocket.NORMAL_CLOSURE, "Desconectando").join();
            conectado = false;
            webSocket = null;
            limparCache();
        }
        return true;
    }

    @Override
    public boolean cadastrarPessoa(Pessoa pessoa, byte[] foto) throws IOException {
        if (foto == null || foto.length == 0) {
            throw new IOException("Foto não pode ser nula ou vazia");
        }

        // Processa e valida a imagem
        byte[] fotoProcessada = ImagemUtil.processarImagem(foto);

        CmdSendUser cmd = new CmdSendUser(String.valueOf(sequence.incrementAndGet()));
        cmd.setEnrollid(Long.parseLong(pessoa.getCodigoPessoa()));
        cmd.setName(pessoa.getNomePessoa());
        cmd.setRecord(new String(fotoProcessada));
        cmd.setAdmin(pessoa.getTipoPessoa().ordinal());
        cmd.setBackupnum(BackupNum.FACE.getValue());

        boolean sucesso = sendCommand(cmd);
        if (sucesso) {
            atualizarCache(pessoa.getCodigoPessoa(), pessoa);
        }
        return sucesso;
    }

    @Override
    public boolean removerPessoa(String codigo) throws IOException {
        if (codigo == null || codigo.isEmpty()) {
            throw new IOException("Código não pode ser nulo ou vazio");
        }

        long enrollId = Long.parseLong(codigo);
        CmdDeleteUser cmd = new CmdDeleteUser(String.valueOf(sequence.incrementAndGet()), enrollId);
        cmd.setBackupnum(BackupNum.FACE.getValue());

        boolean sucesso = sendCommand(cmd);
        if (sucesso) {
            cacheUsuarios.remove(codigo);
        }
        return sucesso;
    }

    @Override
    public boolean atualizarPessoa(Pessoa pessoa, byte[] foto) throws IOException {
        if (foto == null || foto.length == 0) {
            throw new IOException("Foto não pode ser nula ou vazia");
        }

        // Processa e valida a imagem
        byte[] fotoProcessada = ImagemUtil.processarImagem(foto);

        CmdSendUser cmd = new CmdSendUser(String.valueOf(sequence.incrementAndGet()));
        cmd.setEnrollid(Long.parseLong(pessoa.getCodigoPessoa()));
        cmd.setName(pessoa.getNomePessoa());
        cmd.setRecord(new String(fotoProcessada));
        cmd.setAdmin(pessoa.getTipoPessoa().ordinal());
        cmd.setBackupnum(BackupNum.FACE.getValue());

        boolean sucesso = sendCommand(cmd);
        if (sucesso) {
            atualizarCache(pessoa.getCodigoPessoa(), pessoa);
        }
        return sucesso;
    }

    @Override
    public boolean estaCadastrada(String codigo) throws IOException {
        if (codigo == null || codigo.isEmpty()) {
            throw new IOException("Código não pode ser nulo ou vazio");
        }

        // Primeiro tenta no cache
        Pessoa pessoa = obterDoCache(codigo);
        if (pessoa != null) {
            return true;
        }

        // Se não está no cache, consulta o leitor
        CmdGetUserInfo cmd = new CmdGetUserInfo(String.valueOf(sequence.incrementAndGet()));
        cmd.setEnrollid(Long.parseLong(codigo));
        cmd.setBackupnum(BackupNum.FACE.getValue());

        return sendCommand(cmd);
    }

    @Override
    public String getStatus() throws IOException {
        if (webSocket != null && conectado) {
            CmdGetStatus cmd = new CmdGetStatus(String.valueOf(sequence.incrementAndGet()));
            return sendCommand(cmd) ? "Conectado" : "Erro na comunicação";
        }
        return "Desconectado";
    }

    @Override
    public boolean enviarFoto(String codigo, byte[] foto) throws IOException {
        if (foto == null || foto.length == 0) {
            throw new IOException("Foto não pode ser nula ou vazia");
        }

        // Processa e valida a imagem
        byte[] fotoProcessada = ImagemUtil.processarImagem(foto);

        CmdSendUser cmd = new CmdSendUser(String.valueOf(sequence.incrementAndGet()));
        cmd.setEnrollid(Long.parseLong(codigo));
        cmd.setRecord(new String(fotoProcessada));
        cmd.setBackupnum(BackupNum.FACE.getValue());

        return sendCommand(cmd);
    }

    @Override
    public boolean exportarDados(String caminho) throws IOException {
            if (caminho == null || caminho.isEmpty()) {
                throw new IOException("Caminho não pode ser nulo ou vazio");
            }

            CmdExportarDados cmd = new CmdExportarDados(
                String.valueOf(sequence.incrementAndGet()),
                0, // Exportar todos os dados
                caminho
            );

            return sendCommand(cmd);
        }

    @Override
    public List<Pessoa> listarPessoas() throws IOException {
        CmdGetUserList cmd = new CmdGetUserList(String.valueOf(sequence.incrementAndGet()));
        cmd.setStartIndex(0);
        cmd.setCount(1000);
        
        if (!sendCommand(cmd)) {
            return new ArrayList<>();
        }

        // Aguardar a resposta e processar
        try {
            // Aguardar a resposta por um tempo razoável
            Thread.sleep(1000);
            
            // Verificar se temos uma resposta
            String seq = cmd.getSequence();
            if (responseFutures.containsKey(seq)) {
                CompletableFuture<Object> future = responseFutures.get(seq);
                if (future.isDone()) {
                    Object response = future.get();
                    if (response instanceof Mensagem) {
                        Mensagem mensagem = (Mensagem) response;
                        if (mensagem.isResult() && mensagem.getData() instanceof RespostaUsuarioLista) {
                            RespostaUsuarioLista resposta = (RespostaUsuarioLista) mensagem.getData();
                            List<Pessoa> pessoas = new ArrayList<>();
                            
                            for (RespostaUsuarioLista.Usuario usuario : resposta.getUsuarios()) {
                                Pessoa pessoa = new Pessoa();
                                pessoa.setCodigoPessoa(String.valueOf(usuario.getEnrollid()));
                                pessoa.setNomePessoa(usuario.getName());
                                
                                // Mapear o valor do admin para o tipo de pessoa correspondente
                                switch (usuario.getAdmin()) {
                                    case 0:
                                        pessoa.setTipoPessoa(TipoPessoa.ALUNO);
                                        break;
                                    case 1:
                                        pessoa.setTipoPessoa(TipoPessoa.ALUNO_RESPONSAVEL);
                                        break;
                                    case 2:
                                        pessoa.setTipoPessoa(TipoPessoa.PROFESSOR_FUNCIONARIO);
                                        break;
                                    default:
                                        pessoa.setTipoPessoa(TipoPessoa.TODOS);
                                        break;
                                }
                                
                                // Se tiver foto (record), convertê-la
                                if (usuario.getRecord() != null && !usuario.getRecord().isEmpty()) {
                                    pessoa.setFotoPessoa(usuario.getRecord());
                                }
                                
                                pessoas.add(pessoa);
                            }
                            
                            return pessoas;
                        }
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        
        return new ArrayList<>();
    }
}
