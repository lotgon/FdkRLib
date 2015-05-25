using NUnit.Framework;
using RHost;

namespace TestRClrHost
{
    [TestFixture]
    public class TestSmokeSymbolsData
    {
        [Test]
        public void TestSymbols()
        {
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var symbols = FdkHelper.Wrapper.Symbols;

            FdkSymbolInfo.GetRoundLot();
            FdkSymbolInfo.GetSymbolComission();
            FdkSymbolInfo.GetSymbolContractMultiplier();
            FdkSymbolInfo.GetSymbolCurrency();
            FdkSymbolInfo.GetSymbolLimitsCommission();
            FdkSymbolInfo.GetSymbolMaxTradeVolume();
            FdkSymbolInfo.GetSymbolMinTradeVolume();
            FdkSymbolInfo.GetSymbolName();
            FdkSymbolInfo.GetSymbolPrecision();
            FdkSymbolInfo.GetSymbolSettlementCurrency();
            FdkSymbolInfo.GetSymbolSwapSizeLong();
            FdkSymbolInfo.GetSymbolSwapSizeShort();
        }
    }
}