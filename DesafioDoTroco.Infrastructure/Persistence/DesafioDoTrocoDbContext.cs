using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.Enums;
using DesafioDoTroco.Core.Factories;
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
                MoneyFactory.Create(100m),
                MoneyFactory.Create(50m),
                MoneyFactory.Create(10m),
                MoneyFactory.Create(5m),
                MoneyFactory.Create(1m),

                // Moedas
                MoneyFactory.Create(0.50m),
                MoneyFactory.Create(0.10m),
                MoneyFactory.Create(0.05m),
                MoneyFactory.Create(0.01m),

                // Clonar moeda de 100 e criar uma de 200
                MoneyFactory.CreateFromPrototype(MoneyFactory.Create(100m), 200m),
            };
        }

        public List<Sales> Sales { get; set; }
        public List<Money> Money { get; set; }
    }
}
