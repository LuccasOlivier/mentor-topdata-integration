# Integração Mentor + Leitor Facial Topdata T4

## Descrição

Projeto backend responsável por integrar o sistema **Mentor** com o leitor facial **Topdata T4**. O sistema consulta periodicamente a API do Mentor para obter dados atualizados de alunos, professores e colaboradores ativos, e envia essas informações ao leitor facial, que controla o acesso físico à instituição.

## Funcionalidades

- Consumo da API do Mentor para buscar pessoas ativas.
- Autenticação via JWT na API do Mentor.
- Envio dos dados (nome, código e foto) para o leitor facial Topdata T4.
- Atualização do banco de dados interno do leitor.
- Controle e logs dos acessos.

## Tecnologias

- Java 17+
- Spring Boot
- Maven
- REST API
- JWT (Autenticação)
- SDK Topdata (Integração com leitor facial)

## Pré-requisitos

- Java 17 ou superior
- Maven
- IDE (IntelliJ, VSCode, Eclipse)
- Postman (ou similar)
- Git

## Segurança

O acesso à API do Mentor é protegido via autenticação JWT. O token deve ser gerado previamente para realizar as consultas.
