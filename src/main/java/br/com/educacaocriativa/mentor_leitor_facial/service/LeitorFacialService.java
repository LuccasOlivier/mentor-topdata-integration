package br.com.educacaocriativa.mentor_leitor_facial.service;

import br.com.educacaocriativa.mentor_leitor_facial.model.Pessoa;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

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
        return "Sincronização concluída com sucesso! Total de pessoas: " + pessoasCadastradas.size();
    }

    // Método para remover uma pessoa do leitor (baseado no código da pessoa)
    public String removerPessoaDoLeitor(String codigoPessoa) {
        boolean removido = pessoasCadastradas.removeIf(p -> p.getCodigoPessoa().equals(codigoPessoa));
        return removido ? "Pessoa removida com sucesso!" : "Pessoa não encontrada!";
    }

    // Método para buscar pessoa pelo código
    public Optional<Pessoa> buscarPessoaPorCodigo(String codigoPessoa) {
        return pessoasCadastradas.stream()
                .filter(p -> p.getCodigoPessoa().equals(codigoPessoa))
                .findFirst();
    }

    // Método para verificar se uma pessoa está cadastrada
    public boolean estaCadastrada(String codigoPessoa) {
        return pessoasCadastradas.stream()
                .anyMatch(p -> p.getCodigoPessoa().equals(codigoPessoa));
    }

    // Método para atualizar dados de uma pessoa
    public String atualizarPessoa(Pessoa pessoa) {
        Optional<Pessoa> pessoaExistente = buscarPessoaPorCodigo(pessoa.getCodigoPessoa());
        if (pessoaExistente.isPresent()) {
            pessoasCadastradas.remove(pessoaExistente.get());
            pessoasCadastradas.add(pessoa);
            return "Pessoa atualizada com sucesso!";
        }
        return "Pessoa não encontrada!";
    }

    // Método para verificar se o leitor está conectado (simulação)
    public boolean isConectado() {
        // Simula uma conexão com o leitor
        return true;
    }

    // Método para simular o reconhecimento facial
    public String reconhecerPessoa(String codigoPessoa) {
        if (estaCadastrada(codigoPessoa)) {
            return "Pessoa reconhecida: " + buscarPessoaPorCodigo(codigoPessoa).get().getNomePessoa();
        }
        return "Pessoa não reconhecida!";
    }
}