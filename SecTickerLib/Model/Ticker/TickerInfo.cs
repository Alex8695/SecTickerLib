using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SecTickerLib.Model.Ticker
{
    internal class TickerInfo
    {
        [JsonPropertyName("cik_str")]
        public int CIK { get => cik; set => cik = value; }

        [JsonPropertyName("ticker")]
        public string TickerSymbol { get => tickerSymbol; set => tickerSymbol = value; }

        [JsonPropertyName("title")]
        public string CompanyName { get => companyName; set => companyName = value; }

        private int cik;
        private string tickerSymbol;
        private string companyName;

        public TickerInfo() { }
    }
}
