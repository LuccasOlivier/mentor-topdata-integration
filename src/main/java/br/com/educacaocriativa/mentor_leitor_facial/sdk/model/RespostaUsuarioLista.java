package br.com.educacaocriativa.mentor_leitor_facial.sdk.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import java.util.List;

public class RespostaUsuarioLista extends Mensagem {
    @JsonProperty("data")
    private List<Usuario> usuarios;

    public List<Usuario> getUsuarios() {
        return usuarios;
    }

    public void setUsuarios(List<Usuario> usuarios) {
        this.usuarios = usuarios;
    }

    public static class Usuario {
        @JsonProperty("enrollid")
        private long enrollid;

        @JsonProperty("name")
        private String name;

        @JsonProperty("admin")
        private int admin;

        @JsonProperty("backupnum")
        private int backupnum;

        @JsonProperty("record")
        private String record;

        public long getEnrollid() {
            return enrollid;
        }

        public void setEnrollid(long enrollid) {
            this.enrollid = enrollid;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public int getAdmin() {
            return admin;
        }

        public void setAdmin(int admin) {
            this.admin = admin;
        }

        public int getBackupnum() {
            return backupnum;
        }

        public void setBackupnum(int backupnum) {
            this.backupnum = backupnum;
        }

        public String getRecord() {
            return record;
        }

        public void setRecord(String record) {
            this.record = record;
        }
    }
}
