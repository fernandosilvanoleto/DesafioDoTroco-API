using DesafioDoTroco.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Entities
{
    public class MoneyPaper : Money
    {
        public MoneyPaper(decimal value)
        {
            Value = value;
            TypeMoney = TypeMoneyEnum.Cedula;
            Aticve = true;
        }
    }
}
