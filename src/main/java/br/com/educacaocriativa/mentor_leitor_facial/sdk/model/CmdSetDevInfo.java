package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CmdSetDevInfo extends Cmd {
    @JsonProperty("devname")
    private String devName;
    
    @JsonProperty("devpwd")
    private String devPwd;
    
    @JsonProperty("devport")
    private int devPort;

    public CmdSetDevInfo(String sequence, String devName, String devPwd, int devPort) {
        super(CmdType.SET_DEV_INFO, sequence);
        this.devName = devName;
        this.devPwd = devPwd;
        this.devPort = devPort;
    }

    public String getDevName() {
        return devName;
    }

    public void setDevName(String devName) {
        this.devName = devName;
    }

    public String getDevPwd() {
        return devPwd;
    }

    public void setDevPwd(String devPwd) {
        this.devPwd = devPwd;
    }

    public int getDevPort() {
        return devPort;
    }

    public void setDevPort(int devPort) {
        this.devPort = devPort;
    }
}
