using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RESPONSE_OBJ = SecTickerLib.Model.Ticker.TickerInfo;

namespace SecTickerLib.Control
{
    internal class FetchSymbol
	{

		private const string uri = @"https://www.sec.gov/files/company_tickers.json";

		public static RESPONSE_OBJ[] FetchSymbolData()
		{
			HttpRequestMessage _httpRequest;
			HttpResponseMessage _httpResponse;
			Stream _stream;
			HttpClient _client;
			Dictionary<int, RESPONSE_OBJ> _data;
			RESPONSE_OBJ[] _out = null;

			_client =
				new HttpClient();

			_httpRequest =
				new HttpRequestMessage();

			_httpRequest.RequestUri =
				new Uri(uri);

			_httpRequest.Method =
				HttpMethod.Get;

			_httpRequest.Headers.Clear();

			_httpRequest.Headers.TryAddWithoutValidation(
				name: "UserAgent",
				value: $"{Settings.CompanyName} / {Settings.ContactEmailAddress}");

			_httpRequest.Headers.TryAddWithoutValidation(
				name: "AcceptLanguage",
				value: "en-US");

			_httpRequest.Headers.TryAddWithoutValidation(
				name: "AcceptEncoding",
				values: new string[] { "gzip", "deflate" });

			_httpRequest.Headers.TryAddWithoutValidation(
				name: "Accept",
				value: "*/*");

			_httpRequest.Headers.TryAddWithoutValidation(
				name: "Connection",
				value: "keep-alive");

			_httpRequest.Headers.TryAddWithoutValidation(
				name: "Host",
				value: "www.sec.gov");

			try
			{

				Task.Run(async () => {

					_httpResponse =
						await _client.SendAsync(
							request: _httpRequest);

					using (_stream = await _httpResponse.Content.ReadAsStreamAsync())
					{
						_data =
							await JsonSerializer.DeserializeAsync<Dictionary<int,RESPONSE_OBJ>>(
								utf8Json: _stream);
					}

					_out =
						_data
						.Select(s => s.Value)
						.ToArray();
				}).Wait();
			}
			catch (Exception)
			{
				Debugger.Break();
			}

			return (_out != null)?_out:new RESPONSE_OBJ[] { };
		}
	}
}

