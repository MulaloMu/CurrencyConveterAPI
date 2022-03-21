using CurrencyConverter.Data;
using CurrencyConverter.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CurrencyConverter.Controllers
{
    public class CurrenciesController : ApiController
    {

        //Database context instantiation
        CurrenciesDbContext currenciesDbContext = new CurrenciesDbContext();

        // GET: api/Currencies (Returns all saved requests from the Database)
        public IHttpActionResult Get()
        {
            try
            {
                var IsParameters = Request.RequestUri.ToString().Contains("?");
                if (!IsParameters)
                {
                   
                    return Ok(currenciesDbContext.Currencies);
                }
              
                else
                {
                    return BadRequest("Error, unknown request");
                }

            }
            catch (Exception)
            {

                return BadRequest("Error, unknown request");
            }

        }


        //GET: api/Currencies(Overloaded Get Method accepting amount and conversion type i.e USD to ZAR and GBP to ZAR)
        public IHttpActionResult Get(double amount,string conversionType)
        {


            try
            {
              var IsParameters = Request.RequestUri.ToString().ToCharArray();

                int i = IsParameters.Count(a => a == '&');

                if (Request.GetQueryNameValuePairs() == null)
                {

                    return Ok(currenciesDbContext.Currencies);
                }
                else if (conversionType != null && amount.ToString() != null && i == 1)
                {
                    HttpWebRequest request = null;

                    if (conversionType == "USD_ZAR")
                    {

                        request = (HttpWebRequest)WebRequest.Create("https://api.fastforex.io/convert?api_key=68643f1463-e0beec1960-r9011e&from=USD&to=ZAR"+ "&amount=" + amount);
                    }
                    else
                    if(conversionType == "GBP_ZAR")
                    {
                        request = (HttpWebRequest)WebRequest.Create("https://api.fastforex.io/convert?api_key=68643f1463-e0beec1960-r9011e&from=GBP&to=ZAR" + "&amount=" + amount);

                    }
                    var response = (HttpWebResponse)request.GetResponse();
                    string responseString;
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            responseString = reader.ReadToEnd();
                        }
                    }
                    var currency = JObject.Parse(responseString);
                    var convertedAmount = currency.GetValue("result").First.First.ToString();
                    var curr = new Currency
                    {

                     
                        amountFrom = amount,
                        amountTo = Double.Parse(convertedAmount),
                        Date = DateTime.Now
                    };

                    if (conversionType == "USD_ZAR")
                    {
                        currenciesDbContext.Database.ExecuteSqlCommand("exec ProcedureCurrency {0},{1}, {2},{3}", "USD", "ZAR", curr.amountFrom.ToString(), curr.amountTo);
                    }
                    else
                    if(conversionType == "GBP_ZAR")
                    {
                        currenciesDbContext.Database.ExecuteSqlCommand("exec ProcedureCurrency {0},{1}, {2},{3}", "GBP", "ZAR", curr.amountFrom.ToString(), curr.amountTo);
                    }
                    currenciesDbContext.SaveChanges();

                    return Ok(JObject.Parse(responseString));
                }
                else
                {
                    return BadRequest("Error, unknown request");
                }

            }
            catch (Exception ex)
            {

                return BadRequest("Error, unknown request");
            }

        }

        // GET: api/Currencies(Overloaded method accepting three parameters i.e from amount, to amount and amount to convert)
        public IHttpActionResult Get(string from, string to, double amount)
        {
            try
            {
                var test = Request.GetQueryNameValuePairs();
                if (Request.GetQueryNameValuePairs() == null)
                {
                   
                    return Ok(currenciesDbContext.Currencies);
                }
                else if(from != null && to != null && amount.ToString() != null) {
                    var request = (HttpWebRequest)WebRequest.Create("https://api.fastforex.io/convert?api_key=68643f1463-e0beec1960-r9011e&from=" + from + "&to=" + to + "&amount=" + amount);
                    var response = (HttpWebResponse)request.GetResponse();
                    string responseString;
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            responseString = reader.ReadToEnd();
                        }
                    }
                    var currency = JObject.Parse(responseString);
                    var convertedAmount = currency.GetValue("result").First.First.ToString();
                    var curr = new Currency
                    {

                        currencyFrom = from,
                        currencyTo = to,
                        amountFrom = amount,
                        amountTo = Double.Parse(convertedAmount),
                        Date = DateTime.Now
                    };



                    currenciesDbContext.Database.ExecuteSqlCommand("exec ProcedureCurrency {0},{1}, {2},{3}", curr.currencyFrom.ToString(), curr.currencyTo.ToString(), curr.amountFrom.ToString(), curr.amountTo);
                    currenciesDbContext.SaveChanges();
                  
                    return Ok(JObject.Parse(responseString));
                }
                else
                {
                    return BadRequest("Error, unknown request");
                }
                
            }
            catch (Exception ex)
            {

                return BadRequest("Error, unknown request");
            }
           
        }

      
    }
}
