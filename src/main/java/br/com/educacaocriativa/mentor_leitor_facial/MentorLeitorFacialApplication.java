package br.com.educacaocriativa.mentor_leitor_facial;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.properties.EnableConfigurationProperties;

@SpringBootApplication
@EnableConfigurationProperties 
public class MentorLeitorFacialApplication {
    public static void main(String[] args) {
        SpringApplication.run(MentorLeitorFacialApplication.class, args);
    }
}
