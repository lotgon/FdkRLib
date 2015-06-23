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

        }

    }
}