using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConversion.Dto.CurrencyManagement;

namespace CurrencyConversion.Services.CurrencyManagement
{
    public interface IExchangeRatesService
    {
        Task<int> SaveRates(IEnumerable<ExchangeRateDto> rates);
    }
}