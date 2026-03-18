using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Entities
{
    public class Sales : BaseEntity
    {
        public Sales(decimal valorCompra, decimal valorPago) :base()
        {
            ValorCompra = valorCompra;
            ValorPago = valorPago;
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public decimal ValorCompra { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
