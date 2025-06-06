package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

public enum StatusType {
    // Estados de operação
    OPERATIONAL("operacional"),
    MAINTENANCE("manutencao"),
    DISABLED("desabilitado"),
    
    // Estados de conexão
    CONNECTED("conectado"),
    DISCONNECTED("desconectado"),
    RECONNECTING("reconectando"),
    
    // Estados de erro
    ERROR("erro"),
    WARNING("aviso"),
    CRITICAL("critico"),
    
    // Estados de inicialização
    BOOTING("inicializando"),
    READY("pronto"),
    SHUTTING_DOWN("desligando"),
    
    // Estados de processamento
    PROCESSING("processando"),
    IDLE("ocioso"),
    BUSY("ocupado"),
    
    // Estados de atualização
    UPDATING("atualizando"),
    UPDATE_READY("atualizacao_pronta"),
    UPDATE_FAILED("atualizacao_falhou");

    private final String status;

    StatusType(String status) {
        this.status = status;
    }

    public String getStatus() {
        return status;
    }

    public static StatusType fromString(String text) {
        for (StatusType statusType : StatusType.values()) {
            if (statusType.getStatus().equalsIgnoreCase(text)) {
                return statusType;
            }
        }
        throw new IllegalArgumentException("Status não reconhecido: " + text);
    }
}
