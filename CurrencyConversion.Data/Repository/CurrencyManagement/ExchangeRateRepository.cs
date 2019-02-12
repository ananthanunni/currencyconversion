using CurrencyConversion.Data.Models;
using CurrencyConversion.Data.Models.CurrencyManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.Data.Repository.CurrencyManagement
{
    public class ExchangeRateRepository : GenericRepositoryBase<ExchangeRate>,IExchangeRateRepository
    {
        public ExchangeRateRepository(CurrencyDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
