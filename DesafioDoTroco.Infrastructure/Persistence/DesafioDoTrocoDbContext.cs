using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Infrastructure.Persistence
{
    public class DesafioDoTrocoDbContext
    {
        public DesafioDoTrocoDbContext()
        {
            /*decimal é usado para Valuees monetários (evita erro de precisão de double);
            O sufixo m (100m, 0.50m) indica literal decimal em C#;*/

            Money = new List<Money>
            {
                // Cédulas
                new Money { Aticve = true, Value = 100m, TypeMoney = TypeMoneyEnum.Cedula },
                new Money { Aticve = true, Value = 50m, TypeMoney = TypeMoneyEnum.Cedula },
                new Money { Aticve = true, Value = 10m, TypeMoney = TypeMoneyEnum.Cedula },
                new Money { Aticve = true, Value = 5m, TypeMoney = TypeMoneyEnum.Cedula },
                new Money { Aticve = true, Value = 1m, TypeMoney = TypeMoneyEnum.Cedula },

                // Moedas
                new Money { Aticve = true, Value = 0.50m, TypeMoney = TypeMoneyEnum.Moeda },
                new Money { Aticve = true, Value = 0.10m, TypeMoney = TypeMoneyEnum.Moeda },
                new Money { Aticve = true, Value = 0.05m, TypeMoney = TypeMoneyEnum.Moeda },
                new Money { Aticve = true, Value = 0.01m, TypeMoney = TypeMoneyEnum.Moeda }
            };
        }

        public List<Sales> Sales { get; set; }
        public List<Money> Money { get; set; }
    }
}
