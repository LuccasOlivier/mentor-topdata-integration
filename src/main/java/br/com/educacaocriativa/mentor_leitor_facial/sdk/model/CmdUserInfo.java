package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CmdUserInfo {
    @JsonProperty("cmd")
    private String cmd;
    
    @JsonProperty("enrollid")
    private long enrollid;
    
    @JsonProperty("backupnum")
    private int backupnum;
    
    @JsonProperty("seq")
    private int seq;

    public CmdUserInfo() {
        this.cmd = "getuserinfo";
    }

    public String getCmd() {
        return cmd;
    }

    public void setCmd(String cmd) {
        this.cmd = cmd;
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

    public int getSeq() {
        return seq;
    }

    public void setSeq(int seq) {
        this.seq = seq;
    }
}
