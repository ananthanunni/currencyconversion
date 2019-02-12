using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyConversion.Data.Models.CurrencyManagement
{
    [Table("ExchangeRate")]
    public class ExchangeRate : BaseEntity, IEntity
    {
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }

        public long FromId { get; set; }
        public virtual Currency From { get; set; }

        public long ToId { get; set; }
        public virtual Currency To { get; set; }
    }
}
