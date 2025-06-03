package br.com.educacaocriativa.mentor_leitor_facial.service;

import br.com.educacaocriativa.mentor_leitor_facial.model.Pessoa;
import br.com.educacaocriativa.mentor_leitor_facial.model.TipoPessoa;

import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class PessoaService {

    // Este método simula a busca de pessoas (futuramente virá da API do Mentor)
    public List<Pessoa> listarPessoasAtivas() {
        List<Pessoa> pessoas = new ArrayList<>();

        // Aluno
        pessoas.add(new Pessoa(
            "123", // codigoPessoa
            "Lucas Oliveira", // nomePessoa
            "Lucas Oliveira", // nomeCivil
            "hash_foto_123", // fotoPessoa
            TipoPessoa.ALUNO, // tipoPessoa
            "ATIVO", // situacaoPessoa
            "1", // unidade
            true, // ativo
            "2023001", // matricula
            "111.111.111-11" // cpf
        ));

        // Professor/Funcionário
        pessoas.add(new Pessoa(
            "456",
            "Maria Oliveira",
            "Maria Oliveira",
            "hash_foto_456",
            TipoPessoa.PROFESSOR_FUNCIONARIO,
            "ATIVO",
            "1",
            true,
            "2023002",
            "222.222.222-22"
        ));

        // Responsável (usando TODOS)
        pessoas.add(new Pessoa(
            "789",
            "Carlos Souza",
            "Carlos Souza",
            "hash_foto_789",
            TipoPessoa.TODOS,
            "ATIVO",
            "1",
            true,
            "2023003",
            "333.333.333-33"
        ));

        return pessoas;
    }

    // Método para listar por tipo
    public List<Pessoa> listarPorTipo(TipoPessoa tipo) {
        return listarPessoasAtivas().stream()
                .filter(p -> p.getTipoPessoa() == tipo)
                .toList();
    }

    // Método para listar por situação
    public List<Pessoa> listarPorSituacao(String situacao) {
        return listarPessoasAtivas().stream()
                .filter(p -> p.getSituacaoPessoa().equals(situacao))
                .toList();
    }

    // Método para listar por unidade
    public List<Pessoa> listarPorUnidade(String unidade) {
        return listarPessoasAtivas().stream()
                .filter(p -> p.getUnidade().equals(unidade))
                .toList();
    }
}