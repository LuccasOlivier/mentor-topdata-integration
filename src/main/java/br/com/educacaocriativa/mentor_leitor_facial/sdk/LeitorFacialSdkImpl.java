package br.com.educacaocriativa.mentor_leitor_facial.sdk;

import br.com.educacaocriativa.mentor_leitor_facial.model.Pessoa;
import br.com.educacaocriativa.mentor_leitor_facial.model.TipoPessoa;
// Adicionada importação da classe Exportacao
import br.com.educacaocriativa.mentor_leitor_facial.sdk.model.*;

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

public class LeitorFacialSdkImpl implements LeitorFacialSdk {

    private static final String WEBSOCKET_URL = "ws://localhost:7792/pub/chat";
    private static final ObjectMapper objectMapper = new ObjectMapper();
    private static final AtomicInteger sequence = new AtomicInteger(0);

    private HttpClient httpClient;
    private WebSocket webSocket;
    private boolean conectado = false;

    private final ConcurrentHashMap<String, CompletableFuture<Object>> responseFutures = new ConcurrentHashMap<>();

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
                        }

                        @Override
                        public CompletionStage<?> onClose(WebSocket webSocket, int statusCode, String reason) {
                            conectado = false;
                            System.out.println("Conexão encerrada: " + reason);
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
        }
        return true;
    }

    @Override
    public boolean cadastrarPessoa(Pessoa pessoa, byte[] foto) throws IOException {
        CmdSendUser cmd = new CmdSendUser(String.valueOf(sequence.incrementAndGet()));
        cmd.setEnrollid(Long.parseLong(pessoa.getCodigoPessoa()));
        cmd.setName(pessoa.getNomePessoa());
        cmd.setRecord(new String(foto)); // Certifique-se que o formato da imagem é suportado
        cmd.setAdmin(pessoa.getTipoPessoa().ordinal());
        cmd.setBackupnum(BackupNum.FACE.getValue());
        return sendCommand(cmd);
    }

    @Override
    public boolean removerPessoa(String codigo) throws IOException {
        String seq = String.valueOf(sequence.incrementAndGet());
        long enrollId = Long.parseLong(codigo);
        CmdDeleteUser cmd = new CmdDeleteUser(seq, enrollId); // passa os dois
    
        // backupnum já vem como 3 no construtor, mas pode reforçar se necessário
        cmd.setBackupnum(BackupNum.FACE.getValue());
    
        return sendCommand(cmd);
    }

    @Override
    public boolean atualizarPessoa(Pessoa pessoa, byte[] foto) throws IOException {
        return cadastrarPessoa(pessoa, foto); // mesma lógica do cadastro
    }

    @Override
    public boolean estaCadastrada(String codigo) throws IOException {
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
        CmdSendUser cmd = new CmdSendUser(String.valueOf(sequence.incrementAndGet()));
        cmd.setEnrollid(Long.parseLong(codigo));
        cmd.setRecord(new String(foto));
        cmd.setBackupnum(BackupNum.FACE.getValue());
        return sendCommand(cmd);
    }

    @Override
    public boolean exportarDados(String caminho) throws IOException {
        // Tipos de exportação:
        // 0 - Todos os dados
        // 1 - Apenas cadastros
        // 2 - Apenas logs de acesso
        int tipoExportacao = 0; // Exportar todos os dados
        
        CmdExportarDados cmd = new CmdExportarDados(
            String.valueOf(sequence.incrementAndGet()),
            tipoExportacao,
            caminho
        );

        if (!sendCommand(cmd)) {
            return false;
        }

        try {
            // Aguardar a resposta
            Thread.sleep(1000);
            
            String seq = cmd.getSequence();
            if (responseFutures.containsKey(seq)) {
                CompletableFuture<Object> future = responseFutures.get(seq);
                if (future.isDone()) {
                    Object response = future.get();
                    if (response instanceof Mensagem) {
                        Mensagem mensagem = (Mensagem) response;
                        if (mensagem.isResult() && mensagem.getData() instanceof RespostaExportacao) {
                            RespostaExportacao resposta = (RespostaExportacao) mensagem.getData();
                            Exportacao exportacao = resposta.getExportacao();
                            
                            if (exportacao.getStatus() == 0) { // Sucesso
                                return true;
                            } else {
                                throw new IOException("Erro na exportação: " + exportacao.getMessage());
                            }
                        }
                    }
                }
            }
        } catch (Exception e) {
            throw new IOException("Erro ao exportar dados: " + e.getMessage(), e);
        }
        
        return false;
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

    private boolean sendCommand(Cmd cmd) throws IOException {
        String seq = cmd.getSequence();
        CompletableFuture<Object> future = new CompletableFuture<>();
        responseFutures.put(seq, future);

        String json = objectMapper.writeValueAsString(cmd);
        webSocket.sendText(json, true).join();

        try {
            return (boolean) future.get();
        } catch (Exception e) {
            throw new IOException("Erro ao enviar comando: " + e.getMessage(), e);
        } finally {
            responseFutures.remove(seq);
        }
    }

    private void handleResponse(String response) {
        try {
            Mensagem mensagem = objectMapper.readValue(response, Mensagem.class);
            String seq = mensagem.getSequence();

            if (responseFutures.containsKey(seq)) {
                responseFutures.get(seq).complete(mensagem.isResult());
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
