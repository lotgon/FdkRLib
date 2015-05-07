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
    }
}
