package br.com.educacaocriativa.mentor_leitor_facial.sdk;

import br.com.educacaocriativa.mentor_leitor_facial.model.Pessoa;
import java.io.IOException;
import java.util.List;

/**
 * Interface que define as operações do SDK do Leitor Facial Topdata T4.
 * Esta interface deve ser implementada pela classe concreta que fará a comunicação
 * com o leitor facial via WebSocket.
 */
public interface LeitorFacialSdk {
    
    /**
     * Estabelece a conexão com o leitor facial via WebSocket.
     * @throws IOException Se houver erro na conexão
     */
    boolean conectar() throws IOException;
    
    /**
     * Encerra a conexão com o leitor facial.
     */
    boolean desconectar() throws IOException;
    
    /**
     * Cadastra uma nova pessoa no leitor facial.
     * @param pessoa Objeto Pessoa com os dados a serem cadastrados
     * @param foto Imagem facial da pessoa em formato byte[]
     * @return true se o cadastro foi bem-sucedido, false caso contrário
     * @throws IOException Se houver erro na comunicação com o leitor
     */
    boolean cadastrarPessoa(Pessoa pessoa, byte[] foto) throws IOException;
    
    /**
     * Remove o cadastro de uma pessoa do leitor facial.
     * @param codigo Código da pessoa a ser removida
     * @return true se a remoção foi bem-sucedida, false caso contrário
     * @throws IOException Se houver erro na comunicação com o leitor
     */
    boolean removerPessoa(String codigo) throws IOException;
    
    /**
     * Atualiza os dados de uma pessoa já cadastrada no leitor facial.
     * @param pessoa Objeto Pessoa com os novos dados
     * @param foto Nova imagem facial da pessoa em formato byte[]
     * @return true se a atualização foi bem-sucedida, false caso contrário
     * @throws IOException Se houver erro na comunicação com o leitor
     */
    boolean atualizarPessoa(Pessoa pessoa, byte[] foto) throws IOException;
    
    /**
     * Verifica se uma pessoa está cadastrada no leitor facial.
     * @param codigo Código da pessoa a ser verificada
     * @return true se a pessoa está cadastrada, false caso contrário
     * @throws IOException Se houver erro na comunicação com o leitor
     */
    boolean estaCadastrada(String codigo) throws IOException;
    
    /**
     * Obtém o status atual do leitor facial.
     * @return String contendo o status do leitor
     * @throws IOException Se houver erro na comunicação com o leitor
     */
    String getStatus() throws IOException;
    
    /**
     * Envia uma foto para o leitor facial.
     * @param codigo Código da pessoa associada à foto
     * @param foto Imagem em formato byte[]
     * @return true se o envio foi bem-sucedido, false caso contrário
     * @throws IOException Se houver erro na comunicação com o leitor
     */
    boolean enviarFoto(String codigo, byte[] foto) throws IOException;
    
    /**
     * Exporta os dados do leitor facial para um arquivo.
     * @param caminho Caminho completo onde o arquivo será salvo
     * @return true se a exportação foi bem-sucedida, false caso contrário
     * @throws IOException Se houver erro na comunicação com o leitor ou ao salvar o arquivo
     */
    boolean exportarDados(String caminho) throws IOException;
    
    /**
     * Obtém a lista de pessoas cadastradas no leitor facial.
     * @return Lista de objetos Pessoa cadastrados
     * @throws IOException Se houver erro na comunicação com o leitor
     */
    List<Pessoa> listarPessoas() throws IOException;
}
