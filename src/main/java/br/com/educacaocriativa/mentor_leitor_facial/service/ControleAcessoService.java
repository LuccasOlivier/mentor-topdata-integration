package br.com.educacaocriativa.mentor_leitor_facial.service;

import br.com.educacaocriativa.mentor_leitor_facial.dto.RegistroAcessoDTO;
import br.com.educacaocriativa.mentor_leitor_facial.model.Pessoa;
import br.com.educacaocriativa.mentor_leitor_facial.service.LeitorFacialService;
import br.com.educacaocriativa.mentor_leitor_facial.service.PessoaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.List;

@Service
public class ControleAcessoService {

    @Autowired
    private PessoaService pessoaService;

    @Autowired
    private LeitorFacialService leitorFacialService;

    public boolean validarAcesso(String codigoPessoa) {
        if (!leitorFacialService.estaCadastrada(codigoPessoa)) {
            return false;
        }

        List<Pessoa> pessoas = pessoaService.listarPessoasAtivas();
        Pessoa pessoa = pessoas.stream()
                .filter(p -> p.getCodigoPessoa().equals(codigoPessoa))
                .findFirst()
                .orElse(null);

        if (pessoa == null || !pessoa.isAtivo()) {
            return false;
        }

        return validarPessoaPorTipo(pessoa);
    }

    private boolean validarPessoaPorTipo(Pessoa pessoa) {
        if (pessoa == null) return false;

        switch (pessoa.getTipoPessoa()) {
            case ALUNO:
                return validarAluno(pessoa);
            case ALUNO_RESPONSAVEL:
                return validarResponsavel(pessoa);
            case PROFESSOR_FUNCIONARIO:
                return validarProfessor(pessoa);
            default:
                return true;
        }
    }

    private boolean validarAluno(Pessoa aluno) {
        return true;
    }

    private boolean validarResponsavel(Pessoa responsavel) {
        return true;
    }

    private boolean validarProfessor(Pessoa professor) {
        return true;
    }

    public boolean registrarAcesso(RegistroAcessoDTO dto) {
        try {
            if (!validarAcesso(dto.getCodigoIdentificacaoPessoa())) {
                return false;
            }

            leitorFacialService.reconhecerPessoa(dto.getCodigoIdentificacaoPessoa());
            return true;
        } catch (Exception e) {
            System.err.println("Erro ao registrar acesso: " + e.getMessage());
            return false;
        }
    }
}