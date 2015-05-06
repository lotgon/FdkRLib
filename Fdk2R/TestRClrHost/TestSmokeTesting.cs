using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RHost;
using SoftFX.Extended;

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
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            var bars = FdkBars.ComputeBars("EURUSD", "Ask", "M1");
            var highs = FdkBars.BarHighs(bars);
            var lows = FdkBars.BarHighs(bars);
            var opens = FdkBars.BarHighs(bars);
            var volumes = FdkBars.BarHighs(bars);
            FdkVars.Unregister(bars);

        }
    }
}
