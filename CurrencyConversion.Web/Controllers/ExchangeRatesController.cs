using CurrencyConversion.Dto.CurrencyManagement;
using CurrencyConversion.Services.CurrencyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConversion.Web.Controllers
{
    [Route("api/[controller]")]
    public class ExchangeRatesController : Controller
    {
        private readonly IExchangeRatesService _exchangeRatesService;

        public ExchangeRatesController(IExchangeRatesService exchangeRatesService)
        {
            _exchangeRatesService = exchangeRatesService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post([FromBody]IEnumerable<ExchangeRateDto> rates)
        {
            return Ok(await _exchangeRatesService.SaveRates(rates));
        }
    }
}
