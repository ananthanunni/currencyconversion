using CurrencyConversion.Data.Models.CurrencyManagement;
using CurrencyConversion.Data.Repository.CurrencyManagement;
using CurrencyConversion.Dto.Conversion;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversion.Services.CurrencyManagement
{
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public CurrencyConversionService(IExchangeRateRepository exchangeRateRepository)
        {
            this._exchangeRateRepository = exchangeRateRepository;
        }

        public async Task<ConversionResponse> ConvertAsync(ConversionRequest request)
        {
            // TODO: Check for currency validity
            var conversionRate = await _exchangeRateRepository
                .Get(e => (e.From.Id == request.FromCurrency && e.To.Id == request.ToCurrency) || (e.From.Id == request.ToCurrency && e.To.Id == request.FromCurrency))
                .Include(t => t.From).Include(t => t.To)
                .OrderByDescending(t => t.Date)
                .FirstOrDefaultAsync();

            // TODO: Clarify whether indirect rate resolution can be done. (If Ca->Cb rate is not available is it OK to use Ca->Cx->Cb calculation)
            if (conversionRate == null)
                return ConversionResponse.CreateErrorResponse(ConversionStatus.RateNotAvailable);

            if (conversionRate.From.IsDeleted==true)
                return ConversionResponse.CreateErrorResponse(ConversionStatus.SourceCurrencyInvalid);

            if (conversionRate.To.IsDeleted == true)
                return ConversionResponse.CreateErrorResponse(ConversionStatus.TargetCurrencyInvalid);

            return new ConversionResponse
            {
                Status = ConversionStatus.Success,
                Amount = Calculate(conversionRate, request),
                DateUpdated = conversionRate.Date
            };
        }

        private decimal Calculate(ExchangeRate conversionRate, ConversionRequest request)
        {
            var isStraightRate = request.FromCurrency == conversionRate.From.Id;

            if (isStraightRate) return request.Amount * conversionRate.Rate;

            return request.Amount / conversionRate.Rate;
        }
    }
}
