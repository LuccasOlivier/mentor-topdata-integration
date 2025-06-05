package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public abstract class Cmd {
    @JsonProperty("cmd")
    private final String command;

    @JsonProperty("seq")
    private final String sequence;

    protected Cmd(CmdType type, String sequence) {
        this.command = type.getCommand();
        this.sequence = sequence;
    }

    public String getCommand() {
        return command;
    }

    public String getSequence() {
        return sequence;
    }
}
