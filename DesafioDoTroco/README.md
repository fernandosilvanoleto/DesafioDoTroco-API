# 💰 DesafioDoTroco API

API desenvolvida em .NET para cálculo de troco, seguindo boas práticas de arquitetura em camadas (Core, Application, Infrastructure e API).

---

## 🚀 Tecnologias utilizadas

- .NET 8
- C#
- Entity Framework Core
- xUnit (Testes unitários)
- Arquitetura em camadas (DDD simplificado)

---

## 📁 Estrutura do projeto

- **DesafioDoTroco.API** → Camada de entrada (Controllers / configuração)
- **DesafioDoTroco.Application** → Casos de uso / regras de aplicação
- **DesafioDoTroco.Core** → Domínio (entidades, enums, interfaces)
- **DesafioDoTroco.Infrastructure** → Acesso a dados / integrações externas
- **DesafioDoTroco.Tests** → Testes unitários

---

## ⚙️ Como rodar o projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/fernandosilvanoleto/DesafioDoTroco-API.git