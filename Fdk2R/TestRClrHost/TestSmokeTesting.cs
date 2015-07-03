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
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123",  @"c:\FdkCaches\Cache1"));
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("ttlive.fxopen.com", "123318", "rCrT9e4t73HF",  @"c:\FdkCaches\Cache1"));
            FdkHelper.Disconnect();
        }

        [Test]
        public void TestQuotesLevel2()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", @"c:\FdkCaches\Cache1"));
            var time = DateTime.Now;
            var prevHour = time.AddHours(-12);
            var quotes = FdkLevel2.GetQuotePacked("EURUSD", prevHour, time);
     
            var volumesAsk = FdkLevel2.QuotesVolumeBid(quotes);
            var volumesBid = FdkLevel2.QuotesVolumeAsk(quotes);
            Assert.AreNotEqual(0, volumesAsk.Length);
            Assert.AreNotEqual(0, volumesBid.Length);
            FdkVars.Unregister(quotes);
        }


        [Test]
        public void TestQuotesLevel2WideSpread()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", @"c:\FdkCaches\Cache1"));
            var time = new DateTime(2015,06, 26, 15, 51, 0);
            var prevHour = time.AddMinutes(-1);
            var quotes = FdkLevel2.GetQuotePacked("AUDUSD", prevHour, time);

            var volumesAsk = FdkLevel2.QuotesVolumeBid(quotes);
            var volumesBid = FdkLevel2.QuotesVolumeAsk(quotes);
            Assert.AreNotEqual(0, volumesAsk.Length);
            Assert.AreNotEqual(0, volumesBid.Length);
            FdkVars.Unregister(quotes);
        }


        [Test]
        public void TestQuotesLevel2WideSpreadLastSeconds()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", @"c:\FdkCaches\Cache1"));
			var time = DateTime.UtcNow;
            var prevHour = time.AddMinutes(-1);
            var quotes = FdkLevel2.GetQuotePacked("AUDUSD", prevHour, time);

            var volumesAsk = FdkLevel2.QuotesVolumeBid(quotes);
            var volumesBid = FdkLevel2.QuotesVolumeAsk(quotes);
            Assert.AreNotEqual(0, volumesAsk.Length);
            Assert.AreNotEqual(0, volumesBid.Length);
            FdkVars.Unregister(quotes);
        }

        [Test]
        public void TestDuplicateConnectError()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", @"c:\FdkCaches\Cache1"));
            var time = DateTime.Now;
            var prevHour = time.AddMinutes(-5);

            var quotes = FdkQuotes.ComputeQuoteHistory("EURUSD", prevHour, time, 3);
            var asks = FdkQuotes.QuotesAsk(quotes);
            var bids = FdkQuotes.QuotesBid(quotes);
            var opens = FdkQuotes.QuotesCreatingTime(quotes);
            var spread = FdkQuotes.QuotesSpread(quotes);
            FdkVars.Unregister(quotes);
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", @"c:\FdkCaches\Cache1"));
            quotes = FdkQuotes.ComputeQuoteHistory("EURUSD", prevHour, time, 3);

            FdkVars.Unregister(quotes);
        }
        
        [Test]
        public void TestLevel2()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", @"c:\FdkCaches\Cache1"));
            var time = DateTime.Now;
            var prevHour = time.AddDays(-1);

            var quotes = FdkQuotes.ComputeQuoteHistory("EURUSD", prevHour, time, 3);
            var asks = FdkLevel2.QuotesVolumeAsk(quotes);
            var bids = FdkQuotes.QuotesBid(quotes);
            var opens = FdkQuotes.QuotesCreatingTime(quotes);
            var spread = FdkQuotes.QuotesSpread(quotes);
            FdkVars.Unregister(quotes);
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", @"c:\FdkCaches\Cache1"));
            quotes = FdkQuotes.ComputeQuoteHistory("EURUSD", prevHour, time, 3);

            FdkVars.Unregister(quotes);
        }
    }
}
