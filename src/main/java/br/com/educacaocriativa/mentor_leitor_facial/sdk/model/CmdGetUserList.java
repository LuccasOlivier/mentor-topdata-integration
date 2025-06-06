package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CmdGetUserList extends Cmd {

    @JsonProperty("startindex")
    private int startIndex;

    @JsonProperty("count")
    private int count;

    public CmdGetUserList(String sequence) {
        super(CmdType.GET_USER_LIST, sequence);
    }

    public int getStartIndex() {
        return startIndex;
    }

    public void setStartIndex(int startIndex) {
        this.startIndex = startIndex;
    }

    public int getCount() {
        return count;
    }

    public void setCount(int count) {
        this.count = count;
    }
}
