package br.com.educacaocriativa.mentor_leitor_facial.aspect;

import br.com.educacaocriativa.mentor_leitor_facial.service.LogAcessoService;
import jakarta.servlet.http.HttpServletRequest;
import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.annotation.After;
import org.aspectj.lang.annotation.Aspect;
import org.aspectj.lang.annotation.Before;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.Arrays;

@Aspect
@Component
public class LogAcessoAspect {

    @Autowired
    private LogAcessoService logAcessoService;

    @Autowired
    private HttpServletRequest request;

    @Before("execution(* br.com.educacaocriativa.mentor_leitor_facial.service.*.*(..))")
    public void logBefore(JoinPoint joinPoint) {
        String metodo = joinPoint.getSignature().getName();
        String classe = joinPoint.getSignature().getDeclaringTypeName();
        Object[] args = joinPoint.getArgs();

        logAcessoService.registrarAcesso(
            "INICIO",
            "",
            String.format("Método %s.%s iniciado", classe, metodo),
            "INFO",
            "",
            request.getRemoteAddr(),
            request.getRemoteUser(),
            Arrays.toString(args)
        );
    }

    @After("execution(* br.com.educacaocriativa.mentor_leitor_facial.service.*.*(..))")
    public void logAfter(JoinPoint joinPoint) {
        String metodo = joinPoint.getSignature().getName();
        String classe = joinPoint.getSignature().getDeclaringTypeName();

        logAcessoService.registrarAcesso(
            "FIM",
            "",
            String.format("Método %s.%s finalizado", classe, metodo),
            "INFO",
            "",
            request.getRemoteAddr(),
            request.getRemoteUser(),
            ""
        );
    }
}
