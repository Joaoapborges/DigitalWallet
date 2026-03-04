# Digital Wallet (Sistema Bancário)

Este projeto é uma aplicação financeira completa que simula as operações de um sistema bancário moderno. Desenvolvido inicialmente como um projeto de POO, foi totalmente reestruturado para adotar práticas e tecnologias standard da indústria.

O projeto utiliza uma abordagem de **Monorepo**, contendo tanto a API Web como a aplicação Cliente Desktop.

Atualmente, o projeto encontra-se na fase de integração, com foco na ligação entre o Frontend e a API do Backend.

## 🏗️ Estrutura do Projeto

A solução é composta por dois projetos principais:

### 1. Frontend (`Frontend_WPF`)
Uma aplicação Desktop desenvolvida em **WPF (Windows Presentation Foundation)**.
* **Padrão de Arquitetura:** MVVM (Model-View-ViewModel) para uma clara separação entre a lógica de negócio e a interface de utilizador.
* **Estado:** Interface e lógica do cliente praticamente concluídas.

### 2. Backend (`Backend_API`)
Uma **API RESTful** desenvolvida em C# com ASP.NET Core.
* **Autenticação:** Protegida através de tokens (JWT), garantindo que apenas utilizadores autenticados podem aceder aos endpoints.
* **Base de Dados:** Integração com base de dados estruturada através de Entity Framework Core (inclui sistema de *Migrations*).
* **Estado:** API construída, em fase de testes e conexão com o cliente WPF.

## ✨ Principais Funcionalidades

* **Onboarding Automatizado:** Registo de novos clientes com geração automática de Conta e Cartão Digital associado via *Database Transactions*.
* **Segurança Profissional:** Login seguro com emissão de tokens JWT e proteção de endpoints.
* **Gestão de Cartões:** Visualização de cartões protegida para que cada utilizador apenas aceda aos seus próprios dados.
* **Transações Financeiras:** Sistema de depósitos, pagamentos de serviços e transferências (com aplicação de taxas interbancárias).

## 💻 Tecnologias Utilizadas

* **Linguagem:** C# (.NET)
* **Frontend:** WPF, XAML, padrão MVVM
* **Backend:** ASP.NET Core Web API
* **Segurança:** Autenticação baseada em Tokens (Bearer/JWT)
* **Base de Dados:** PostgreSQL (via Entity Framework Core / Npgsql)

## Como Executar o Projeto


### Pré-requisitos
* [.NET SDK](https://dotnet.microsoft.com/download) instalado.
* **PostgreSQL** 

### Passos para arrancar o Backend
1. Navega até à pasta do backend: `cd BackMultibanco`
2. Atualiza a base de dados: `dotnet ef database update`
3. Inicia a API: `dotnet run`

### Passos para arrancar o Frontend
1. Abre a solução no Visual Studio.
2. Define o projeto `ipgt_oop` como *Startup Project*.
3. Garante que o URL da API no frontend corresponde ao URL onde o backend está a correr (ex: `localhost:5000`).
4. Inicia a aplicação.

## 📈 Próximos Passos (To-Do)
- [ ] Finalizar a integração dos *endpoints* da API com os *ViewModels* do WPF.
- [ ] Testar fluxos de autenticação (Login/Registo e armazenamento do token no frontend).
- [ ] Tratamento de erros de rede no cliente WPF.
