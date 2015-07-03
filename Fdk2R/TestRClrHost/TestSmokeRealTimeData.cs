using System;
using System.Threading;
using NUnit.Framework;
using RHost;

namespace TestRClrHost
{
    [TestFixture]
    public class TestSmokeRealTimeData
    {
        [Test]
        public void TestGetTradeRecords()
        {
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var time = DateTime.Now;
            var eventId = FdkRealTime.MonitorSymbol("EURUSD");
            //5 seconds
            Thread.Sleep(new TimeSpan(0,0,15));
            var eventData = FdkRealTime.GetEventById(eventId);
            FdkHelper.Disconnect();
            Assert.AreNotEqual(0, eventData.Events.Count, "Some feed events should work");
            
            var bid = FdkRealTime.QuoteArrayBid(eventId);
            var ask = FdkRealTime.QuoteArrayAsk(eventId);
            var createTime = FdkRealTime.QuoteArrayCreateTime(eventId);
            var spread = FdkRealTime.QuoteArraySpread(eventId);
            
            Assert.AreEqual(eventData.Events.Count, bid.Length);
            Assert.AreEqual(eventData.Events.Count, ask.Length);
            Assert.AreEqual(eventData.Events.Count, createTime.Length);
            Assert.AreEqual(eventData.Events.Count, spread.Length);
        }

    }
}