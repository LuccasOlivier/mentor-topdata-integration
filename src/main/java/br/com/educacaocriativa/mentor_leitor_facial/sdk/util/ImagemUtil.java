package br.com.educacaocriativa.mentor_leitor_facial.sdk.util;

import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

public class ImagemUtil {
    
    private static final int TAMANHO_MAXIMO_KB = 500; // 500KB
    private static final int LARGURA_MAXIMA = 1280;
    private static final int ALTURA_MAXIMA = 720;
    private static final String FORMATO_IMAGEM = "jpg";
    
    public static boolean validarImagem(byte[] imagem) throws IOException {
        if (imagem == null || imagem.length == 0) {
            throw new IOException("Imagem não pode ser nula ou vazia");
        }
        
        if (imagem.length > TAMANHO_MAXIMO_KB * 1024) {
            throw new IOException("Imagem muito grande. Tamanho máximo permitido: " + TAMANHO_MAXIMO_KB + "KB");
        }
        
        try {
            BufferedImage img = ImageIO.read(new ByteArrayInputStream(imagem));
            if (img == null) {
                throw new IOException("Formato de imagem inválido");
            }
            
            if (img.getWidth() > LARGURA_MAXIMA || img.getHeight() > ALTURA_MAXIMA) {
                throw new IOException("Imagem muito grande. Dimensões máximas: " + LARGURA_MAXIMA + "x" + ALTURA_MAXIMA);
            }
            
            return true;
        } catch (IOException e) {
            throw new IOException("Erro ao processar imagem: " + e.getMessage(), e);
        }
    }
    
    public static byte[] processarImagem(byte[] imagem) throws IOException {
        validarImagem(imagem);
        
        try (ByteArrayInputStream bis = new ByteArrayInputStream(imagem);
             ByteArrayOutputStream baos = new ByteArrayOutputStream()) {
            
            BufferedImage img = ImageIO.read(bis);
            ImageIO.write(img, FORMATO_IMAGEM, baos);
            return baos.toByteArray();
        }
    }
    
    public static String converterParaBase64(byte[] imagem) throws IOException {
        return java.util.Base64.getEncoder().encodeToString(processarImagem(imagem));
    }
    
    public static byte[] converterDeBase64(String base64) throws IOException {
        byte[] bytes = java.util.Base64.getDecoder().decode(base64);
        return processarImagem(bytes);
    }
}
