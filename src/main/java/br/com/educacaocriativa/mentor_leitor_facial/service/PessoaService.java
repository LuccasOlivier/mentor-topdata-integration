package br.com.educacaocriativa.mentor_leitor_facial.service;

import br.com.educacaocriativa.mentor_leitor_facial.model.Pessoa;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class PessoaService {

    // Este método simula a busca de pessoas (futuramente virá da API do Mentor)
    public List<Pessoa> listarPessoasAtivas() {
        List<Pessoa> pessoas = new ArrayList<>();

        pessoas.add(new Pessoa("Lucas Oliveira", "123", "111.111.111-11", "2023001", "Aluno", true));
        pessoas.add(new Pessoa("Maria Oliveira", "456", "222.222.222-22", "2023002", "Professor", true));
        pessoas.add(new Pessoa("Carlos Souza", "789", "333.333.333-33", "2023003", "Funcionário", true));

        return pessoas;
    }
}
