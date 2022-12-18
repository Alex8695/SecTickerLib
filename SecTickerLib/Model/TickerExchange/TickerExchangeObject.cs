using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecTickerLib.Model.TickerExchange
{
	internal class TickerExchangeObject
	{

		public int CIK { get=>cik; set=>cik = value; }
		public string CompanyName { get => companyName; set => companyName = value; }
		public string TickerSymbol { get => tickerSymbol;set=> tickerSymbol = value; }
		public string Exchange { get=> exchange; set => exchange = value; }



		private int cik;
		private string companyName;
		private string tickerSymbol;
		private string exchange;

		public TickerExchangeObject() { }

		internal TickerExchangeObject(System.Text.Json.JsonElement[] arg)
		{
			cik = arg[0].GetInt32();
			companyName = arg[1].GetString();
			tickerSymbol = arg[2].GetString();
			exchange = arg[3].GetString();

		}
	}
}
