package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * Classe que representa uma resposta de erro do leitor facial
 */
public class ErroLeitorResponse {
    @JsonProperty("message")
    private String message;
    
    @JsonProperty("devname")
    private String devName;

    public ErroLeitorResponse() {
    }

    public ErroLeitorResponse(String message, String devName) {
        this.message = message;
        this.devName = devName;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public String getDevName() {
        return devName;
    }

    public void setDevName(String devName) {
        this.devName = devName;
    }
}
