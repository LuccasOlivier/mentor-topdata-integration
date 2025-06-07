package br.com.educacaocriativa.mentor_leitor_facial.service;

import br.com.educacaocriativa.mentor_leitor_facial.model.LogAcesso;
import br.com.educacaocriativa.mentor_leitor_facial.repository.LogAcessoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.time.LocalDateTime;
import java.util.List;

@Service
@Transactional
public class LogAcessoService {

    @Autowired
    private LogAcessoRepository logAcessoRepository;

    public void registrarAcesso(String tipoOperacao, String codigoPessoa, String mensagem, 
                               String nivelLog, String status, String ipCliente, 
                               String usuarioSistema, String detalhes) {
        LogAcesso log = new LogAcesso();
        log.setTipoOperacao(tipoOperacao);
        log.setCodigoPessoa(codigoPessoa);
        log.setMensagem(mensagem);
        log.setNivelLog(nivelLog);
        log.setStatus(status);
        log.setIpCliente(ipCliente);
        log.setUsuarioSistema(usuarioSistema);
        log.setDetalhes(detalhes);
        
        logAcessoRepository.save(log);
    }

    public List<LogAcesso> listarLogsPorPeriodo(LocalDateTime inicio, LocalDateTime fim) {
        return logAcessoRepository.findByDataHoraBetween(inicio, fim);
    }

    public List<LogAcesso> listarLogsPorTipo(String tipoOperacao) {
        return logAcessoRepository.findByTipoOperacao(tipoOperacao);
    }

    public List<LogAcesso> listarLogsPorPessoa(String codigoPessoa) {
        return logAcessoRepository.findByCodigoPessoa(codigoPessoa);
    }
}
