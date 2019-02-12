using CurrencyConversion.Dto.CurrencyManagement;
using CurrencyConversion.Services.CurrencyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyConversion.Web.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        private ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        // GET: /<controller>/
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<CurrencyDto>>> Get()
        {
            return Json(await _currencyService.GetCurrencies());
        }
    }
}
