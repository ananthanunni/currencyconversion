using CurrencyConversion.Dto.CurrencyManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConversion.Services.CurrencyManagement
{
    public interface ICurrencyService
    {
        Task<List<CurrencyDto>> GetCurrencies();        
    }
}