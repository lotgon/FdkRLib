using System;
using System.Threading;
using NUnit.Framework;
using RHost;

namespace TestRClrHost
{
    [TestFixture]
    public class TestRealTimeData
    {
        [Test]
        public void TestGetTradeRecords()
        {
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var eventId = FdkRealTime.MonitorSymbol("EURUSD");

			var snapshot = FdkRealTime.SnapshotMonitoredSymbol (eventId);

            //5 seconds
            Thread.Sleep(new TimeSpan(0,0,15));
            var eventData = FdkRealTime.GetEventById(eventId);

            Assert.AreNotEqual(0, eventData.Events.Count, "Some feed events should work");
            
			var bid = FdkRealTime.QuoteArrayBid(snapshot);
			var ask = FdkRealTime.QuoteArrayAsk(snapshot);
			var createTime = FdkRealTime.QuoteArrayCreateTime(snapshot);
			var spread = FdkRealTime.QuoteArraySpread(snapshot);
            
			FdkVars.Unregister (snapshot);

			FdkRealTime.RemoveEvent (eventId);

            Assert.AreEqual(eventData.Events.Count, bid.Length);
            Assert.AreEqual(eventData.Events.Count, ask.Length);
            Assert.AreEqual(eventData.Events.Count, createTime.Length);
            Assert.AreEqual(eventData.Events.Count, spread.Length);

			FdkHelper.Disconnect();
        }

    }
}