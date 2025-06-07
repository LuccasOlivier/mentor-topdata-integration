package br.com.educacaocriativa.mentor_leitor_facial.config;

import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.context.annotation.Configuration;
import jakarta.annotation.PostConstruct;

@Configuration
@ConfigurationProperties(prefix = "leitor.facial")
public class LeitorFacialConfig {

    private String ip;
    private int porta;
    private String tipoConexao;
    private String caminhoSdk;

    // Getters e Setters
    public String getIp() {
        return ip;
    }

    public void setIp(String ip) {
        this.ip = ip;
    }

    public int getPorta() {
        return porta;
    }

    public void setPorta(int porta) {
        this.porta = porta;
    }

    public String getTipoConexao() {
        return tipoConexao;
    }

    public void setTipoConexao(String tipoConexao) {
        this.tipoConexao = tipoConexao;
    }

    public String getCaminhoSdk() {
        return caminhoSdk;
    }

    public void setCaminhoSdk(String caminhoSdk) {
        this.caminhoSdk = caminhoSdk;
    }

    @PostConstruct
    public void init() {
        System.out.println("Configuração do Leitor Facial carregada:");
        System.out.println("IP Leitor: " + ip);
        System.out.println("Porta Leitor: " + porta);
        System.out.println("Tipo Conexão: " + tipoConexao);
        System.out.println("Caminho SDK: " + caminhoSdk);
    }
}
