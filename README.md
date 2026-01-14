# Voting System – gRPC Clients

Este repositório contém a implementação de **aplicações cliente gRPC** desenvolvidas no âmbito da  
**Atividade II (Atividade 5)** da Unidade Curricular **Integração de Sistemas**, do Mestrado em Engenharia Informática e Tecnologia Web.

O objetivo do trabalho é **experimentar e testar serviços gRPC** fornecidos para um sistema de votação eletrónica, através da utilização de ferramentas de teste e do desenvolvimento de clientes de teste em C#.

---

## 🎯 Objetivos da Atividade

- Testar os serviços gRPC da **Entidade de Registo (AR)** e da **Entidade de Votação (AV)**;
- Utilizar a ferramenta **grpcurl** para validação inicial dos serviços;
- Desenvolver **duas aplicações cliente autónomas** em C#;
- Validar os principais casos de uso do sistema;
- Preparar a base para integração no **projeto final** da UC.

---

## 🧩 Estrutura do Projeto

VotingSystemClients/
├── RegistrationClient/
│ ├── Protos/
│ │ └── voter.proto
│ ├── Program.cs
│ └── RegistrationClient.csproj
├── VotingClient/
│ ├── Protos/
│ │ └── voting.proto
│ ├── Program.cs
│ └── VotingClient.csproj
├── VotingSystemClients.sln
└── README.md



---

## 📄 Contratos gRPC (.proto)

Os contratos dos serviços encontram-se definidos nos ficheiros `.proto` incluídos no repositório:

- `voter.proto` – Serviço da **Entidade de Registo**, responsável pela emissão de credenciais de voto;
- `voting.proto` – Serviço da **Entidade de Votação**, responsável pela gestão do processo de votação.

Estes contratos definem os serviços, mensagens e operações gRPC utilizadas pelas aplicações cliente.

---

## 🧪 Testes com grpcurl

Antes da implementação das aplicações cliente, os serviços gRPC foram testados utilizando a ferramenta **grpcurl**, conforme indicado no enunciado da atividade.

Foram validados os seguintes casos de uso:
- Emissão de credenciais de voto (válidas e inválidas);
- Consulta da lista de candidatos;
- Submissão de votos;
- Rejeição de votos inválidos;
- Consulta dos resultados eleitorais.

Os testes foram realizados em ambiente **Windows (PowerShell)**, utilizando o endpoint: ken01.utad.pt:9091


---

## ⚙️ Aplicações Cliente

### 🔹 RegistrationClient – Entidade de Registo
Aplicação cliente responsável por solicitar a emissão de uma credencial de voto a partir do número do cartão de cidadão introduzido pelo utilizador.

Funcionalidades principais:
- Comunicação gRPC com o serviço da Entidade de Registo;
- Tratamento de respostas válidas e inválidas;
- Apresentação do resultado ao utilizador.

---

### 🔹 VotingClient – Entidade de Votação
Aplicação cliente responsável por simular o processo de votação.

Funcionalidades principais:
- Consulta da lista de candidatos;
- Submissão de votos;
- Consulta dos resultados eleitorais.

O comportamento observado reflete corretamente a lógica do serviço *mock* disponibilizado.

---

## 🔐 Nota sobre SSL/TLS

Por se tratar de um ambiente de testes com certificados autoassinados, foi necessário desativar a validação SSL nos clientes gRPC, de forma a permitir a comunicação com o servidor remoto.  
Esta configuração é utilizada **exclusivamente para fins académicos e de teste**.

---

## ▶️ Instruções de Compilação e Execução

### Pré-requisitos
- Windows
- .NET SDK (versão 6.0 ou superior)
- Visual Studio ou Visual Studio Code

### Compilar o projeto
Na raiz do projeto:

powershell
dotnet build
Executar o cliente da Entidade de Registo
dotnet run --project RegistrationClient

Executar o cliente da Entidade de Votação
dotnet run --project VotingClient

Observações Finais

As aplicações desenvolvidas têm caráter de clientes de teste, conforme solicitado no enunciado da atividade.
Este trabalho será posteriormente integrado e expandido no projeto final da Unidade Curricular.

Autor

Bernardo Massango
Mestrado em Engenharia Informática e Tecnologia Web
Universidade Aberta
