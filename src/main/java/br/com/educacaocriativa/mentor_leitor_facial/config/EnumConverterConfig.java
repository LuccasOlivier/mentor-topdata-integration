package br.com.educacaocriativa.mentor_leitor_facial.config;

import org.springframework.lang.NonNull;
import org.springframework.format.FormatterRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import org.springframework.stereotype.Component;

@Component
public class EnumConverterConfig implements WebMvcConfigurer {

    @Override
    public void addFormatters(@NonNull FormatterRegistry registry) {
        registry.addConverterFactory(new StringToEnumConverterFactory());
    }
}

