package br.com.educacaocriativa.mentor_leitor_facial.model;

public class Pessoa {
    private String codigoPessoa; // PES_CODTEL
    private String nomePessoa;   // PES_NOME
    private String nomeCivil;    // PES_NOMCIV
    private String fotoPessoa;   // HASH DA FOTO
    private TipoPessoa tipoPessoa;
    private String situacaoPessoa;
    private String unidade;      // id da unidade
    private boolean ativo;
    private String matricula;
    private String cpf;

    // Construtor vazio (obrigatório pro Spring)
    public Pessoa() {
    }

    // Construtor completo
    public Pessoa(String codigoPessoa, String nomePessoa, String nomeCivil, String fotoPessoa, TipoPessoa tipoPessoa, 
                  String situacaoPessoa, String unidade, boolean ativo, String matricula, String cpf) {
        this.codigoPessoa = codigoPessoa;
        this.nomePessoa = nomePessoa;
        this.nomeCivil = nomeCivil;
        this.fotoPessoa = fotoPessoa;
        this.tipoPessoa = tipoPessoa;
        this.situacaoPessoa = situacaoPessoa;
        this.unidade = unidade;
        this.ativo = ativo;
        this.matricula = matricula;
        this.cpf = cpf;
    }

    // Getters e Setters
    public String getCodigoPessoa() {
        return codigoPessoa;
    }

    public void setCodigoPessoa(String codigoPessoa) {
        this.codigoPessoa = codigoPessoa;
    }

    public String getNomePessoa() {
        return nomePessoa;
    }

    public void setNomePessoa(String nomePessoa) {
        this.nomePessoa = nomePessoa;
    }

    public String getNomeCivil() {
        return nomeCivil;
    }

    public void setNomeCivil(String nomeCivil) {
        this.nomeCivil = nomeCivil;
    }

    public String getFotoPessoa() {
        return fotoPessoa;
    }

    public void setFotoPessoa(String fotoPessoa) {
        this.fotoPessoa = fotoPessoa;
    }

    public TipoPessoa getTipoPessoa() {
        return tipoPessoa;
    }

    public void setTipoPessoa(TipoPessoa tipoPessoa) {
        this.tipoPessoa = tipoPessoa;
    }

    public String getSituacaoPessoa() {
        return situacaoPessoa;
    }

    public void setSituacaoPessoa(String situacaoPessoa) {
        this.situacaoPessoa = situacaoPessoa;
    }

    public String getUnidade() {
        return unidade;
    }

    public void setUnidade(String unidade) {
        this.unidade = unidade;
    }

    public boolean isAtivo() {
        return ativo;
    }

    public void setAtivo(boolean ativo) {
        this.ativo = ativo;
    }

    public String getMatricula() {
        return matricula;
    }

    public void setMatricula(String matricula) {
        this.matricula = matricula;
    }

    public String getCpf() {
        return cpf;
    }

    public void setCpf(String cpf) {
        this.cpf = cpf;
    }

    // toString (útil pra debugar)
    @Override
    public String toString() {
        return "Pessoa{" +
                "codigoPessoa='" + codigoPessoa + '\'' +
                ", nomePessoa='" + nomePessoa + '\'' +
                ", nomeCivil='" + nomeCivil + '\'' +
                ", fotoPessoa='" + fotoPessoa + '\'' +
                ", tipoPessoa=" + tipoPessoa +
                ", situacaoPessoa='" + situacaoPessoa + '\'' +
                ", unidade='" + unidade + '\'' +
                ", ativo=" + ativo +
                ", matricula='" + matricula + '\'' +
                ", cpf='" + cpf + '\'' +
                '}';
    }
}