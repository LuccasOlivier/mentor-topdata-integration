package br.com.educacaocriativa.mentor_leitor_facial.dto;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class RegistroAcessoDTO {
    private String codigoIdentificacaoPessoa;
    private String tipoAcesso;
    private String dataHora;
    private String tipoTurno;
}