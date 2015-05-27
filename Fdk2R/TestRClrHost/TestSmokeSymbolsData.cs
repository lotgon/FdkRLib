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
            var symbolInfos = FdkSymbolInfo.GetSymbolInfos();
            FdkSymbolInfo.GetRoundLot(symbolInfos);
            FdkSymbolInfo.GetSymbolComission(symbolInfos);
            FdkSymbolInfo.GetSymbolContractMultiplier(symbolInfos);
            FdkSymbolInfo.GetSymbolCurrency(symbolInfos);
            FdkSymbolInfo.GetSymbolLimitsCommission(symbolInfos);
            FdkSymbolInfo.GetSymbolMaxTradeVolume(symbolInfos);
            FdkSymbolInfo.GetSymbolMinTradeVolume(symbolInfos);
            FdkSymbolInfo.GetSymbolName(symbolInfos);
            FdkSymbolInfo.GetSymbolPrecision(symbolInfos);
            FdkSymbolInfo.GetSymbolSettlementCurrency(symbolInfos);
            FdkSymbolInfo.GetSymbolSwapSizeLong(symbolInfos);
            FdkSymbolInfo.GetSymbolSwapSizeShort(symbolInfos);
            FdkVars.Unregister(symbolInfos);
        }
    }
}