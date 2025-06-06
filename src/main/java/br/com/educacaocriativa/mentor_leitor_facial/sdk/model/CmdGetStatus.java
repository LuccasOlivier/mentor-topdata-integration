package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

public class CmdGetStatus extends Cmd {
    public CmdGetStatus(String sequence) {
        super(CmdType.GET_STATUS, sequence);
    }
}
