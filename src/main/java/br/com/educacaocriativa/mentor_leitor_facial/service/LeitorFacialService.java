package br.com.educacaocriativa.mentor_leitor_facial.service;

import br.com.educacaocriativa.mentor_leitor_facial.model.Pessoa;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

/**
 * Este serviço simula um leitor facial.
 * No futuro, será substituído pelo SDK do Topdata.
 */
@Service
public class LeitorFacialService {

    // Simula uma lista de pessoas cadastradas no leitor facial
    private List<Pessoa> pessoasCadastradas = new ArrayList<>();

    // Método para listar pessoas no leitor
    public List<Pessoa> listarPessoasNoLeitor() {
        return pessoasCadastradas;
    }

    // Método para sincronizar pessoas (Adicionar várias de uma vez)
    public String sincronizarPessoasComLeitor(List<Pessoa> pessoas) {
        pessoasCadastradas.addAll(pessoas);
        return "Sincronização concluída com sucesso!";
    }

    // Método para remover uma pessoa do leitor (beseado no ID)
    public String removerPessoaDoLeitor(String id) {
        boolean removido = pessoasCadastradas.removeIf(p -> p.getId().equals(id));
        return removido ? "Pessoa removida com sucesso!" : "Pessoa não encontrada!";
    }
}
