using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.Payments.Cash;
using DesafioDoTroco.Core.Services.Interfaces.Sales;
using DesafioDoTroco.Core.ValueObjects.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Services.Implementations.Sales
{
    public class CashManager : ICashManager
    {
        // Como usa injenção de dependência
        private readonly ChangeCalculator _changeCalculator;

        public CashManager(ChangeCalculator changeCalculator)
        {
            _changeCalculator = changeCalculator;
        }

        // Se o valor de recebimento for menor do que o total a ser pago, retornar ao cliente que está faltando dinheiro
        public bool IsPaymentInsufficient(decimal purchaseAmount, decimal amountPaid)
        {
            return amountPaid < purchaseAmount;
        }

        public bool IsPaymentEqualToTotal(decimal purchaseAmount, decimal amountPaid)
        {
            return amountPaid == purchaseAmount;
        }

        /// <summary>
        /// Gerenciar chamada ao método/função para calcular o troco com base no valor da compra, valor pago e dinheiro disponível.
        /// </summary>
        /// <param name="purchaseAmount">Valor total da compra realizada.</param>
        /// <param name="amountPaid">Valor pago pelo cliente.</param>
        /// <param name="moneyAvailable">Lista de cédulas e moedas disponíveis para fornecer o troco.</param>
        /// <returns>Retornar uma lista contendo as cédulas e moedas utilizadas no troco.</returns>
        public List<ResultMoneyChange> CalculateChangeMoney(decimal purchaseAmount, decimal amountPaid, List<Money> moneyAvailable)
        {
            List<ResultMoneyChange> resultMoneyChanges = _changeCalculator.CalculateChangeAmount(purchaseAmount, amountPaid, moneyAvailable);

            return resultMoneyChanges;
        }
    }
}
