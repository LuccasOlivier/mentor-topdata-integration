package br.com.educacaocriativa.mentor_leitor_facial.model;

public class Pessoa {
    private String id;
    private String nome;
    private String cpf;
    private String matricula;
    private String tipo; // aluno, professor, funcionário
    private boolean ativo; // true se está ativo, false se inativo;

    // Construtor vazio (obrigatório pro Spring)
    public Pessoa() {
    }

    // Construtor completo
    public Pessoa(String nome, String id, String cpf, String matricula, String tipo, boolean ativo) {
        this.nome = nome;
        this.id = id;
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

    public String getTipo() {
        return tipo;
    }

    public void setTipo(String tipo) {
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
                ", tipo='" + tipo + '\'' +
                ", ativo=" + ativo +
                '}';
    }
}
