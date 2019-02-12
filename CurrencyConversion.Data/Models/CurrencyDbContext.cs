using CurrencyConversion.Data.Models.CurrencyManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.Data.Models
{
    public class CurrencyDbContext:DbContext
    {
        public CurrencyDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
