using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.Dto
{
    public interface IDtoWithId:IDto
    {
        long Id { get; set; }
    }
}
