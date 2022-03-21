# CurrencyConveterAPI
This is a currency converter application that converts different currencies and save all requests to a Database using C# web API

Title
Currency converter


The below are instructions about the currency conversion API with different methods.

This can be tested using Postman, below is the example APIs created.

Conver GBP to ZAR: https://localhost:44344/api/Currencies/?amount=1000000&ConversionType=GBP_ZAR
Conver USD to ZAR: https://localhost:44344/api/Currencies/?amount=1000000&ConversionType=USD_ZAR

Convert Any currency(Specify currencies): https://localhost:44344/api/Currencies/?from=usd&to=zar&amount=1000000

Please note: "https://api.fastforex.io/convert" was used as Google finance API could not be found.
api_key=68643f1463-e0beec1960-r9011e

All calls are saved on the database(Entity Framework) 
Table Name (Currencies)

Base URL

https://localhost:44344

Convert USD to ZAR
Returns json data with currency conversion results(US Dollar to Rand)

URL

/Currencies/

Method:

GET

URL Params

Required:

?amount=[Integer]&conversionType=[string]

Data Params

?amount=100&conversionType=USD_ZAR

Success Response:

Code: 200
Content: {
    "base": "USD",
    "amount": 100,
    "result": {
        "ZAR": 1495.96,
        "rate": 14.95964
    },
    "ms": 6
}
Error Response:

Code: 404 NOT FOUND
Content: { error : "Error, unknown request" }

Convert GBP to ZAR
Returns json data with currency conversion results(Pound to Rand)

URL

/Currencies/

Method:

GET

URL Params

Required:

?amount=[Integer]&conversionType=[string]

Data Params

?amount=100&conversionType=GBP_ZAR

Success Response:

Code: 200
Content: {
    "base": "GBP",
    "amount": 100,
    "result": {
        "ZAR": 1967.14,
        "rate": 19.6714
    },
    "ms": 7
}
Error Response:

Code: 404 NOT FOUND
Content: { error : "Error, unknown request" }

Convert By specifying currencies
Returns json data with currency conversion results(Any two currencies)

URL

/Currencies/

Method:

GET

URL Params

Required:

?From=[string]&To=[string]&amount=[Integer]

Data Params

?From=zar&To=usd&amount=200

Success Response:

Code: 200
Content: {
    "base": "zar",
    "amount": 100,
    "result": {
        "usd": 13,40,
        "rate": 0,067
    },
    "ms": 7
}
Error Response:

Code: 404 NOT FOUND
Content: { error : "Error, unknown request" }

Get all the conversion entries from database
Returns json data with all the conversion entries from database

URL

/Currencies/

Method:

GET

URL Params

Required:

None

Data Params

None

Success Response:

Code: 200
Content:[
    {
        "Id": 1,
        "currencyFrom": "usd",
        "currencyTo": "zar",
        "amountFrom": 100.0,
        "amountTo": 1495.33,
        "Date": "2022-03-20T14:22:14.54"
    },
    {
        "Id": 2,
        "currencyFrom": "usd",
        "currencyTo": "zar",
        "amountFrom": 100.0,
        "amountTo": 1495.33,
        "Date": "2022-03-20T14:30:27.42"
    },
    {
        "Id": 3,
        "currencyFrom": "usd",
        "currencyTo": "zar",
        "amountFrom": 10.0,
        "amountTo": 149.53,
        "Date": "2022-03-20T14:31:25.023"
    }
]


Error Response:

Code: 404 NOT FOUND
Content: { error : "Error, unknown request" }





