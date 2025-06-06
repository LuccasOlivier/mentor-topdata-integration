package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RespostaExportacao extends Mensagem {
    @JsonProperty("data")
    private Exportacao exportacao;

    public Exportacao getExportacao() {
        return exportacao;
    }

    public void setExportacao(Exportacao exportacao) {
        this.exportacao = exportacao;
    }
}
