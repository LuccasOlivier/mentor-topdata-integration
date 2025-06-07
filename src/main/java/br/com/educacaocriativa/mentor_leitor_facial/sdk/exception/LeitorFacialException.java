package br.com.educacaocriativa.mentor_leitor_facial.sdk.exception;

import br.com.educacaocriativa.mentor_leitor_facial.sdk.model.ErroLeitor;

public class LeitorFacialException extends RuntimeException {
    private final ErroLeitor erro;
    private final String codigo;
    private final String mensagem;

    public LeitorFacialException(ErroLeitor erro, String codigo, String mensagem) {
        super(mensagem);
        this.erro = erro;
        this.codigo = codigo;
        this.mensagem = mensagem;
    }

    public LeitorFacialException(ErroLeitor erro, String mensagem) {
        this(erro, null, mensagem);
    }

    public LeitorFacialException(String mensagem) {
        this(ErroLeitor.ERRO_DESCONHECIDO, null, mensagem);
    }

    public ErroLeitor getErro() {
        return erro;
    }

    public String getCodigo() {
        return codigo;
    }

    public String getMensagem() {
        return mensagem;
    }
}
