using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecTickerLib
{
	public class TickerSymbol
	{
		public int CIK { get => cik;set=> cik = value; }
		public string SymbolName { get=>tickerSymbol; set=>tickerSymbol = value; }
		public string Exchange { get=>exchange; set => exchange = value; }
		public string CompanyName { get=>companyName; set=>companyName = value; }

		private int cik;
		private string tickerSymbol;
		private string exchange;
		private string companyName;

		public TickerSymbol() { }
		
		internal TickerSymbol(Model.Ticker.TickerInfo tick_info, Model.TickerExchange.TickerExchangeObject ticker_obj)
		{
			if (tick_info.CIK == ticker_obj.CIK)
			{
				this.cik = tick_info.CIK;
				this.tickerSymbol = tick_info.TickerSymbol;
				this.exchange = ticker_obj.Exchange;
				this.companyName= ticker_obj.CompanyName;

			}
		}

	}
}
