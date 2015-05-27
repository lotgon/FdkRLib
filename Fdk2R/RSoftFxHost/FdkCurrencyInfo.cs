using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    public class FdkCurrencyInfo
    {
        public static string GetCurrencyInfos()
        {
            CurrencyInfo[] symbolInfos = FdkHelper.Wrapper.ConnectLogic.Feed.Cache.Currencies;
            var varName = FdkVars.RegisterVariable(symbolInfos, "symbolsInfo");
            return varName;
        }

        public static string[] GetCurrencyDescription(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<CurrencyInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.Description).ToArray();
        }

        public static string[] GetCurrencyContractMultiplier(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<CurrencyInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.Name).ToArray();
        }

        public static double[] GetCurrencyCurrency(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<CurrencyInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => (double)b.Precision).ToArray();
        }
        public static double[] GetCurrencyLimitsCommission(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<CurrencyInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => (double)b.SortOrder).ToArray();
        }
    }
}