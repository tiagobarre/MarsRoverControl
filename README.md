Mars Rover Control API
=======================

Este projeto simula o controle de Rovers em Marte, seguindo comandos enviados via API REST.
Desenvolvido em .NET 8 com testes, padrão CQRS, e documentação via Swagger.

----------------------------------
REQUISITOS
----------------------------------

- .NET 8 SDK
- Visual Studio 2022+ ou VS Code com extensão C#
- Git (opcional)

----------------------------------
COMO RODAR O PROJETO
----------------------------------

1. Clone o repositório:
   git clone https://github.com/tiagobarre/MarsRoverControl.git
   cd MarsRoverControl.API

2. Restaure os pacotes:
   dotnet restore

3. Rode a aplicação:
   dotnet run --project MarsRoverControl.API

4. Acesse o Swagger:
   https://localhost:5001/swagger

----------------------------------
ESTRUTURA DO PROJETO
----------------------------------

MarsRoverControl.API/
│
├── Controllers/
│   └── RoversController.cs       -> Controlador da API
│
├── Models/
│   ├── RoversModels.cs          -> Lógica principal de movimentação
│   ├── Plateau.cs               -> Grade de coordenadas de Marte
│   ├── Position.cs              -> Posição (X, Y)
│   ├── Rover.cs                 -> Representação do Rover
│   ├── Direction.cs             -> Enum (N, S, E, W)
│   └── Commands/
│       ├── ICommand.cs
│       ├── MoveCommand.cs
│       ├── LeftCommand.cs
│       ├── RightCommand.cs
│       └── CommandParser.cs
│
├── Requests/
│   └── RoverCommandRequest.cs   -> DTO do request da API
│
├── Tests/
│   └── RoverTests.cs            -> Testes unitários
│
└── Program.cs

----------------------------------
COMO TESTAR
----------------------------------

Execute os testes com o comando:

   dotnet test

Testes cobrem:
- Direções inválidas
- Posições inválidas ou ocupadas
- Execução de sequência de comandos

----------------------------------
EXEMPLO DE USO NO SWAGGER
----------------------------------

Request:
{
  "startX": 1,
  "startY": 2,
  "direction": "E",
  "commands": "MMRMMRMRRM"
}

Resposta esperada:
"3 3 S"

----------------------------------
USANDO O DEBUGGER
----------------------------------

No Visual Studio:

1. Coloque breakpoint no método ExecuteRovers() (em RoversModels.cs)
2. Pressione F5 para rodar em modo debug
3. Envie uma requisição pelo Swagger
4. O Visual Studio vai pausar no ponto desejado

No VS Code:

1. Instale a extensão "C#"
2. Coloque breakpoints no código
3. Pressione F5
4. Use o Swagger para testar

----------------------------------
FUTURAS MELHORIAS
----------------------------------

- Salvar estado dos Rovers
- Múltiplos Rovers simultâneos
- Autenticação via JWT
- Suporte a arquivos de entrada e logs

----------------------------------
AUTOR
----------------------------------

Desenvolvido por Tiago Barreto
Desenvolvedor .NET
Auxílio de IA em alguns passos (ChatGPT)
