using CurrencyConversion.Data.Models.CurrencyManagement;
using CurrencyConversion.Data.Repository.CurrencyManagement;
using CurrencyConversion.Dto.CurrencyManagement;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversion.Services.CurrencyManagement
{
    public class CurrencyService : BaseService<Currency, CurrencyDto>, ICurrencyService
    {
        private ICurrencyRepository _currencyRepo;

        public CurrencyService(ICurrencyRepository currencyRepo)
        {
            _currencyRepo = currencyRepo;
        }

        public Task<List<CurrencyDto>> GetCurrencies() => _currencyRepo.Get()?.Select(c => ToDto(c))?.ToListAsync();
    }
}
