using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SecTickerLib
{

	/// <summary>
	/// <c>Security Exchange Commission Symbol Query</c>
	/// <para>Query SEC for Ticker Symbol Information</para>
	/// <para><seealso href="https://www.sec.gov/os/accessing-edgar-data">SEC Data Access</seealso></para>
	/// </summary>
	public class SecSymbolQuery
	{
		public static TickerSymbol[] GetTickerSymbols()
		{
			Model.Ticker.TickerInfo[] _tickerInfos;
			Model.TickerExchange.TickerExchangeObject[] _tickerExchangeObjects;
			TickerSymbol[] _out=null;

			try
			{
				_tickerInfos =
					Control.FetchSymbol.FetchSymbolData();

				_tickerExchangeObjects =
					Control.FetchSymbolExchange.FetchSymbolExchangeData();

				_out =
					_tickerInfos
					.Join(
						inner: _tickerExchangeObjects,
						outerKeySelector: x => x.CIK,
						innerKeySelector: x => x.CIK,
						resultSelector: (x, y) => new TickerSymbol(
							tick_info: x,
							ticker_obj: y)
						).ToArray();
			}
			catch (Exception)
			{
				Debugger.Break();
			}

			return (_out!=null)?_out:new TickerSymbol[] { };
		}

	}
}
