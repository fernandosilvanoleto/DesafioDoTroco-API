using DesafioDoTroco.Application.InputModels.Sales;
using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.ValueObjects.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Application.ViewModels.Sales
{
    public class CalculateChangeClientViewModel
    {
        public CalculateChangeClientViewModel(CalculateChangeInputModel input, string statusPayment)
        {
            this.StatusPayment = statusPayment;
            this.CustomerName = input.CustomerName;
            this.PurchaseAmount = input.PurchaseAmount;
            this.AmountPaid = input.AmountPaid;
            this.ChangeAmount = (input.AmountPaid - input.PurchaseAmount);
        }

        public CalculateChangeClientViewModel(CalculateChangeInputModel input, string statusPayment, decimal changeAmount, List<ResultMoneyChange> changeMoneyItems)
        {
            this.StatusPayment = statusPayment;
            this.CustomerName = input.CustomerName;
            this.PurchaseAmount = input.PurchaseAmount;
            this.AmountPaid = input.AmountPaid;
            this.ChangeAmount = changeAmount;
            this.ChangeMoneyItems = changeMoneyItems;
        }

        [Display(Name = "Status de Pagamento")]
        public string StatusPayment { get; private set; }

        [Display(Name = "Nome do Cliente")]
        public string CustomerName { get; private set; }


        [Display(Name = "Valor da Compra")]
        public decimal PurchaseAmount { get; private set; }


        [Display(Name = "Valor Pago")]
        public decimal AmountPaid { get; private set; }


        [Display(Name = "Troco Total")]
        public decimal ChangeAmount { get; private set; } = 0;


        [Display(Name = "Detalhamento do Troco")]
        public List<ResultMoneyChange> ChangeMoneyItems { get; private set; } = new List<ResultMoneyChange>();
    }
}

/*
 Escolhi estruturar o modelo com propriedades explícitas e com o atributo [Display] para manter clareza semântica, padronização de documentação e separação adequada de responsabilidades, aspectos importantes em sistemas financeiros e contábeis de grande porte.

Cada propriedade representa um dado específico do processo de cálculo de troco — nome do cliente, valor da compra, valor pago e valor do troco — e o uso do atributo [Display(Name = "...")] permite manter o código em inglês (seguindo boas práticas de desenvolvimento) enquanto a descrição exibida para usuários, logs ou documentação permanece em português, facilitando a compreensão para usuários de negócio e equipes de suporte.

Além disso, optei por manter classes de entrada (InputModel) e de saída (ViewModel) separadas, evitando herança entre DTOs. Em sistemas financeiros isso é importante porque tais sistemas exigem:

baixo acoplamento, para evitar que mudanças em modelos de entrada afetem contratos de saída;

auditoria, permitindo registrar exatamente quais dados entraram e quais foram retornados pelo sistema;

versionamento de API, possibilitando evoluir endpoints sem quebrar integrações existentes;

rastreabilidade, essencial para investigações e conferências contábeis.

Com essa abordagem, cada modelo possui uma responsabilidade clara e o fluxo de dados entre eles pode ser feito de forma controlada por mapeamento manual ou ferramentas de mapeamento como AutoMapper. Essa separação reduz riscos de manutenção, melhora a legibilidade do código e torna a arquitetura mais robusta para sistemas críticos.

Em resumo, a decisão segue princípios de Clean Architecture e boas práticas de APIs, priorizando classes separadas, baixo acoplamento e ausência de herança entre DTOs, garantindo maior segurança, previsibilidade e facilidade de evolução do sistema.
 */