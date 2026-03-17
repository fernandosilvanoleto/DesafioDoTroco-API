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
            if (calcularTrocoModel == null)
            {
                return BadRequest("Dados inválidos. Revise os dados enviados.");
            }

            try
            {
                var result = _salesServices.CalculateChange(calcularTrocoModel);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
