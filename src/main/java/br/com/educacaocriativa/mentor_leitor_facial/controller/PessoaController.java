package br.com.educacaocriativa.mentor_leitor_facial.controller;

import br.com.educacaocriativa.mentor_leitor_facial.model.Pessoa;
import br.com.educacaocriativa.mentor_leitor_facial.service.PessoaService;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/pessoas")
public class PessoaController {

    private final PessoaService pessoaService;

    // Construtor - injeção de dependência
    public PessoaController(PessoaService pessoaService) {
        this.pessoaService = pessoaService;
    }

    // Endpoint GET que retorna a lista de pessoas ativas
    @GetMapping("/ativas")
    public List<Pessoa> listarPessoasAtivas() {
        return pessoaService.listarPessoasAtivas();
    }
}
