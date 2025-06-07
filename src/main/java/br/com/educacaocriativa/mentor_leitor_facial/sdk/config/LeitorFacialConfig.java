package br.com.educacaocriativa.mentor_leitor_facial.sdk.config;

import lombok.Data;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.context.annotation.Configuration;
import org.springframework.validation.annotation.Validated;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Min;

import java.time.Duration;

@Data
@Validated
@Configuration
@ConfigurationProperties(prefix = "leitorfacial.sdk")
public class LeitorFacialConfig {
    /**
     * URL do WebSocket do leitor facial
     */
    @NotBlank
    private String url = "ws://localhost:7792/pub/chat";

    /**
     * Timeout para operações em milissegundos
     */
    @NotNull
    @Min(1000)
    private Duration timeout = Duration.ofSeconds(10);

    /**
     * Timeout para reconexão em milissegundos
     */
    @NotNull
    @Min(1000)
    private Duration reconnectTimeout = Duration.ofSeconds(5);

    /**
     * Número máximo de tentativas de reconexão
     */
    @NotNull
    @Min(1)
    private int maxReconnectAttempts = 3;

    /**
     * Tamanho máximo da fila de comandos pendentes
     */
    @NotNull
    @Min(1)
    private int maxQueueSize = 100;

    /**
     * Tamanho máximo da cache em minutos
     */
    @NotNull
    @Min(1)
    private Duration cacheTimeout = Duration.ofMinutes(15);

    /**
     * Número máximo de tentativas de envio de comando
     */
    @NotNull
    @Min(1)
    private int maxCommandRetries = 3;

    /**
     * Intervalo entre tentativas de envio de comando em milissegundos
     */
    @NotNull
    @Min(100)
    private Duration retryInterval = Duration.ofSeconds(1);

    /**
     * Tamanho máximo da imagem em bytes
     */
    @NotNull
    @Min(1024)
    private int maxImageSizeBytes = 524288; // 500KB

    /**
     * Dimensões máximas da imagem em pixels
     */
    @NotNull
    @Min(1)
    private int maxImageWidth = 1280;

    @NotNull
    @Min(1)
    private int maxImageHeight = 720;

    /**
     * Formatos de imagem suportados
     */
    private String[] supportedImageFormats = {"jpg", "jpeg", "png"};

    /**
     * Nível de log padrão
     */
    private String logLevel = "INFO";
}
