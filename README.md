# SecTickerLib

Performs multiple queries on U.S. Securities And Exchange Commissions Ticker Symbol data.

Joins multiple datasets into single object continaing:
* CIK Number (Central Index Key)
* Ticker Symbol
* Stock Exchange
* Company Name

## SEC Documentation:

Information regarding SEC EDGAR Data, along with other data sets can be found on the [SEC's Web Page](https://www.sec.gov/os/accessing-edgar-data) 

## Configuration:

Make sure to set Company Name and E-mail in [Settings.cs](/SecTickerLib/Control/Settings.cs)

These two properties are sent in the HTTP Request Header User-Agent property, as outlined by [SEC Fair access](https://www.sec.gov/os/accessing-edgar-data).

#### SEC limits the number of requests to 10 requests per second.  Each request by this library will perform 2 requests.

## Example:

```
TickerSymbol[] _tickers =
  SecTickerLib.SecSymbolQuery.GetTickerSymbols();
```

## Notes:

At time of initial release: 
* There are 24,556 symbols returned from SEC

#### Implementation Of Task

Initial testing of query returned results between 800ms-900ms.

Moving querys into individual Tasks improved time between 400ms-500ms



