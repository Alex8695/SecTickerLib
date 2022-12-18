using SecTickerLib;


namespace SecTickerTEST
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestTickerPull()
		{
			var _tickers =
				SecTickerLib.SecSymbolQuery.GetTickerSymbols();

			Assert.IsNotEmpty(_tickers);
		}
	}
}