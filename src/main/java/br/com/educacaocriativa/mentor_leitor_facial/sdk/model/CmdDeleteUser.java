package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CmdDeleteUser extends Cmd {
    @JsonProperty("enrollid")
    private long enrollid;
    
    @JsonProperty("backupnum")
    private int backupnum;

    public CmdDeleteUser(String sequence, long enrollid) {
        super(CmdType.DELETE_USER, sequence);
        this.enrollid = enrollid;
        this.backupnum = 3; // BackupNum.Todos - Remove todos os dados do usuário
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
