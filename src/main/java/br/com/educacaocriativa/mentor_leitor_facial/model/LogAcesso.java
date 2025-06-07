package br.com.educacaocriativa.mentor_leitor_facial.model;

import jakarta.persistence.*;
import lombok.Data;
import java.time.LocalDateTime;

@Data
@Entity
@Table(name = "log_acesso")
public class LogAcesso {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false)
    private LocalDateTime dataHora;

    @Column(nullable = false, length = 50)
    private String tipoOperacao;

    @Column(length = 100)
    private String codigoPessoa;

    @Column(length = 255)
    private String mensagem;

    @Column(length = 50)
    private String nivelLog;

    @Column(length = 1000)
    private String detalhes;

    @Column(length = 50)
    private String status;

    @Column(length = 50)
    private String ipCliente;

    @Column(length = 50)
    private String usuarioSistema;

    public LogAcesso() {
        this.dataHora = LocalDateTime.now();
    }
}
