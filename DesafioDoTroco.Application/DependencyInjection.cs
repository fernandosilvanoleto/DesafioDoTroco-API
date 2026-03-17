using DesafioDoTroco.Application.Services.Implementations.Sales;
using DesafioDoTroco.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencysApplication(this IServiceCollection services)
        {
            services.AddScoped<ISalesService, SalesService>();

            return services;
        }
    }
}
