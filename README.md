Este projeto é uma API RESTful. Ele inclui funcionalidades de gerenciamento de carrinhos de compras, produtos e usuários, além de outras operações essenciais.

🚀 Tecnologias Utilizadas
.NET 8 - Framework principal para a aplicação.
ASP.NET Core Web API - Para a construção da API.
Entity Framework Core (com Npgsql) - ORM para comunicação com PostgreSQL.
Docker & Docker Compose - Para facilitar a implantação e execução dos serviços.
xUnit - Para testes unitários e de integração.
Moq - Para criação de mocks em testes.
FluentAssertions - Para asserções mais intuitivas em testes.
AutoMapper - Para mapeamento de objetos DTOs e entidades.
PostgreSQL - Banco de dados relacional utilizado.

📋 Pré-requisitos
Antes de rodar o projeto, certifique-se de ter instalado:
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Visual Studio / Visual Studio Code](https://code.visualstudio.com/)
- 
💻 Como Rodar o Projeto
1️⃣ Executando via Docker Compose (Recomendado)
O Docker facilita a execução do projeto sem precisar instalar dependências adicionais.

Crie a rede compartilhada (caso ainda não exista):
```
docker network create shared-net
```

Suba os containers da aplicação e banco de dados:
```
docker compose up -d --remove-orphans

```
Isso iniciará:
A API no container configurado.
O PostgreSQL em outro container.
Atenção: A string de conexão da API utiliza o hostname do container do banco (por exemplo, postgres), não localhost.

2️⃣ Executando Localmente (Sem Docker)
Caso prefira rodar o projeto sem Docker, siga os passos abaixo:

Configure a string de conexão
Edite o arquivo appsettings.Development.json, ajustando a conexão com o PostgreSQL local.

Rode as migrations para criar/atualizar o banco de dados:

```
dotnet ef database update --startup-project ./Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj --project ./Ambev.DeveloperEvaluation.ORM/Ambev.DeveloperEvaluation.ORM.csproj
```
Inicie a API:

```
dotnet run --project ./Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj
```
🔹 A API ficará disponível em http://localhost:5000 (ou na porta configurada).

🛠 Como Testar o Projeto
Testes automatizados garantem a qualidade do código. Você pode executá-los de duas maneiras:

📌 Via Linha de Comando
Abra o terminal na raiz do repositório e execute:
```
dotnet test
```
Esse comando compilará e executará todos os testes unitários e de integração.
📌 Pelo Visual Studio
Abra o Test Explorer (menu Test → Test Explorer).
Selecione os testes desejados e clique com o botão direito para Run Selected Tests ou Debug Selected Tests.
📂 Estrutura do Projeto
📁 Ambev.DeveloperEvaluation.WebApi → Contém a API e seus endpoints.
📁 Ambev.DeveloperEvaluation.Application → Regras de negócio e validações.
📁 Ambev.DeveloperEvaluation.ORM → Contém as entidades, repositórios, DbContext e migrations.
📁 Tests → Contém testes unitários e de integração.
📄 docker-compose.yml → Arquivo para execução dos containers.

📌 Boas Práticas Adotadas
✅ Gitflow → Utilização de branches (feature, develop, main) e criação de PRs para revisão.
✅ Commits Semânticos → Mensagens padronizadas para facilitar o histórico (feat, fix, refactor, etc.).
✅ Testes Automatizados → Cobertura de testes para garantir qualidade e evitar regressões.
✅ Código Limpo → Arquitetura organizada, separação de responsabilidades e boas práticas de DDD.

📌 Considerações Finais
🔹 Variáveis de ambiente: Verifique se as configurações de conexão com o banco e outras variáveis estão corretamente definidas.
🔹 Docker: Certifique-se de que os containers da API e do PostgreSQL estão na mesma rede (shared-net).
🔹 Contribuições: Sinta-se à vontade para abrir issues ou enviar pull requests com melhorias!

📌 Agora o projeto está pronto para rodar e ser testado! 🚀

