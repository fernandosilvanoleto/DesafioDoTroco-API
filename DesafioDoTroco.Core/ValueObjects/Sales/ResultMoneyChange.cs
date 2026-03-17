using DesafioDoTroco.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.ValueObjects.Sales
{
    public class ResultMoneyChange
    {
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public string TypeMoney { get; set; }
    }
}
