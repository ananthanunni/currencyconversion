using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.Dto.CurrencyManagement
{
    public class CurrencyDto:DtoWithId,IDto
    {
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
