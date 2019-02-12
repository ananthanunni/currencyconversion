using System;

namespace CurrencyConversion.Data.Models.CurrencyManagement
{
    public class ExchangeRate : BaseEntity, IEntity
    {
        public virtual Currency From { get; set; }
        public virtual Currency To { get; set; }
        public double Rate { get; set; }
        public DateTime Date;
    }
}
