package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

public enum BackupNum {
    FACE(0),
    CARTAO(1),
    SENHA(2);

    private final int value;

    BackupNum(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }

    public static BackupNum fromInt(int value) {
        for (BackupNum backupNum : BackupNum.values()) {
            if (backupNum.getValue() == value) {
                return backupNum;
            }
        }
        throw new IllegalArgumentException("Valor de backup não reconhecido: " + value);
    }
}
