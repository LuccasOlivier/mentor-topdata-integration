package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CmdSendUser extends Cmd {
    @JsonProperty("enrollid")
    private long enrollid;

    @JsonProperty("name")
    private String name;

    @JsonProperty("backupnum")
    private int backupnum;

    @JsonProperty("admin")
    private int admin;

    @JsonProperty("record")
    private String record;

    public CmdSendUser(String sequence) {
        super(CmdType.SET_USER_INFO, sequence);
    }

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

    public String getRecord() {
        return record;
    }

    public void setRecord(String record) {
        this.record = record;
    }
}
