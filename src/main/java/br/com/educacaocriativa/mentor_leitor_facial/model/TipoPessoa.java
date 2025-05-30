package br.com.educacaocriativa.mentor_leitor_facial.model;

public enum TipoPessoa {
    ALUNO,
    RESPONSAVEL,
    PROFESSOR,
    FUNCIONARIO;

    @Override
    public String toString() {
        return name().toLowerCase();
    }
}
