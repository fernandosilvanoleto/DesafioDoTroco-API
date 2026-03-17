using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.ValueObjects.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Payments.Interfaces
{
    public interface ICash
    {
        /// <summary>
        /// Calcula o troco com base no valor da compra, valor pago e dinheiro disponível.
        /// </summary>
        /// <param name="purchaseAmount">Valor total da compra realizada.</param>
        /// <param name="amountPaid">Valor pago pelo cliente.</param>
        /// <param name="moneyAvailable">Lista de cédulas e moedas disponíveis para fornecer o troco.</param>
        /// <returns>Lista contendo as cédulas e moedas utilizadas no troco.</returns>
        List<ResultMoneyChange> CalculateChangeAmount(decimal purchaseAmount, decimal amountPaid, List<Money> moneyAvailable);
    }
}
