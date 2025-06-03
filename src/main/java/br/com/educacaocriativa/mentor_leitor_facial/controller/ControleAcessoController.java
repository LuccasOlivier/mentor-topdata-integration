package br.com.educacaocriativa.mentor_leitor_facial.controller;

import br.com.educacaocriativa.mentor_leitor_facial.dto.RegistroAcessoDTO;
import br.com.educacaocriativa.mentor_leitor_facial.service.ControleAcessoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/controleacesso")
public class ControleAcessoController {

    @Autowired
    private ControleAcessoService controleAcessoService;

    /**
     * Endpoint para validar acesso
     * @param codigoPessoa Código da pessoa que deseja acessar
     * @return ResponseEntity com resultado da validação
     */
    @GetMapping("/validar/{codigoPessoa}")
    public ResponseEntity<Boolean> validarAcesso(@PathVariable String codigoPessoa) {
        boolean podeAcessar = controleAcessoService.validarAcesso(codigoPessoa);
        return ResponseEntity.ok(podeAcessar);
    }

    /**
     * Endpoint para registrar acesso
     * @param dto Dados do acesso
     * @return ResponseEntity com resultado do registro
     */
    @PostMapping("/registrar")
    public ResponseEntity<Boolean> registrarAcesso(@RequestBody RegistroAcessoDTO dto) {
        boolean registrado = controleAcessoService.registrarAcesso(dto);
        return ResponseEntity.ok(registrado);
    }
}