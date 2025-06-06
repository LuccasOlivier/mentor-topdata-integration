package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

public enum AccessType {
    // Tipos de acesso padrão
    SUCCESSFUL_ACCESS("successful_access"),
    FAILED_ACCESS("failed_access"),
    DENIED_ACCESS("denied_access"),
    
    // Tipos de acesso por método
    FACE_RECOGNITION("face_recognition"),
    MANUAL_ACCESS("manual_access"),
    CARD_ACCESS("card_access"),
    
    // Tipos de acesso por direção
    ENTRY_ACCESS("entry_access"),
    EXIT_ACCESS("exit_access"),
    
    // Tipos de acesso por situação
    UNAUTHORIZED_ACCESS("unauthorized_access"),
    INVALID_CREDENTIALS("invalid_credentials"),
    TIMEOUT_ACCESS("timeout_access"),
    
    // Tipos de acesso por dispositivo
    PRIMARY_DEVICE("primary_device"),
    SECONDARY_DEVICE("secondary_device"),
    REMOTE_ACCESS("remote_access");

    private final String type;

    AccessType(String type) {
        this.type = type;
    }

    public String getType() {
        return type;
    }

    public static AccessType fromString(String text) {
        for (AccessType accessType : AccessType.values()) {
            if (accessType.getType().equalsIgnoreCase(text)) {
                return accessType;
            }
        }
        throw new IllegalArgumentException("Tipo de acesso não reconhecido: " + text);
    }
}
