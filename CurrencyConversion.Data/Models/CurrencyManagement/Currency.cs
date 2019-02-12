namespace CurrencyConversion.Data.Models.CurrencyManagement
{
    public class Currency:BaseEntity, IEntity
    {
        public string Code{ get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
}
