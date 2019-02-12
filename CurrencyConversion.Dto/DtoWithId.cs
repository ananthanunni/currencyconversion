using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.Dto
{
    public abstract class DtoWithId : IDtoWithId
    {
        public long Id { get; set; }
    }
}
