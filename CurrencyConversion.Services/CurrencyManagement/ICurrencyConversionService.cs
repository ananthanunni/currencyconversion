using System.Threading.Tasks;
using CurrencyConversion.Dto.Conversion;

namespace CurrencyConversion.Services.CurrencyManagement
{
    public interface ICurrencyConversionService
    {
        Task<ConversionResponse> ConvertAsync(ConversionRequest request);
    }
}