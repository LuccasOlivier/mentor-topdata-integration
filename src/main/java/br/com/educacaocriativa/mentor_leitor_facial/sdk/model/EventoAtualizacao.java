package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class EventoAtualizacao {
    @JsonProperty("eventtype")
    private String eventType;
    
    @JsonProperty("enrollid")
    private long enrollid;
    
    @JsonProperty("name")
    private String name;
    
    @JsonProperty("timestamp")
    private String timestamp;
    
    @JsonProperty("devname")
    private String devName;
    
    @JsonProperty("status")
    private boolean status;
    
    @JsonProperty("backupnum")
    private int backupnum;

    public String getEventType() {
        return eventType;
    }

    public void setEventType(String eventType) {
        this.eventType = eventType;
    }

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

    public String getTimestamp() {
        return timestamp;
    }

    public void setTimestamp(String timestamp) {
        this.timestamp = timestamp;
    }

    public String getDevName() {
        return devName;
    }

    public void setDevName(String devName) {
        this.devName = devName;
    }

    public boolean isStatus() {
        return status;
    }

    public void setStatus(boolean status) {
        this.status = status;
    }

    public int getBackupnum() {
        return backupnum;
    }

    public void setBackupnum(int backupnum) {
        this.backupnum = backupnum;
    }
}
