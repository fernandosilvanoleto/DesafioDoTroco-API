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
                new MoneyPaper(100m),
                new MoneyPaper(50m),
                new MoneyPaper(10m),
                new MoneyPaper(5m),
                new MoneyPaper(1m),

                // Moedas
                new MoneyCoin(0.50m),
                new MoneyCoin(0.10m),
                new MoneyCoin(0.05m),
                new MoneyCoin(0.01m)
            };
        }

        public List<Sales> Sales { get; set; }
        public List<Money> Money { get; set; }
    }
}
