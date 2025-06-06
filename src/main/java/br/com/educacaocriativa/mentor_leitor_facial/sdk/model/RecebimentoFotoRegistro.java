package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RecebimentoFotoRegistro {
    @JsonProperty("enrollid")
    private long enrollid;
    
    @JsonProperty("image")
    private String image; // Base64 da imagem
    
    @JsonProperty("timestamp")
    private String timestamp;
    
    @JsonProperty("devname")
    private String devName;
    
    @JsonProperty("status")
    private StatusType status;
    
    @JsonProperty("confidence")
    private float confidence;

    public long getEnrollid() {
        return enrollid;
    }

    public void setEnrollid(long enrollid) {
        this.enrollid = enrollid;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
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

    public StatusType getStatus() {
        return status;
    }

    public void setStatus(StatusType status) {
        this.status = status;
    }

    public float getConfidence() {
        return confidence;
    }

    public void setConfidence(float confidence) {
        this.confidence = confidence;
    }
}
