using System;
using NUnit.Framework;
using RHost;

namespace TestRClrHost
{
    [TestFixture]
    public class TestTestingPairBar
    {
        [Test]
        public void TestBarPairs()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var time = DateTime.Now;
            var prevHour = time.AddDays(-1);

            var timeDouble = FdkHelper.GetCreatedEpoch(time);

            var bars = FdkBarPairs.ComputeGetPairBars("EURUSD", "M1", prevHour, time,  10000);
            var askhighs = FdkBarPairs.GetBarsAskHigh(bars);
            var asklows = FdkBarPairs.GetBarsAskLow(bars);
            var askopen = FdkBarPairs.GetBarsAskOpen(bars);
            var askClose = FdkBarPairs.GetBarsAskClose(bars);
            var askVolume = FdkBarPairs.GetBarsAskVolume(bars);

            var bidhighs = FdkBarPairs.GetBarsBidHigh(bars);
            var bidlows = FdkBarPairs.GetBarsBidLow(bars);
            var bidOpen = FdkBarPairs.GetBarsBidOpen(bars);
            var bidClose = FdkBarPairs.GetBarsBidClose(bars);
            var bidVolume = FdkBarPairs.GetBarsBidVolume(bars);
            
            FdkVars.Unregister(bars);
            FdkHelper.Disconnect();
        }

        [Test]
        public void TestBarsRange()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var time = DateTime.Now;
            var prevHour = time.AddDays(-1);

            var timeDouble = FdkHelper.GetCreatedEpoch(time);
            var prevHourDouble = FdkHelper.GetCreatedEpoch(prevHour);
            var bars = FdkBars.ComputeGetPairBarsRange("EURUSD", "M1", prevHour, time);
            var highs = FdkBarPairs.GetBarsAskHigh(bars);
            var lows = FdkBarPairs.GetBarsAskLow(bars);

            FdkVars.Unregister(bars);

            FdkHelper.Disconnect();
        }

    }
}