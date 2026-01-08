Este repositório contém a implementação de **duas aplicações cliente gRPC** desenvolvidas no âmbito da  
**Unidade Curricular de Integração de Sistemas** (Mestrado em Engenharia Informática e Tecnologia Web).

O objetivo do projeto é testar os serviços gRPC disponibilizados pela **Entidade de Registo (AR)** e pela  
**Entidade de Votação (AV)**, conforme especificado no enunciado do sistema de votação eletrónica.

---

## Contexto

No âmbito da atividade prática, são fornecidos serviços gRPC (mockups) que simulam um sistema de votação eletrónica, garantindo:
- validação de eleitores,
- emissão de credenciais de voto,
- votação anónima,
- consulta de resultados.

As aplicações cliente implementadas permitem testar os principais **casos de uso** do sistema, servindo também de base para o trabalho final da UC.

---

##  Arquitetura Geral

O sistema é composto por:
- **Entidade de Registo (AR)** – Emissão de credenciais de voto  
- **Entidade de Votação (AV)** – Gestão da votação e apuramento de resultados  
- **Clientes gRPC** – Aplicações desenvolvidas neste repositório  

Os clientes comunicam com os serviços remotos via **gRPC**, utilizando contratos definidos em ficheiros `.proto`.

---

## 📁 Estrutura do Repositório
VotingSystemClients/
├── RegistrationClient/ # Cliente gRPC da Entidade de Registo
├── VotingClient/ # Cliente gRPC da Entidade de Votação
├── Protos/ # Ficheiros .proto fornecidos
│ ├── voter.proto
│ └── voting.proto
└── README.md


---

## Tecnologias Utilizadas

- .NET (C#)
- gRPC
- Protocol Buffers
- Visual Studio
- grpcurl (para testes iniciais)

---

## Como Executar o Projeto

### Pré-requisitos

- .NET SDK (versão compatível com gRPC)
- Visual Studio (recomendado)
- Acesso à internet (para ligação aos serviços gRPC)

---

### Testes iniciais com grpcurl (opcional)

Antes de executar os clientes, os serviços podem ser testados com `grpcurl`.

**Obter credencial de voto (AR):**
```bash
'{"citizen_card_number":"123456789"}' | grpcurl -insecure \
-proto Protos/voter.proto -d "@" ken01.utad.pt:9091 \
voting.VoterRegistrationService/IssueVotingCredential

