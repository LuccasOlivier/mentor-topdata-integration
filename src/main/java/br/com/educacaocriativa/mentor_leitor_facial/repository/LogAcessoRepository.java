package br.com.educacaocriativa.mentor_leitor_facial.repository;

import br.com.educacaocriativa.mentor_leitor_facial.model.LogAcesso;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.time.LocalDateTime;
import java.util.List;

@Repository
public interface LogAcessoRepository extends JpaRepository<LogAcesso, Long> {

    List<LogAcesso> findByDataHoraBetween(LocalDateTime inicio, LocalDateTime fim);
    List<LogAcesso> findByTipoOperacao(String tipoOperacao);
    List<LogAcesso> findByCodigoPessoa(String codigoPessoa);
    
    @Query("SELECT l FROM LogAcesso l WHERE l.nivelLog = :nivel")
    List<LogAcesso> findByNivelLog(String nivel);
    
    @Query("SELECT l FROM LogAcesso l WHERE l.status = :status")
    List<LogAcesso> findByStatus(String status);
}
