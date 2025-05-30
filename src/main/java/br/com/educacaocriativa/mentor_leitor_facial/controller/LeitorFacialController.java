package br.com.educacaocriativa.mentor_leitor_facial.controller;

import br.com.educacaocriativa.mentor_leitor_facial.model.Pessoa;
import br.com.educacaocriativa.mentor_leitor_facial.service.LeitorFacialService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/leitor")
public class LeitorFacialController {

    @Autowired
    private LeitorFacialService leitorFacialService;

    // Endpoint para listar pessoas cadastradas no leitor
    @GetMapping("/pessoas")
    public List<Pessoa> listarPessoasNoLeitor() {
        return leitorFacialService.listarPessoasNoLeitor();
    }

    // Endpoint para sincronizar uma lista de pessoas com o leitor
    @PostMapping("/sincronizar")
    public String sincronizarPessoas(@RequestBody List<Pessoa> pessoas) {
        return leitorFacialService.sincronizarPessoasComLeitor(pessoas);
    }

    // Endpoint para remover uma pessoa do leitor (usando ID ou matrícula)
    @DeleteMapping("/remover/{id}")
    public String removerPessoa(@PathVariable String id) {
        return leitorFacialService.removerPessoaDoLeitor(id);
    }
}
