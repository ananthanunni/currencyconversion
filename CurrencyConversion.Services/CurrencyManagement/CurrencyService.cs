using CurrencyConversion.Data.Models.CurrencyManagement;
using CurrencyConversion.Data.Repository.CurrencyManagement;
using CurrencyConversion.Dto.Conversion;
using CurrencyConversion.Dto.CurrencyManagement;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversion.Services.CurrencyManagement
{
    public class CurrencyService : BaseService<Currency, CurrencyDto>, ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepo;
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public CurrencyService(ICurrencyRepository currencyRepo, IExchangeRateRepository exchangeRateRepository)
        {
            _currencyRepo = currencyRepo;
            _exchangeRateRepository = exchangeRateRepository;
        }

        public Task<List<CurrencyDto>> GetCurrencies() => _currencyRepo.Get(c => c.IsDeleted != true)?.Select(c => ToDto(c))?.ToListAsync();        
    }
}
