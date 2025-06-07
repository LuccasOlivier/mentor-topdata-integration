package br.com.educacaocriativa.mentor_leitor_facial.config;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ActiveProfiles;

@SpringBootTest
@ActiveProfiles("dev")
public class ConfigTest {

    @Autowired
    private LeitorFacialConfig config;

    @Test
    public void testConfiguracao() {
        System.out.println("IP do Leitor: " + config.getIp());
        System.out.println("Porta: " + config.getPorta());
        System.out.println("Tipo de Conexão: " + config.getTipoConexao());
        System.out.println("Caminho SDK: " + config.getCaminhoSdk());

        // Verificações básicas
        assert config.getIp() != null;
        assert config.getPorta() > 0;
        assert config.getTipoConexao() != null;
        assert config.getCaminhoSdk() != null;
    }
}
