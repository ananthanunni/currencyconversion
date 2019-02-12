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

        // TODO: Deliberately calculating at the server side rather than bring the params to the client and calculating in browser in order to demostrate HTTP POST
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ConversionResponse>> Convert([FromBody]ConversionRequest request)
        {
            return Ok(await _currencyConversionService.ConvertAsync(request));
        }
    }
}
