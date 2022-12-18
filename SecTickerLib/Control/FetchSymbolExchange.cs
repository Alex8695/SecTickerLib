using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RESPONSE = SecTickerLib.Model.TickerExchange.TickerExchangeResponse;
using RESPONSE_OBJ = SecTickerLib.Model.TickerExchange.TickerExchangeObject;

namespace SecTickerLib.Control
{
	internal class FetchSymbolExchange
	{
		private const string uri = @"https://www.sec.gov/files/company_tickers_exchange.json";

		public static RESPONSE_OBJ[] FetchSymbolExchangeData()
		{
			HttpRequestMessage _httpRequest;
			HttpResponseMessage _httpResponse;
			Stream _stream;
			HttpClient _client;
			RESPONSE _response = new RESPONSE();

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
				name:"Accept",
				value:"*/*");

			_httpRequest.Headers.TryAddWithoutValidation(
				name:"Connection",
				value:"keep-alive");

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
						_response =
							await JsonSerializer.DeserializeAsync<Model.TickerExchange.TickerExchangeResponse>(
								utf8Json: _stream);
					}
				}).Wait();



			}
			catch (Exception)
			{
				Debugger.Break();
			}

			return _response
				.ResponseData
				.Select(s => new RESPONSE_OBJ(arg: s))
				.ToArray();

		}



	}
}
