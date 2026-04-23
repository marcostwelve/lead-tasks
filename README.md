<h1 align="center">Lead Tasks APP</h1>

 ### Página Principal
<img width="1383" height="915" alt="Captura de tela 2026-04-23 010119" src="https://github.com/user-attachments/assets/923ff322-a7ba-4579-a503-a2122cac422f" />

 ## Lead Task App. Um App para gerenciar as tarefas de um lead

 ### Página de Tasks
 <img width="1385" height="885" alt="Captura de tela 2026-04-23 010138" src="https://github.com/user-attachments/assets/1f77ec20-9373-4da4-bc29-8a381c830b34" />

 
## 🔥 Introdução

APP foi criação com .net versão 8 e Angular versão 16

### ⚙️ Pré-requisitos
* .Net Core versão 8.0 [.Net Core 8.0 Download](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
* Entity Framework Core versão 8.0 [Documentação](https://learn.microsoft.com/pt-br/ef/)
* Visual studio 2022, ou IDE que tenha suporte ao .Net 8.0 [Visual Studio 2022 Download](https://visualstudio.microsoft.com/pt-br/downloads/)
* Sql Server versão 2022 [Sql Server Download](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
* Sql Server Management Studio (SSMS) [SSMS Download](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
* Angular v1 [Documentação] ([Learn React](https://v16.angular.io/docs))
* Swagger [Documentação] ([Swagger](https://swagger.io/))


### 🔨 Guia de instalação

Para utilizar este projeto, necessário instalar o Entity Framework, e configurar o banco de dados no arquivo appsettings.Development.json (versão para desenvolvimento), e instalar as migrations para conexão com o banco de dados

Etapas para instalar:

```bash
dotnet tool install --global dotnet-ef
```
Passo 2:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
Passo 3:
```bash
Install-Package Microsoft.EntityFrameworkCore.Design
```
Passo 4:
```bash
dotnet-ef migrations add (Nome da migration do projeto)
```

Passo 5:
```bash
dotnet-ef database update
```

# Executando a Aplicação 🌐

Para executar a aplicação App, digite o seguinte comando

```bash
ng serve
```
Acessar o link http://localhost:4200 (Caso o navegador não abra automaticamente)

Para executar a aplicação back-end, digite o seguinte comando

```bash
dotnet run
```

O back-end irá abrir uma página automática do Swagger com o end-point
<img width="1897" height="848" alt="image" src="https://github.com/user-attachments/assets/4c32593a-acb2-4151-ace3-c4fe49d2e256" />

Se preferir, pode executar o end-point diretamente no navegador, ou em softwares para testar a API -> https://localhost:5000
