# Pequeno Cadastro de Produtos

API desenvolvida como teste técnico para vaga de Back-end .NET Júnior.

O objetivo do projeto é permitir o cadastro, listagem, busca, atualização e remoção de produtos, utilizando uma estrutura simples em camadas.

## Versão

- Versão do projeto: 1.0.0
- .NET SDK: 10.0
- Framework: ASP.NET Core Web API

## Tecnologias utilizadas

- C#
- ASP.NET Core Web API
- Swagger
- Armazenamento em memória

## Estrutura do projeto

O projeto foi organizado em camadas simples para separar melhor as responsabilidades:

- **Controllers**: recebem as requisições HTTP e retornam as respostas da API.
- **Services**: concentram as validações e regras da aplicação.
- **Repositories**: manipulam os dados armazenados em memória.
- **DTOs**: representam os dados recebidos nas requisições.
- **Entities**: representam as entidades principais do projeto.

Fluxo principal da aplicação:

```text
Controller → Service → Repository
```

## Como executar o projeto

Acesse a pasta do projeto da API:

```bash
cd TesteVagaBackEnd.Api
```

Restaure as dependências:

```bash
dotnet restore
```

Execute o projeto:

```bash
dotnet run
```

Depois, acesse o Swagger pelo navegador.

Exemplo:

```text
https://localhost:7059/swagger
```

ou:

```text
http://localhost:5237/swagger
```

A porta pode variar de acordo com a configuração local.

## Endpoints disponíveis

### Criar produto

```http
POST /api/produto
```

Exemplo de corpo da requisição:

```json
{
  "nome": "Teclado",
  "preco": 150.00,
  "quantidade": 10,
  "categoriaId": 1
}
```

### Listar todos os produtos

```http
GET /api/produto
```

### Buscar produto por ID

```http
GET /api/produto/{id}
```

### Atualizar produto

```http
PUT /api/produto/{id}
```

Exemplo de corpo da requisição:

```json
{
  "nome": "Teclado Mecânico",
  "preco": 250.00,
  "quantidade": 5,
  "categoriaId": 1
}
```

### Remover produto

```http
DELETE /api/produto/{id}
```

## Validações implementadas

A API possui validações básicas para criação e atualização de produtos:

- O nome do produto não pode ser vazio.
- O preço deve ser maior que zero.
- A quantidade deve ser maior que zero.
- O ID informado deve ser válido.
- Caso o produto não seja encontrado, a API retorna uma resposta adequada.

## Armazenamento dos dados

Os dados são armazenados em memória utilizando uma lista dentro do repositório.

Por isso, ao encerrar a aplicação, os produtos cadastrados são perdidos.