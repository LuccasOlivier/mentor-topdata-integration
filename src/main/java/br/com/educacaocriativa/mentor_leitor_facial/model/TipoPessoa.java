package br.com.educacaocriativa.mentor_leitor_facial.model;

public enum TipoPessoa {
    ALUNO("ALUNO"),
    ALUNO_RESPONSAVEL("ALUNO_RESPONSAVEL"),
    PROFESSOR_FUNCIONARIO("PROFESSOR_FUNCIONARIO"),
    TODOS("TODOS");

    private final String valor;

    TipoPessoa(String valor) {
        this.valor = valor;
    }

    public String getValor(){
        return valor;
    }

    public static TipoPessoa fromValor(String valor){
        for (TipoPessoa tipo : values()) {
            if (tipo.valor.equals(valor)){
                return tipo;
            }
        }
        throw new IllegalArgumentException("Tipo de pessoa inválido: " + valor);
    }
}