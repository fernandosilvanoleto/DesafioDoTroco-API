using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Factories
{
    public static class MoneyFactory
    {
        public static Money Create(decimal value)
        {
            var baseMoney = new Money(value, GetType(value));

            return baseMoney;
        }

        public static Money CreateFromPrototype(Money prototype, decimal newValue)
        {
            var clone = prototype.Clone();
            clone.UpdateValue(newValue);

            return clone;
        }

        private static TypeMoneyEnum GetType(decimal value)
        {
            return value >= 1 ? TypeMoneyEnum.Cedula : TypeMoneyEnum.Moeda;
        }
    }
}
