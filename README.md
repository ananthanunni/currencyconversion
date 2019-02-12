# Currency Converter
Currency Converter is an SPA app which uses ASP.NET MVC Core 2.2 as backend and Angular 7 at front end.
## Project Structure
* CurrencyConversion.Core   : Contains core functionalities like logging and core Exceptions
* CurrencyConversion.Data   : Contains entity models, data access logic, repositories and DB context.
* CurrencyConversion.Dto    : Contains all DTO types.
* CurrencyConversion.Services   : Contains the business logic as service implementations.
* CurrencyConversion.Web    : This is the main project (Startup project) which contains the API controllers, routing, DI configuration and so on. The Angular SPA app being rendered at the client side resides inside the directory "ClientApp".
## Running Locally
* Execute the DB create script located at "CurrencyConversion.Data/SQL/Create Database.sql"
* Update connection string in appsettings.json. Make sure the connection string is named as "CurrencyConnectionString".
* Make sure .NET Core 2.2 is installed.
* Make sure Angular 7 + CLI is installed.
* Set CurrencyConversion.Web as startup project.
* [Optional] Create a "Development" environment in project properties if does not exist. This will be helpful to debug.
* Hit F5. It may take a while to populate the "node_modules" folder inside "CurrencyConversion.Web/ClientApp" folder which is a one time process.
## Adding exchange rates
Adding exchange rates has no UI as it is supposed to be receiving the rates being posted from external servers/services to an endpoint in the system. 
The API expects a list of rates as an array. If all rates are successfully saved, the system returns HTTP 200 OK.
Please see a sample request below.
### EndPoint/Method
POST {rootUrl}/api/exchangerates
### Headers
Content-Type : "application/json"
## Body
`
[
	{
	"fromCurrency":"USD", 
	"toCurrency":"INR",
	"rate":72,
	"date":"2019-02-13"
	}
]
`