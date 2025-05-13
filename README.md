## Descrição do Projeto

O **SmartMotoZone.API** é uma API RESTful desenvolvida para o mapeamento inteligente de motos em pátios de filiais. A solução foi criada para facilitar a gestão de frotas, localizando as motos de forma precisa e eficiente em tempo real. Utilizando a tecnologia de zonas virtuais (beacons), o sistema oferece visibilidade e controle sobre a disposição das motos nos pátios, permitindo uma gestão mais ágil e escalável.

Esta API oferece funcionalidades de CRUD (Create, Read, Update, Delete) para gerenciamento de motos, com integração ao banco de dados Oracle via Entity Framework Core. A documentação da API é disponibilizada através do Swagger, proporcionando uma interface gráfica para interação com os endpoints.

## Como Rodar o Projeto

### Requisitos:
- **.NET 8.0** ou superior
- **Oracle Database** (configuração do banco de dados no `appsettings.Development.json`)
- **Visual Studio 2022+**

### Passos:
1. Clone o repositório:
    bash
    git clone https://github.com/SmartMotoZone-API/SmartMotoZone.API.git

    
2. Abra o projeto no Visual Studio.
3. Instale os pacotes NuGet necessários para Entity Framework Core e Oracle:
    - **Oracle.EntityFrameworkCore**
    - **Microsoft.EntityFrameworkCore.Tools**
    - **Swashbuckle.AspNetCore** (para Swagger)
4. Configure a string de conexão com o banco de dados Oracle no arquivo `appsettings.Development.json`:
    json
    "ConnectionStrings": {
      "DefaultConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=seu_servidor;"
    }
    
5. Restaure os pacotes NuGet:
    bash
    dotnet restore
    
6. Execute as migrations para criar as tabelas no banco de dados:
    bash
    dotnet ef database update
    
7. Execute o projeto:
    bash
    dotnet run
    

Agora, a API estará disponível no endereço: `https://localhost:5001` (por padrão).

---

## Rotas Disponíveis

### Moto

- **GET /api/motos**
  - Retorna todas as motos cadastradas.
  - **Resposta:** `200 OK` com a lista de motos.
  
- **GET /api/motos/{id}**
  - Retorna os detalhes de uma moto específica.
  - **Parâmetros de URL:** `id` (ID da moto)
  - **Resposta:** `200 OK` com os detalhes da moto ou `404 Not Found` se não encontrada.

- **POST /api/motos**
  - Cria uma nova moto.
  - **Corpo da requisição:** Dados da moto (exemplo: `placa`, `modelo`, `zonaAtual`).
  - **Resposta:** `201 Created` com os dados da moto criada.

- **PUT /api/motos/{id}**
  - Atualiza os dados de uma moto existente.
  - **Parâmetros de URL:** `id` (ID da moto)
  - **Corpo da requisição:** Dados atualizados da moto.
  - **Resposta:** `200 OK` com os dados atualizados ou `404 Not Found` se não encontrada.

- **DELETE /api/motos/{id}**
  - Deleta uma moto.
  - **Parâmetros de URL:** `id` (ID da moto)
  - **Resposta:** `204 No Content` se deletado com sucesso ou `404 Not Found` se não encontrada.

---

## Tecnologias Usadas

- **ASP.NET Core 8.0** - Framework para API RESTful
- **Entity Framework Core** - ORM para interação com o banco de dados
- **Oracle Database** - Banco de dados para armazenamento de informações
- **Swagger (Swashbuckle)** - Documentação da API
- **Visual Studio 2022+** - IDE para desenvolvimento

---

## Observações Importantes

- Certifique-se de configurar corretamente sua string de conexão no arquivo `appsettings.Development.json` antes de executar o projeto.
- O Swagger pode ser acessado no endereço `/swagger` após o projeto ser executado. Ele oferece uma interface gráfica para testar os endpoints da API.

---

Feito com 💙 por [Kaio Cumpian, Gabriel]

`

---
