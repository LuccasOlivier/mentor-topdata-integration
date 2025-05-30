package br.com.educacaocriativa.mentor_leitor_facial.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;

import static org.springframework.security.config.Customizer.withDefaults;
import static org.springframework.security.config.http.SessionCreationPolicy.STATELESS;

@Configuration
@EnableWebSecurity
public class SecurityConfig {

    @Bean
    public SecurityFilterChain filterChain(HttpSecurity http) throws Exception {
        http
                .securityMatcher("/**") // Aplica segurança a todos os endpoints
                .authorizeHttpRequests(auth -> auth
                        .anyRequest().permitAll() // Permite acesso total
                )
                .sessionManagement(sess -> sess.sessionCreationPolicy(STATELESS)) // Sem sessão
                .httpBasic(withDefaults()) // Sem autenticação básica
                .csrf(csrf -> csrf.disable()); // Desabilita CSRF (forma correta a partir do Spring Security 6.1)

        return http.build();
    }
}
