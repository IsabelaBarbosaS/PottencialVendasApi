# 🧾 Tech Test - PottencialVendasApi

API RESTful desenvolvida em .NET 8 para gerenciamento de vendas, incluindo cadastro de vendedores, controle de itens e atualização de status de pedidos. Criada como parte de um desafio técnico, a aplicação prioriza boas práticas de arquitetura, testes automatizados e escalabilidade.

---

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/download)
- ASP.NET Core Web API
- xUnit (testes unitários)
- Injeção de Dependência nativa
- Repository Pattern (com repositório em memória)
- DTOs (Data Transfer Objects)
- Enum para controle de status
- Clean Architecture (Domain, Application, Infrastructure)

---

## 📁 Estrutura de Pastas

```
tech-test-payment-api/
├── Application/        # Camada de aplicação (DTOs, Services)
├── Controller/         # Endpoints HTTP
├── Domain/             # Entidades, enums e interfaces
├── Infrastructure/     # Repositórios (in-memory)
├── Helpers/            # Classes auxiliares (validações e mensagens)
├── Tests/              # Testes unitários com xUnit
├── Program.cs          # Entry point da aplicação
├── PottencialVendasApi.csproj
└── README.md
```

---

## 🔧 Como Executar o Projeto

### Pré-requisitos

- .NET SDK 8.0 ou superior

### Executar a aplicação

```bash
dotnet run
```

A aplicação estará disponível em `http://localhost:5000` (ou porta configurada no `launchSettings.json`).

### Executar testes

```bash
dotnet test
```

---

## 🛠 Funcionalidades

- ✅ Cadastro de uma nova venda
- ✅ Consulta de venda por ID
- ✅ Listagem de todas as vendas
- ✅ Atualização de status da venda (validações de transição)
- ✅ Mensagens de erro padronizadas
- ✅ Testes unitários cobrindo regras de negócio

---

## 📄 Exemplo de Requisição (POST /vendas)

```json
{
  "vendedor": {
    "cpf": "12345678900",
    "nome": "João da Silva"
  },
  "itens": [
    {
      "nome": "Produto A",
      "quantidade": 2,
      "valor": 100.0
    }
  ]
}
```

