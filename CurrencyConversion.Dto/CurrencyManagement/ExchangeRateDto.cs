using System;

namespace CurrencyConversion.Dto.CurrencyManagement
{
    public class ExchangeRateDto:IDto
    {
        public string FromCurrency { get; set; } 
        public string ToCurrency { get; set; }
        public decimal Rate { get; set; }

        public DateTime Date { get; set; }
    }
}
