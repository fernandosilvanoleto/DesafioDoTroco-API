using DesafioDoTroco.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Entities
{
    public class Money : BaseEntity
    {
        public decimal Value { get; set; }
        public TypeMoneyEnum TypeMoney { get; set; }
    }
}
