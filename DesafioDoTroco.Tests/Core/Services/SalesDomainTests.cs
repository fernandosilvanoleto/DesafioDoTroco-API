using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.Factories;
using DesafioDoTroco.Core.Payments.Interfaces;
using DesafioDoTroco.Core.Services.Implementations.Sales;
using DesafioDoTroco.Core.ValueObjects.Sales;
using Moq;

namespace DesafioDoTroco.Tests;

public class SalesDomainTests
{
    [Fact]
    public void CashManager_IsPaymentInsufficient_ValorMenor_RetornarTrue()
    {
        var cashMock = new Mock<ICash>();
        var manager = new CashManager(cashMock.Object);

        var resultado = manager.IsPaymentInsufficient(100m, 50m);

        Assert.True(resultado);
    }

    [Fact]
    public void CashManager_IsPaymentEqualToTotal_QuandoValoresIguais_RetornarTrue()
    {
        var cashMock = new Mock<ICash>();
        var manager = new CashManager(cashMock.Object);

        var resultado = manager.IsPaymentEqualToTotal(100m, 100m);

        Assert.True(resultado);
    }

    
    [Fact]
    public void CashManager_CalculateChangeMoney_DeveChamarCashERetornarResultado()
    {
        // Arrange
        var moneyList = new List<Money>
        {
            MoneyFactory.Create(10m)
        };

        var retornoEsperado = new List<ResultMoneyChange>
        {
            new ResultMoneyChange
            {
                Quantity = 3,
                Value = 10,
                TypeMoney = "Cédula(s)"
            }
        };

        var cashMock = new Mock<ICash>();

        cashMock
            .Setup(c => c.CalculateChangeAmount(20m, 50m, moneyList))
            .Returns(retornoEsperado);

        var manager = new CashManager(cashMock.Object);

        // Act
        var resultado = manager.CalculateChangeMoney(20m, 50m, moneyList);

        // Assert
        Assert.Equal(retornoEsperado, resultado);
        Assert.Single(resultado);
        Assert.Equal(3, resultado[0].Quantity);
        Assert.Equal(10m, resultado[0].Value);
        Assert.Equal("Cédula(s)", resultado[0].TypeMoney);
    }
    
}
