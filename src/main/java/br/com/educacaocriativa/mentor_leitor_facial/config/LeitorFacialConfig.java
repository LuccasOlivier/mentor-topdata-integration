package br.com.educacaocriativa.mentor_leitor_facial.config;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import jakarta.annotation.PostConstruct;

@Configuration
public class LeitorFacialConfig {
    
    @Value("${leitor.facial.ip}")
    private String ipLeitor;
    
    @Value("${leitor.facial.porta}")
    private int portaLeitor;
    
    @Value("${leitor.facial.tipo-conexao}")
    private String tipoConexao;
    
    @Value("${leitor.facial.caminho-sdk}")
    private String caminhoSdk;

    // Getters
    public String getIpLeitor() {
        return ipLeitor;
    }

    public int getPortaLeitor() {
        return portaLeitor;
    }

    public String getTipoConexao() {
        return tipoConexao;
    }

    public String getCaminhoSdk() {
        return caminhoSdk;
    }

    @PostConstruct
    public void init() {
        System.out.println("Configuração do Leitor Facial carregada:");
        System.out.println("IP Leitor: " + ipLeitor);
        System.out.println("Porta Leitor: " + portaLeitor);
        System.out.println("Tipo Conexão: " + tipoConexao);
        System.out.println("Caminho SDK: " + caminhoSdk);
    }
}
