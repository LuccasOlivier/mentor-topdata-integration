package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

/**
 * Enum que representa os possíveis erros do leitor facial
 */
public enum ErroLeitor {
    NAO_CONECTADO("Não conectado ao leitor facial"),
    ERRO_CONEXAO("Erro na conexão com o leitor facial"),
    ERRO_COMANDO("Erro ao enviar comando"),
    ERRO_RESPOSTA("Erro na resposta do leitor"),
    ERRO_PROCESSAMENTO("Erro ao processar dados"),
    ERRO_DESCONHECIDO("Erro desconhecido"),
    SEQUENCIA_INVALIDA("Sequência inválida"),
    DADOS_INVALIDOS("Dados inválidos"),
    IMAGEM_INVALIDA("Imagem inválida"),
    TIMEOUT("Timeout na operação"),
    ERRO_ARQUIVO("Erro ao manipular arquivo"),
    ERRO_PERMISSAO("Permissão negada"),
    ERRO_MEMORIA("Erro de memória"),
    ERRO_CONFIGURACAO("Erro de configuração"),
    ERRO_HARDWARE("Erro de hardware"),
    ERRO_SOFTWARE("Erro de software"),
    ERRO_REDE("Erro de rede"),
    ERRO_SEGURANCA("Erro de segurança"),
    ERRO_AUTENTICACAO("Erro de autenticação"),
    ERRO_CERTIFICADO("Erro de certificado"),
    ERRO_ATUALIZACAO("Erro ao atualizar dados"),
    ERRO_EXPORTACAO("Erro ao exportar dados"),
    ERRO_IMPORTACAO("Erro ao importar dados"),
    ERRO_CACHE("Erro no cache"),
    ERRO_EVENTO("Erro em evento"),
    ERRO_LOG("Erro ao gravar log"),
    ERRO_VALIDACAO("Erro de validação"),
    ERRO_SISTEMA("Erro no sistema");

    private final String mensagem;

    ErroLeitor(String mensagem) {
        this.mensagem = mensagem;
    }

    public String getMensagem() {
        return mensagem;
    }
}
