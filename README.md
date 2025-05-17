# 🏍️ SmartMotoZone.API

API RESTful para mapeamento inteligente de motos em pátios de filiais da Mottu.  
Utiliza o conceito de **zonas virtuais** (sem necessidade de hardware físico) para localizar motos de forma eficiente e organizada.

---

## 🚀 Funcionalidades

- CRUD completo de motos (placa, modelo, status, zona atual)
- Integração com banco de dados Oracle via EF Core
- Documentação interativa com Swagger UI
- Totalmente compatível com `.NET 8.0`

---

## ⚙️ Tecnologias Utilizadas

- ASP.NET Core 8.0
- Entity Framework Core + Migrations
- Oracle Database
- Swashbuckle (Swagger)
- Visual Studio 2022+

---

## 🧩 Como Rodar o Projeto

### ✅ Requisitos

- .NET 8.0 SDK
- Oracle Database local ou em nuvem
- Visual Studio 2022 ou superior

### 🛠️ Passos para execução

1. Clone o repositório:

   ```bash
   git clone https://github.com/SmartMotoZone-API/SmartMotoZone.API.git
   ```

2. Abra o projeto no Visual Studio 2022.

3. Instale os seguintes pacotes NuGet:

   * `Oracle.EntityFrameworkCore`
   * `Microsoft.EntityFrameworkCore.Tools`
   * `Swashbuckle.AspNetCore`

4. Configure a string de conexão no arquivo `appsettings.Development.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=SEU_HOST)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=SEU_SERVICO)));"
   }
   ```

   > 📝 Substitua:
   >
   > * `SEU_USUARIO` pelo usuário do Oracle
   > * `SUA_SENHA` pela senha correspondente
   > * `SEU_HOST` pelo endereço/IP do servidor Oracle
   > * `1521` pela porta (padrão do Oracle, se não mudou)
   > * `SEU_SERVICO` pelo nome do serviço (ou SID) da instância Oracle

5. Restaure os pacotes:

   ```bash
   dotnet restore
   ```

6. Execute as migrations:

   ```bash
   dotnet ef database update
   ```

7. Rode o projeto:

   ```bash
   dotnet run
   ```

A API estará disponível em: `https://localhost:5001`  
A documentação Swagger estará em: `https://localhost:5001/swagger`

---

## 📚 Modelo da Entidade: Moto

```json
{
  "id": 1,
  "placa": "ABC1234",
  "modelo": "Honda CG 160",
  "status": "Disponível",
  "zonaAtual": "B2",
  "ultimaAtualizacao": "2025-05-13T14:30:00"
}
```

---

## 📡 Rotas Disponíveis

### 🔍 GET

* `GET /api/motos`
  → Retorna todas as motos

* `GET /api/motos/{id}`
  → Retorna detalhes de uma moto específica

* `GET /api/motos/porzona?zona=B2`
  → Lista motos que estão na zona B2

* `GET /api/motos/status?status=Disponível`
  → Lista motos com o status "Disponível"

### ➕ POST

* `POST /api/motos`
  → Cria uma nova moto  
  **Body JSON:** Ver exemplo acima

### ✏️ PUT

* `PUT /api/motos/{id}`
  → Atualiza os dados de uma moto

### ❌ DELETE

* `DELETE /api/motos/{id}`
  → Remove uma moto do sistema

---

## 🛡️ Respostas HTTP

| Código            | Descrição                   |
| ----------------- | --------------------------- |
| `200 OK`          | Requisição bem-sucedida     |
| `201 Created`     | Recurso criado com sucesso  |
| `204 No Content`  | Recurso removido            |
| `400 Bad Request` | Dados inválidos ou ausentes |
| `404 Not Found`   | Moto não encontrada         |

---

## 📘 Observações

- O Swagger fornece uma interface gráfica para testes. Basta acessar `/swagger` com o projeto rodando.
- Toda a persistência é feita via Oracle + Entity Framework Core com migrations.
- O atributo `[ApiController]` presente no controller garante que erros de validação nos modelos sejam tratados automaticamente, retornando mensagens de erro em formato JSON com status `400 Bad Request`.

### 🔎 Exemplo de erro 400 Bad Request

Se for enviada uma requisição POST com dados inválidos (ex: campo `status` vazio ou com mais de 20 caracteres), a API retorna erro automático:

**Requisição:**
```json
{
  "placa": "XYZ1234",
  "modelo": "Yamaha",
  "status": "",
  "zonaAtual": "A1"
}
```

**Resposta:**
```json
{
  "errors": {
    "Status": [
      "O status da moto é obrigatório."
    ]
  },
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-...etc..."
}
```

---

## 👨‍💻 Equipe

* Kaio Cumpian  
* Gabriel Yuji Suzuki 
* Lucas Felix Vassiliades

---

> Feito com 💙 para a disciplina de *Advanced Business Development with .NET*
