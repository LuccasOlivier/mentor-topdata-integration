package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

public enum ErroCode {
    // Erros gerais
    SUCCESS(0, "Sucesso"),
    UNKNOWN_ERROR(1, "Erro desconhecido"),
    INVALID_COMMAND(2, "Comando inválido"),
    INVALID_PARAMETER(3, "Parâmetro inválido"),
    
    // Erros de conexão
    CONNECTION_ERROR(100, "Erro de conexão"),
    TIMEOUT(101, "Timeout"),
    CONNECTION_CLOSED(102, "Conexão fechada"),
    
    // Erros de usuário
    USER_NOT_FOUND(200, "Usuário não encontrado"),
    USER_ALREADY_EXISTS(201, "Usuário já existe"),
    INVALID_USER_DATA(202, "Dados do usuário inválidos"),
    
    // Erros de dispositivo
    DEVICE_ERROR(300, "Erro no dispositivo"),
    DEVICE_BUSY(301, "Dispositivo ocupado"),
    DEVICE_DISABLED(302, "Dispositivo desabilitado"),
    DEVICE_NOT_FOUND(303, "Dispositivo não encontrado"),
    
    // Erros de foto
    INVALID_PHOTO(400, "Foto inválida"),
    PHOTO_PROCESSING_ERROR(401, "Erro no processamento da foto"),
    PHOTO_NOT_FOUND(402, "Foto não encontrada"),
    
    // Erros de exportação
    EXPORT_ERROR(500, "Erro na exportação"),
    INVALID_EXPORT_PATH(501, "Caminho de exportação inválido"),
    EXPORT_PERMISSION_DENIED(502, "Permissão negada para exportação");

    private final int code;
    private final String message;

    ErroCode(int code, String message) {
        this.code = code;
        this.message = message;
    }

    public int getCode() {
        return code;
    }

    public String getMessage() {
        return message;
    }
}
