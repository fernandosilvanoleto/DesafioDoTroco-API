using DesafioDoTroco.Application.InputModels.Sales;
using DesafioDoTroco.Application.Services.Implementations.Sales;
using DesafioDoTroco.Application.ViewModels.Sales;
using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.Services.Interfaces.Sales;
using DesafioDoTroco.Core.ValueObjects.Sales;
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

        [Fact]
        public void CalculateChange_ValoresNegativosOuZero_DeveLancarArgumentException()
        {
            // Arrange
            var entrada = new CalculateChangeInputModel()
            {
                CustomerName = "Fernando Silva",
                PurchaseAmount = 0, // inválido
                AmountPaid = -50    // inválido
            };

            var dbContextMock = new Mock<DesafioDoTrocoDbContext>();
            var cashManagerMock = new Mock<ICashManager>();

            var salesService = new SalesService(
                dbContextMock.Object,
                cashManagerMock.Object
            );

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
                salesService.CalculateChange(entrada)
            );

            Assert.Equal("Os valores de Valor da Compra e Valor Pago devem ser maiores que zero.", ex.Message);
        }

        [Fact]
        public void CalculateChange_ReceberValorIgualDaComprar_RetornarPagoIgualCompra()
        {
            // Arrange
            CalculateChangeInputModel entrada_ValoresDoCliente = new CalculateChangeInputModel()
            {
                CustomerName = "Fernando Silva",
                PurchaseAmount = (decimal)65,
                AmountPaid = (decimal)65
            };

            CalculateChangeClientViewModel saida_Personalizada = new CalculateChangeClientViewModel(entrada_ValoresDoCliente, "Valor pago exatamente igual ao valor da compra");

            var dbContextMock = new Mock<DesafioDoTrocoDbContext>();
            var cashManagerMock = new Mock<ICashManager>();

            cashManagerMock
                .Setup(cm => cm.IsPaymentEqualToTotal(entrada_ValoresDoCliente.PurchaseAmount, entrada_ValoresDoCliente.AmountPaid))
                .Returns(true);

            var salesService = new SalesService(
                dbContextMock.Object,
                cashManagerMock.Object
            );

            // Act
            var resultado = salesService.CalculateChange(entrada_ValoresDoCliente);

            // Assert
            Assert.Equal("Valor pago exatamente igual ao valor da compra.", resultado.StatusPayment);
            Assert.Equal("Fernando Silva", resultado.CustomerName);
            Assert.Equal(65, resultado.PurchaseAmount);
            Assert.Equal(65, resultado.AmountPaid);
            Assert.NotNull(resultado);
            Assert.Empty(resultado.ChangeMoneyItems);
        }

        [Fact]
        public void CalculateChange_PagamentoValido_RetornarTrocoCorreto()
        {
            // Arrange
            var entrada = new CalculateChangeInputModel
            {
                CustomerName = "Rafaella Martins",
                PurchaseAmount = 20m,
                AmountPaid = 50m
            };

            var moneyFake = new List<Money>
            {
                new MoneyPaper(50m),
                new MoneyPaper(10m),
                new MoneyPaper(5m),
                new MoneyPaper(1m),
                new MoneyCoin(0.50m),
                new MoneyCoin(0.10m),
                new MoneyCoin(0.05m),
                new MoneyCoin(0.01m)
            };

            var dbContextMock = new Mock<DesafioDoTrocoDbContext>();
            var cashManagerMock = new Mock<ICashManager>();

            cashManagerMock
                .Setup(cm => cm.CalculateChangeMoney(
                    20m,
                    50m,
                    moneyFake
                ))
                .Returns(new List<ResultMoneyChange>
                {
                    new ResultMoneyChange
                    {
                        Quantity = 3,
                        Value = 10,
                        TypeMoney = "Cédula(s)"
                    }
                });

            // 🔥 Mockando o próprio Service
            var serviceMock = new Mock<SalesService>(
                    dbContextMock.Object,
                    cashManagerMock.Object
                )
                { CallBase = true };

                serviceMock
                    .Setup(s => s.ConsultMoneyAvailable(50m))
                    .Returns(moneyFake);

            // Act
            var resultado = serviceMock.Object.CalculateChange(entrada);

            // Assert
            Assert.Equal("Pagamento realizado com sucesso", resultado.StatusPayment);
            Assert.Equal(30m, resultado.ChangeAmount);
            Assert.Single(resultado.ChangeMoneyItems);

            Assert.Single(resultado.ChangeMoneyItems);

            var item = resultado.ChangeMoneyItems[0];
            Assert.Equal(3, item.Quantity);
            Assert.Equal(10m, item.Value);
            Assert.Equal("Cédula(s)", item.TypeMoney);
        }

    }
}
