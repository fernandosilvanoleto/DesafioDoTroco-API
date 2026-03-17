using DesafioDoTroco.Application.InputModels.Sales;
using DesafioDoTroco.Application.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Application.Services.Interfaces
{
    public interface ISalesService
    {
        CalculateChangeClientViewModel CalculateChange(CalculateChangeInputModel calculateChange); // lógica de cálculo do troco
    }
}
