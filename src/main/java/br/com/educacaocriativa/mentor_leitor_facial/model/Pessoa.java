package br.com.educacaocriativa.mentor_leitor_facial.model;

public class Pessoa {
    private String id;
    private String nome;
    private String cpf;
    private String matricula;
    private TipoPessoa tipo; // aluno, professor, funcionário, responsável
    private boolean ativo; // true se está ativo, false se inativo;

    // Construtor vazio (obrigatório pro Spring)
    public Pessoa() {
    }

    // Construtor completo
    public Pessoa(String id, String nome, String cpf, String matricula, TipoPessoa tipo, boolean ativo) {
        this.id = id;
        this.nome = nome;
        this.cpf = cpf;
        this.matricula = matricula;
        this.tipo = tipo;
        this.ativo = ativo;

    }

    // Getters e Setters
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getCpf() {
        return cpf;
    }

    public void setCpf(String cpf) {
        this.cpf = cpf;
    }

    public String getMatricula() {
        return matricula;
    }

    public void setMatricula(String matricula) {
        this.matricula = matricula;
    }

    public TipoPessoa getTipo() {
        return tipo;
    }

    public void setTipo(TipoPessoa tipo) {
        this.tipo = tipo;
    }

    public boolean isAtivo() {
        return ativo;
    }

    public void setAtivo(boolean ativo) {
        this.ativo = ativo;
    }

    // toString (útil pra debugar)
    @Override
    public String toString() {
        return "Pessoa{" +
                "id='" + id + '\'' +
                ", nome='" + nome + '\'' +
                ", cpf='" + cpf + '\'' +
                ", matricula='" + matricula + '\'' +
                ", tipo=" + tipo +
                ", ativo=" + ativo +
                '}';
    }
}
