package br.com.educacaocriativa.mentor_leitor_facial.config;

import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;

@Configuration
@PropertySource("classpath:application-${spring.profiles.active}.properties")
public class AmbienteConfig {
    // Esta classe apenas carrega as propriedades corretas
}
