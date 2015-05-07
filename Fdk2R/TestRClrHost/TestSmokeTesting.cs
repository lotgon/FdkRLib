using NUnit.Framework;
using RHost;

namespace TestRClrHost
{
    [TestFixture]
    public class TestSmokeTesting
    {
        [Test]
        public void ConnectToFdk()
        {
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
        }

        [Test]
        public void TestApp()
        {
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            var bars = FdkBars.ComputeBars("EURUSD", "Ask", "M1");
            var highs = FdkBars.BarHighs(bars);
            var lows = FdkBars.BarHighs(bars);
            var opens = FdkBars.BarHighs(bars);
            var volumes = FdkBars.BarHighs(bars);
            FdkVars.Unregister(bars);
        }

        [Test]
        public void TestQuotes()
        {
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            var quotes = FdkQuotes.ComputeQuoteHistory("EURUSD", "05/12/2014", "05/12/2015", 3);
            var asks = FdkQuotes.QuotesAsk(quotes);
            var bids = FdkQuotes.QuotesBid(quotes);
            var opens = FdkQuotes.QuotesCreatingTime(quotes);
            var hasAsk = FdkQuotes.QuotesHasAsk(quotes);
            var hasBid = FdkQuotes.QuotesHasBid(quotes);
            var spread = FdkQuotes.QuotesSpread(quotes);
            FdkVars.Unregister(quotes);
        }
    }
}
