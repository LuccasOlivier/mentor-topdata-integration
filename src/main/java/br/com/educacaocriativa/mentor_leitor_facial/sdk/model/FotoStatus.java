package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

public enum FotoStatus {
    // Estados de processamento
    PROCESSING("processando"),
    WAITING("esperando"),
    QUEUED("na_fila"),
    
    // Estados de sucesso
    SUCCESS("sucesso"),
    COMPLETED("completado"),
    VERIFIED("verificado"),
    
    // Estados de erro
    ERROR("erro"),
    INVALID_FORMAT("formato_invalido"),
    LOW_QUALITY("qualidade_baixa"),
    NO_FACE_DETECTED("sem_rosto"),
    MULTIPLE_FACES("multiplos_rostos"),
    PROCESSING_FAILED("processamento_falhou"),
    STORAGE_FAILED("armazenamento_falhou"),
    
    // Estados de cancelamento
    CANCELED("cancelado"),
    TIMEOUT("timeout"),
    ABORTED("abortado"),
    
    // Estados de validação
    VALIDATING("validando"),
    VALIDATION_FAILED("validacao_falhou"),
    VALIDATION_SUCCESS("validacao_sucesso"),
    
    // Estados de atualização
    UPDATING("atualizando"),
    UPDATE_REQUIRED("atualizacao_necessaria"),
    UPDATE_FAILED("atualizacao_falhou");

    private final String status;

    FotoStatus(String status) {
        this.status = status;
    }

    public String getStatus() {
        return status;
    }

    public static FotoStatus fromString(String text) {
        for (FotoStatus fotoStatus : FotoStatus.values()) {
            if (fotoStatus.getStatus().equalsIgnoreCase(text)) {
                return fotoStatus;
            }
        }
        throw new IllegalArgumentException("Status de foto não reconhecido: " + text);
    }
}
