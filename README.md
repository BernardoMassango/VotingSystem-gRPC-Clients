# Voting System – gRPC Clients

Este repositório contém a implementação das **aplicações cliente gRPC** desenvolvidas no âmbito da  
**Tarefa 5 – Atividade II** da Unidade Curricular **Integração de Sistemas**, do Mestrado em Engenharia Informática e Tecnologia Web.

O objetivo do trabalho é testar os serviços gRPC disponibilizados pela **Entidade de Registo (AR)** e pela  
**Entidade de Votação (AV)**, no contexto de um sistema de votação eletrónica.

---

## 📌 Contexto do Projeto

No enunciado da atividade, são fornecidos serviços gRPC (*mockups*) que simulam um sistema de votação eletrónica, permitindo:
- emissão de credenciais de voto;
- consulta de candidatos;
- submissão de votos;
- apuramento de resultados.

As aplicações cliente criadas neste repositório permitem estruturar e documentar a integração com estes serviços, de acordo com os princípios estudados na UC.

---

## 🧩 Estrutura do Repositório
VotingSystem-gRPC-Clients/
├── RegistrationClient/
│ ├── Program.cs
│ ├── RegistrationClient.csproj
│ └── Protos/
│ └── voter.proto
├── VotingClient/
│ ├── Program.cs
│ ├── VotingClient.csproj
│ └── Protos/
│ └── voting.proto
├── VotingSystemClients.sln
└── README.md


---

## 📄 Contratos gRPC (.proto)

Os contratos dos serviços encontram-se definidos nos ficheiros `.proto`, incluídos no repositório:
- `voter.proto` – Entidade de Registo (AR)
- `voting.proto` – Entidade de Votação (AV)

Estes ficheiros descrevem os serviços, mensagens e operações disponíveis, sendo fundamentais para a integração gRPC.

---

## 🧪 Testes com grpcurl

Antes da implementação das aplicações cliente, os serviços foram testados utilizando a ferramenta **grpcurl**, conforme recomendado no enunciado da atividade.

Foram validados os seguintes casos de uso:
- emissão de credenciais de voto (válidas e inválidas);
- obtenção da lista de candidatos;
- submissão de votos;
- rejeição de votos inválidos;
- consulta de resultados eleitorais.

Os testes confirmaram o correto funcionamento dos serviços, tendo em conta que se tratam de *mockups* com persistência apenas em memória.

---

## ⚙️ Aplicações Cliente

Foram estruturadas duas aplicações cliente independentes:

### 🔹 RegistrationClient
Cliente responsável por simular a fase de registo do eleitor, solicitando a emissão de uma credencial de voto a partir do número do cartão de cidadão.

### 🔹 VotingClient
Cliente responsável por simular a fase de votação, permitindo consultar candidatos, submeter votos e consultar resultados.

---

## ⚠️ Nota sobre o Ambiente de Desenvolvimento

A implementação foi realizada em ambiente **macOS**.  
Verificou-se uma limitação de compatibilidade do compilador `protoc` (Grpc.Tools) com o runtime C++ do sistema operativo, o que impediu a geração automática dos *stubs* gRPC localmente.

No entanto:
- os serviços foram corretamente testados com `grpcurl`;
- os contratos `.proto` encontram-se incluídos;
- a estrutura das aplicações cliente e a lógica de integração estão devidamente documentadas.

Esta limitação não compromete os objetivos da atividade, que se centram na compreensão e integração de sistemas via gRPC.

---

## 📚 Referência

- Trabalho Prático de Integração de Sistemas – *Voting System*  
  Ano letivo 2025–2026

---

## 👤 Autor

Bernardo Massango  
Mestrado em Engenharia Informática e Tecnologia Web  
Universidade Aberta

