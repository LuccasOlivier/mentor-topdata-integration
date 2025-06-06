package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

public enum ExportacaoType {
    // Tipos de exportação de dados
    ALL_DATA("all_data"),
    USERS_ONLY("users_only"),
    PHOTOS_ONLY("photos_only"),
    ACCESS_LOGS("access_logs"),
    
    // Tipos de exportação por período
    DAILY("daily"),
    WEEKLY("weekly"),
    MONTHLY("monthly"),
    CUSTOM_PERIOD("custom_period"),
    
    // Tipos de exportação por formato
    CSV("csv"),
    JSON("json"),
    XML("xml"),
    PDF("pdf"),
    
    // Tipos de exportação por conteúdo
    FULL_BACKUP("full_backup"),
    INCREMENTAL_BACKUP("incremental_backup"),
    DATABASE_ONLY("database_only"),
    FILES_ONLY("files_only"),
    
    // Tipos de exportação por usuário
    ALL_USERS("all_users"),
    ACTIVE_USERS("active_users"),
    INACTIVE_USERS("inactive_users"),
    SPECIFIC_USER("specific_user"),
    
    // Tipos de exportação por dispositivo
    CURRENT_DEVICE("current_device"),
    ALL_DEVICES("all_devices"),
    SPECIFIC_DEVICE("specific_device");

    private final String type;

    ExportacaoType(String type) {
        this.type = type;
    }

    public String getType() {
        return type;
    }

    public static ExportacaoType fromString(String text) {
        for (ExportacaoType exportacaoType : ExportacaoType.values()) {
            if (exportacaoType.getType().equalsIgnoreCase(text)) {
                return exportacaoType;
            }
        }
        throw new IllegalArgumentException("Tipo de exportação não reconhecido: " + text);
    }
}
