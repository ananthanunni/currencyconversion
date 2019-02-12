using CurrencyConversion.Dto.CurrencyManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.Dto.Conversion
{
    public class ConversionRequest:IDto
    {
        public long FromCurrency { get; set; }
        public long ToCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
