using System;
using NUnit.Framework;
using RHost;

namespace TestRClrHost
{
    [TestFixture]
    public class TestSmokeTestingPairBar
    {
        [Test]
        public void TestBarsRange()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var time = DateTime.Now;
            var prevHour = time.AddDays(-1);

            var timeDouble = FdkHelper.GetCreatedEpoch(time);
            var prevHourDouble = FdkHelper.GetCreatedEpoch(prevHour);
            var bars = FdkBars.ComputeGetPairBars("EURUSD", "M1", prevHourDouble);
            var highs = FdkBars.GetBarsAskHigh(bars);
            var lows = FdkBars.GetBarsAskLow(bars);
            
            FdkVars.Unregister(bars);
        }

        [Test]
        public void TestBarsPairs()
        {
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var time = DateTime.Now;
            var prevHour = time.AddDays(-1);

            var timeDouble = FdkHelper.GetCreatedEpoch(time);
            var prevHourDouble = FdkHelper.GetCreatedEpoch(prevHour);
            var bars = FdkBars.ComputeGetPairBarsRange("EURUSD", "M1", prevHourDouble, timeDouble);
            var highs = FdkBars.GetBarsAskHigh(bars);
            var lows = FdkBars.GetBarsAskLow(bars);

            FdkVars.Unregister(bars);
        }

    }
}