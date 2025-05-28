package br.com.educacaocriativa.mentor_leitor_facial;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HomeController {

    @GetMapping("/")
    public String home() {
        return "Projeto Mentor + Leitor facial está rodando!";
    }
}