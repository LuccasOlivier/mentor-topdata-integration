package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CmdExportarDados extends Cmd {
    @JsonProperty("exporttype")
    private int exportType;

    @JsonProperty("path")
    private String path;

    public CmdExportarDados(String sequence, int exportType, String path) {
        super(CmdType.EXPORT_DATA, sequence);
        this.exportType = exportType;
        this.path = path;
    }

    public int getExportType() {
        return exportType;
    }

    public void setExportType(int exportType) {
        this.exportType = exportType;
    }

    public String getPath() {
        return path;
    }

    public void setPath(String path) {
        this.path = path;
    }
}
