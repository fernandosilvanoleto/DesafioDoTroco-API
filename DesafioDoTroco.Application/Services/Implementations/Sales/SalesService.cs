using DesafioDoTroco.Application.InputModels.Sales;
using DesafioDoTroco.Application.Services.Interfaces;
using DesafioDoTroco.Application.ViewModels.Sales;
using DesafioDoTroco.Core.Entities;
using DesafioDoTroco.Core.Services.Interfaces.Sales;
using DesafioDoTroco.Core.ValueObjects.Sales;
using DesafioDoTroco.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Application.Services.Implementations.Sales
{
    public class SalesService : ISalesService
    {
        private readonly DesafioDoTrocoDbContext _dbContext;
        private readonly ICashManager _cashManager;
        public SalesService(DesafioDoTrocoDbContext dbContext, ICashManager cashManager)
        {
            _dbContext = dbContext; // Injeção de Dependência para um Contexto de banco de dados
            _cashManager = cashManager;
        }
        public CalculateChangeClientViewModel CalculateChange(CalculateChangeInputModel calculateChange)
        {
            Debug.WriteLine($"[SalesService][CalculateChange] Iniciar pagamento em dinheiro. Total: {calculateChange.PurchaseAmount}, Pago: {calculateChange.AmountPaid}, Cliente: {calculateChange.CustomerName}");

            if (_cashManager.IsPaymentInsufficient(calculateChange.PurchaseAmount, calculateChange.AmountPaid))
            {
                Debug.WriteLine($"[SalesService][CalculateChange] Pagamento insuficiente.");

                return new CalculateChangeClientViewModel(
                    calculateChange,
                    "Pagamento insuficiente"
                );
            }

            if (_cashManager.IsPaymentEqualToTotal(calculateChange.PurchaseAmount, calculateChange.AmountPaid))
            {
                Debug.WriteLine("[SalesService][CalculateChange] Pagamento exato");

                return new CalculateChangeClientViewModel(
                    calculateChange,
                    "Valor pago exatamente igual ao valor da compra"
                );
            }

            List<Money> availableBankMoney = ConsultMoneyAvailable(calculateChange.AmountPaid);

            List<ResultMoneyChange> resultMoney = _cashManager.CalculateChangeMoney(calculateChange.PurchaseAmount, calculateChange.AmountPaid, availableBankMoney);

            var changeValue = calculateChange.AmountPaid - calculateChange.PurchaseAmount;

            return new CalculateChangeClientViewModel(
                calculateChange,
                "Pagamento realizado com sucesso",
                changeValue,
                resultMoney
            );
        }

        /// <summary>
        /// Buscar os dinheiros disponíveis e ativos no banco de dados
        /// </summary>
        /// <param name="amountPaid">Valor pago pelo cliente.</param>
        /// <returns>Listar as cédulas e moedas menor do que o valor pago.</returns>
        private List<Money> ConsultMoneyAvailable(decimal amountPaid)
        {
            // listar dinheiro (cédulas e moedas) do banco
            List<Money> moneys = _dbContext.Money
                .Where(m => m.Value <= amountPaid && m.Aticve == true)
                .ToList();

            return moneys;
        }
    }
}
