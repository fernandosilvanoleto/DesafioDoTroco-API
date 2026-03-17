using DesafioDoTroco.Application.InputModels.Sales;
using DesafioDoTroco.Application.Services.Implementations.Sales;
using DesafioDoTroco.Application.ViewModels.Sales;
using DesafioDoTroco.Core.Services.Interfaces.Sales;
using DesafioDoTroco.Infrastructure.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Tests.Application.Services
{
    public class SalesTests
    {
        [Fact]
        public void CalculateChange_ReceberValorInferior_RetornarInsuficiente()
        {
            // Arrange
            CalculateChangeInputModel entrada_ValoresDoCliente = new CalculateChangeInputModel()
            {
                CustomerName = "Fernando Silva",
                PurchaseAmount = (decimal)100,
                AmountPaid = (decimal)90
            };

            CalculateChangeClientViewModel saida_Personalizada = new CalculateChangeClientViewModel(entrada_ValoresDoCliente, "Pagamento insuficiente");

            var dbContextMock = new Mock<DesafioDoTrocoDbContext>();

            var cashManagerMock = new Mock<ICashManager>();

            cashManagerMock
                .Setup(cm => cm.IsPaymentInsufficient(entrada_ValoresDoCliente.PurchaseAmount, entrada_ValoresDoCliente.AmountPaid))
                .Returns(true);

            var salesService = new SalesService(
                dbContextMock.Object,
                cashManagerMock.Object
            );

            // Act
            var resultado = salesService.CalculateChange(entrada_ValoresDoCliente);

            // Assert
            Assert.Equal("Pagamento insuficiente", resultado.StatusPayment);
            Assert.Equal("Fernando Silva", resultado.CustomerName);
            Assert.Equal(100, resultado.PurchaseAmount);
            Assert.Equal(90, resultado.AmountPaid);
            Assert.NotNull(resultado);
            Assert.Empty(resultado.ChangeMoneyItems);
        }
    }
}
