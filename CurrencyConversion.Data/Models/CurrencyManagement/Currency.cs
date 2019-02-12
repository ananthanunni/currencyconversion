using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyConversion.Data.Models.CurrencyManagement
{
    [Table("Currency")]
    public class Currency:BaseEntity, IEntity
    {
        public string Code{ get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
