using System;
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
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
        }

        [Test]
        public void TestApp()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var bars = FdkBars.ComputeBars("EURUSD", "Ask", "M1");
            var highs = FdkBars.BarHighs(bars);
            var lows = FdkBars.BarLows(bars);
            var opens = FdkBars.BarOpens(bars);
            var volumes = FdkBars.BarVolumes(bars);
            var closes = FdkBars.BarCloses(bars);
            var froms = FdkBars.BarFroms(bars);
            var tos = FdkBars.BarTos(bars);
            FdkVars.Unregister(bars);
        }

        [Test]
        public void TestQuotes()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", @"c:\FdkCaches\Cache1"));
            var time = DateTime.Now;
            var prevHour = time.AddDays(-1);
            var quotes = FdkQuotes.ComputeQuoteHistory("EURUSD", prevHour.ToString(), time.ToString(), 3);
            var asks = FdkQuotes.QuotesAsk(quotes);
            var bids = FdkQuotes.QuotesBid(quotes);
            var opens = FdkQuotes.QuotesCreatingTime(quotes);
            var hasAsk = FdkQuotes.QuotesHasAsk(quotes);
            var hasBid = FdkQuotes.QuotesHasBid(quotes);
            var spread = FdkQuotes.QuotesSpread(quotes);
            Assert.AreNotEqual(0, asks.Length);
            FdkVars.Unregister(quotes);
        
        }

        [Test]
        public void TestDuplicateConnectError()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", @"c:\FdkCaches\Cache1"));
            var time = DateTime.Now;
            var prevHour = time.AddDays(-1);
            var quotes = FdkQuotes.ComputeQuoteHistory("EURUSD", prevHour.ToString(), time.ToString(), 3);
            var asks = FdkQuotes.QuotesAsk(quotes);
            var bids = FdkQuotes.QuotesBid(quotes);
            var opens = FdkQuotes.QuotesCreatingTime(quotes);
            var hasAsk = FdkQuotes.QuotesHasAsk(quotes);
            var hasBid = FdkQuotes.QuotesHasBid(quotes);
            var spread = FdkQuotes.QuotesSpread(quotes);
            FdkVars.Unregister(quotes);
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", @"c:\FdkCaches\Cache1"));
            quotes = FdkQuotes.ComputeQuoteHistory("EURUSD", prevHour.ToString(), time.ToString(), 3);

            hasBid = FdkQuotes.QuotesHasBid(quotes);
            FdkVars.Unregister(quotes);
            Assert.AreNotEqual(0, hasBid.Length);
        }
    }
}
