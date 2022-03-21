using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyConverter.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string currencyFrom { get; set; }
        public string currencyTo { get; set; }
        public double amountFrom { get; set; }
        public double amountTo { get; set; }
        public DateTime Date { get; set; }
    }
}