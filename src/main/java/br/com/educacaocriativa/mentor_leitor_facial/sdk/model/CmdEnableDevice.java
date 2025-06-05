package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CmdEnableDevice extends Cmd {
    @JsonProperty("devpwd")
    private String devPwd;

    public CmdEnableDevice(String sequence, String devPwd) {
        super(CmdType.ENABLE_DEVICE, sequence);
        this.devPwd = devPwd;
    }

    public String getDevPwd() {
        return devPwd;
    }

    public void setDevPwd(String devPwd) {
        this.devPwd = devPwd;
    }
}
