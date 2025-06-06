package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;



public class CmdGetDevInfo extends Cmd {
    public CmdGetDevInfo(String sequence) {
        super(CmdType.SET_DEV_INFO, sequence);
    }
}
