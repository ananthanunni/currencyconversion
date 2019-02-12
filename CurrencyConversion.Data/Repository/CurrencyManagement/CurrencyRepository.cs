using CurrencyConversion.Data.Models;
using CurrencyConversion.Data.Models.CurrencyManagement;

namespace CurrencyConversion.Data.Repository.CurrencyManagement
{
    public class CurrencyRepository : GenericRepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(CurrencyDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
