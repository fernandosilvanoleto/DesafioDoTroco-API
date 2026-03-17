using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Application.InputModels.Sales
{
    public class CalculateChangeInputModel
    {
        [Display(Name = "Nome do Cliente")]
        public string CustomerName { get; set; }

        [Display(Name = "Valor da Compra")]
        public decimal PurchaseAmount { get; set; }

        [Display(Name = "Valor Pago")]
        public decimal AmountPaid { get; set; }
    }
}
