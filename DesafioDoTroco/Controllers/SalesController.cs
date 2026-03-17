using DesafioDoTroco.Application.InputModels.Sales;
using DesafioDoTroco.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDoTroco.Controllers
{
    [Route("api/sales")]
    public class SalesController : Controller
    {
        private readonly ISalesService _salesServices;
        public SalesController(ISalesService salesService)
        {
            _salesServices = salesService;
        }

        [HttpPost("calculateChange")]
        public IActionResult CalculateChange([FromBody] CalculateChangeInputModel calcularTrocoModel)
        {
            var returnChange = _salesServices.CalculateChange(calcularTrocoModel);

            if (returnChange == null)
            {
                return NotFound();
            }

            return Ok(returnChange);
        }
    }
}
