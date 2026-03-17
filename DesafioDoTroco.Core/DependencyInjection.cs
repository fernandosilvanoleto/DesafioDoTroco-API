using DesafioDoTroco.Core.Payments.Cash;
using DesafioDoTroco.Core.Services.Implementations.Sales;
using DesafioDoTroco.Core.Services.Interfaces.Sales;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencysCore(this IServiceCollection services)
        {
            // Dependências Externas do "<ISalesService, SalesService>"
            // toda dependência do construtor precisa estar registrada no container.
            services.AddScoped<ChangeCalculator>();
            services.AddScoped<ICashManager, CashManager>();

            return services;
        }
    }    
}
