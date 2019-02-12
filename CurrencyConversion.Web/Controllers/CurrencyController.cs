using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyConversion.Services.CurrencyManagement;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyConversion.Web.Controllers
{
    [Route("[controller]")]
    public class CurrencyController : Controller
    {
        private ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        // GET: /<controller>/
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> Get()
        {
            return Json(await _currencyService.GetCurrencies());
        }
    }
}
