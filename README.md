# **Blip Challenge**

Este repositório contém:
1. **API RESTful** em C# que atua como intermediária para a API pública do GitHub.  
2. **Chatbot** construído na plataforma **Blip** para demonstrar o fluxo conversacional e integração com a API intermediária.

## **Índice**
- [Descrição do Projeto](#descrição-do-projeto)
- [Arquitetura e Tecnologias](#arquitetura-e-tecnologias)
- [Estrutura de Pastas](#estrutura-de-pastas)
---

## **Descrição do Projeto**
Este projeto foi desenvolvido para atender ao **Desafio Chatbot Developer** da Take Blip, onde o objetivo principal é:
- Listar informações sobre os 5 (cinco) repositórios de linguagem C# mais antigos do GitHub da **Blip**.
  
---

## **Arquitetura e Tecnologias**
- **.NET 8** (C#) – para a **API**.
- **HttpClient / IHttpClientFactory** – para consumir a API do GitHub.
- **xUnit** – para testes unitários.

---

## **Estrutura de Pastas**
A estrutura para o repositório é:
```scss
├── Api
│   ├── Controllers
│   │   └── RepositoriesController.cs
│   ├── Models
│   │   └── *.cs
│   ├── Repositories
│   │   └── GitHubRepository.cs
│   ├── Services
│   │   └── RepositoryService.cs
│   ├── Tests
│   │   └── RepositoryServiceTests.cs
│   ├── Utils
│   │   └── Logger.cs
│   └── Program.cs
├── Flow
│   └── mybotflow.json (export do fluxo do Blip)
```
---

## **Configuração e Execução da API**

### **Pré-requisitos**
1. **.NET 8**.
2. **Git**.
3. **Chave/TOKEN** do GitHub.
