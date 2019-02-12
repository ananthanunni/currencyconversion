using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyConversion.Data.Models.CurrencyManagement
{
    [Table("ExchangeRate")]
    public class ExchangeRate : BaseEntity, IEntity
    {
        public virtual Currency From { get; set; }
        public virtual Currency To { get; set; }
        public double Rate { get; set; }
        public DateTime Date;
    }
}
