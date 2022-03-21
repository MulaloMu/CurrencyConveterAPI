using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurrencyConverter.Data
{
    public class CurrenciesDbContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
    }
}