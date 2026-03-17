using DesafioDoTroco.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Entities
{
    public class MoneyCoin : Money
    {
        public MoneyCoin(decimal value)
        {
            Value = value;
            TypeMoney = TypeMoneyEnum.Moeda;
            Aticve = true;
        }
    }
}
