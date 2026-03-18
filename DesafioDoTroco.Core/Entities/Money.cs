using DesafioDoTroco.Core.Entities.Interfaces;
using DesafioDoTroco.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Entities
{
    public class Money : BaseEntity, IPrototype<Money>
    {
        public decimal Value { get; private set; }
        public TypeMoneyEnum TypeMoney { get; private set; }

        public Money(decimal value, TypeMoneyEnum type)
        {
            Value = value;
            TypeMoney = type;
            Active = true;
        }

        public Money Clone()
        {
            return new Money(this.Value, this.TypeMoney);
        }

        public void UpdateValue(decimal newValue)
        {
            Value = newValue;
        }
    }
}
