using CurrencyConversion.Data.Repository.CurrencyManagement;
using CurrencyConversion.Dto.CurrencyManagement;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CurrencyConversion.Data.Models.CurrencyManagement;

namespace CurrencyConversion.Services.CurrencyManagement
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public ExchangeRatesService(ICurrencyRepository currencyRepository, IExchangeRateRepository exchangeRateRepository)
        {
            _currencyRepository = currencyRepository;
            _exchangeRateRepository = exchangeRateRepository;
        }

        public async Task<int> SaveRates(IEnumerable<ExchangeRateDto> rates)
        {
            var dbCurrencyCodes = await _currencyRepository.Get().Select(t => t.Code)?.ToListAsync();

            var newFromCurrencies = rates.Where(r => !dbCurrencyCodes.Any(dc => dc == r.FromCurrency))?.Select(t=>t.FromCurrency);
            var newToCurrencies = rates.Where(r => !dbCurrencyCodes.Any(dc => dc == r.ToCurrency))?.Select(t=>t.ToCurrency);

            AddCurrencies(newFromCurrencies);
            AddCurrencies(newToCurrencies);
            await _currencyRepository.SaveChangesAsync();

            var currencies = await _currencyRepository.Get().Select(t => new KeyValuePair<long, string>(t.Id, t.Code)).ToListAsync();

            foreach(var rate in rates)
            {
                _exchangeRateRepository.Create(new ExchangeRate
                {
                    FromId = FindCurrencyId(currencies, rate.FromCurrency),
                    ToId = FindCurrencyId(currencies, rate.ToCurrency),
                    Rate = rate.Rate,

                    Date = rate.Date
                });
            }

            return await _exchangeRateRepository.SaveChangesAsync();
        }

        private long FindCurrencyId(List<KeyValuePair<long, string>> currencies, string currencyCode) => currencies.Find(t => t.Value == currencyCode).Key;

        private void AddCurrencies(IEnumerable<string> currencies)
        {
            if (currencies == null || currencies.Count() == 0) return;

            foreach (var c in currencies)
                _currencyRepository.Create(new Currency
                {
                    Code = c,
                    Name = null,
                    Symbol = null
                });
        }
    }
}
