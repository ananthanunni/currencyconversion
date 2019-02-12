using CurrencyConversion.Dto.Conversion;
using CurrencyConversion.Services.CurrencyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurrencyConversion.Web.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyConvertController:Controller
    {
        private readonly ICurrencyConversionService _currencyConversionService;

        public CurrencyConvertController(ICurrencyConversionService currencyConversionService)
        {
            _currencyConversionService = currencyConversionService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ConversionResponse>> Convert([FromBody]ConversionRequest request)
        {
            return Json(await _currencyConversionService.ConvertAsync(request));
        }
    }
}
