# 🏷️ Controle de Estoque de Produtos

![API](https://github.com/user-attachments/assets/b88875c3-e759-4b98-9b37-16308ff39083)


## 📜 Descrição do Projeto

Este projeto é uma aplicação web para gerenciamento de estoque de produtos. O sistema permite que os usuários realizem operações de criação, leitura, atualização e exclusão (CRUD) de produtos e fabricantes, facilitando o controle e o fluxo de itens em estoque.

![diagrama](https://github.com/user-attachments/assets/d4a233d3-955f-4e85-8e2b-cd9fd35e1566)


## ✅ Funcionalidades

- **Gerenciamento de Produtos**: Adicionar, atualizar, visualizar e remover produtos do estoque.
- **Cadastro de Fabricantes**: Gerenciar informações sobre fabricantes dos produtos.
- **Consulta de Estoque**: Visualizar a lista de produtos disponíveis com detalhes como nome, peso, quantidade em estoque e fabricante.
- **Controle de Fluxo**: Acompanhar as operações realizadas no estoque, garantindo a precisão dos dados.

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core**: Framework para desenvolvimento de aplicações web.
- **Entity Framework Core**: ORM para manipulação de dados com bancos de dados relacionais.
- **SQL Server**: Sistema de gerenciamento de banco de dados utilizado para armazenar informações.
- **Swagger**: Ferramenta para documentação e teste da API.

## 📁 Estrutura do Projeto

- **ControleDeEstoque**: Diretório principal do projeto.
  - **Controllers**: Contém os controladores da API que gerenciam as requisições e as operações no banco de dados.
  - **Entities**: Contém as classes que representam as entidades do sistema (e.g., Produto, Fabricante).
  - **Infra**: Contém a configuração do contexto do banco de dados.
  - **Migrations**: Contém as migrações do Entity Framework para manter o esquema do banco de dados atualizado.


