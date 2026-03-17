using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.Enums;
using DesafioDoTroco.Core.ValueObjects.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Payments.Cash
{
    public class ChangeCalculator
    {

        /// <summary>
        /// Calcula o troco com base no valor da compra, valor pago e dinheiro disponível.
        /// </summary>
        /// <param name="purchaseAmount">Valor total da compra realizada.</param>
        /// <param name="amountPaid">Valor pago pelo cliente.</param>
        /// <param name="moneyAvailable">Lista de cédulas e moedas disponíveis para fornecer o troco.</param>
        /// <returns>Lista contendo as cédulas e moedas utilizadas no troco.</returns>
        public List<ResultMoneyChange> CalculateChangeAmount(decimal purchaseAmount, decimal amountPaid, List<Money> moneyAvailable)
        {
            List<ResultMoneyChange> resultMoney = new List<ResultMoneyChange>();

            decimal changeAmount = amountPaid - purchaseAmount;

            moneyAvailable = moneyAvailable
                        .OrderByDescending(m => m.Value)
                        .ToList();

            foreach (var itemMoney in moneyAvailable)
            {
                // antes de iniciar, verifica se o valor de troco já zerou
                if (changeAmount <= 0)
                    break;

                int quantity = (int)(changeAmount / itemMoney.Value);

                if (quantity > 0)
                {
                    resultMoney.Add(new ResultMoneyChange
                    {
                        Value = itemMoney.Value,
                        Quantity = quantity,
                        TypeMoney = returnNameEnum(itemMoney.TypeMoney)
                    });

                    changeAmount = changeAmount - (quantity * itemMoney.Value);

                    changeAmount = Math.Round(changeAmount, 2);
                }
            }

            return resultMoney;
        }

        private string returnNameEnum(TypeMoneyEnum typeMoney)
        {
            var field = typeof(TypeMoneyEnum).GetField(typeMoney.ToString());
            var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attr.Description;
        }
    }
}
