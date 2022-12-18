using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using JSON_ELEMENT = System.Text.Json.JsonElement;

namespace SecTickerLib.Model.TickerExchange
{
	internal class TickerExchangeResponse
	{



		[JsonPropertyName("data")]
		public JSON_ELEMENT[][] ResponseData { get; set; }

	}
}
