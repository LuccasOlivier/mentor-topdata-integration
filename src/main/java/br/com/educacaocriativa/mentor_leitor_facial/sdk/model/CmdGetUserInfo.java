package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CmdGetUserInfo extends Cmd {
    @JsonProperty("enrollid")
    private long enrollid;
    
    @JsonProperty("backupnum")
    private int backupnum;

    public CmdGetUserInfo(String sequence, long enrollid, int backupnum) {
        super(CmdType.GET_USER_INFO, sequence);
        this.enrollid = enrollid;
        this.backupnum = backupnum;
    }

    public long getEnrollid() {
        return enrollid;
    }

    public void setEnrollid(long enrollid) {
        this.enrollid = enrollid;
    }

    public int getBackupnum() {
        return backupnum;
    }

    public void setBackupnum(int backupnum) {
        this.backupnum = backupnum;
    }
}