package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

public enum CmdType {
    SET_USER_INFO("setuserinfo"),
    DELETE_USER("deleteuser"),
    GET_USER_LIST("getuserlist"),
    GET_USER_INFO("getuserinfo"),
    SET_DEV_INFO("setdevinfo"),
    DISABLE_DEVICE("disabledevice"),
    ENABLE_DEVICE("enabledevice"),
    GET_STATUS("getstatus"),
    EXPORT_DATA("exportdata"); // 

    private final String command;

    CmdType(String command) {
        this.command = command;
    }

    public String getCommand() {
        return command;
    }
}
