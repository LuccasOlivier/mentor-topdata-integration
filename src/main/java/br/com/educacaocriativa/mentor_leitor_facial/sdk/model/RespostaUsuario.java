package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RespostaUsuario {
    @JsonProperty("enrollid")
    private long enrollid;
    
    @JsonProperty("name")
    private String name;
    
    @JsonProperty("backupnum")
    private int backupnum;
    
    @JsonProperty("admin")
    private int admin;

    // Getters e Setters
    public long getEnrollid() {
        return enrollid;
    }

    public void setEnrollid(long enrollid) {
        this.enrollid = enrollid;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getBackupnum() {
        return backupnum;
    }

    public void setBackupnum(int backupnum) {
        this.backupnum = backupnum;
    }

    public int getAdmin() {
        return admin;
    }

    public void setAdmin(int admin) {
        this.admin = admin;
    }
}