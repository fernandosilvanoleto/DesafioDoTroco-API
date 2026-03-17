using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.ValueObjects.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Services.Interfaces.Sales
{
    public interface ICashManager
    {
        bool IsPaymentInsufficient(decimal purchaseAmount, decimal amountPaid);

        public bool IsPaymentEqualToTotal(decimal purchaseAmount, decimal amountPaid);

        public List<ResultMoneyChange> CalculateChangeMoney(decimal purchaseAmount, decimal amountPaid, List<Money> moneyAvailable);
    }
}
