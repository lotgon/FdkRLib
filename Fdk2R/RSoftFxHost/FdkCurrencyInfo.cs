using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    public class FdkCurrencyInfo
    {
        public static string GetCurrencyInfos()
        {
            CurrencyInfo[] symbolInfos = FdkHelper.Wrapper.ConnectLogic.Feed.Cache.Currencies;
            var varName = FdkVars.RegisterVariable(symbolInfos, "currencyInfo");
            return varName;
        }

        public static string[] GetCurrencyDescription(string currencyInfo)
        {
            var currencyInfos = FdkVars.GetValue<CurrencyInfo[]>(currencyInfo);
            return currencyInfos.Select(b => b.Description).ToArray();
        }

        public static string[] GetCurrencyName(string currencyInfo)
        {
            var currencyInfos = FdkVars.GetValue<CurrencyInfo[]>(currencyInfo);
            return currencyInfos.Select(b => b.Name).ToArray();
        }

        public static double[] GetCurrencyPrecision(string currencyInfo)
        {
            var currencyInfos = FdkVars.GetValue<CurrencyInfo[]>(currencyInfo);
            return currencyInfos.Select(b => (double)b.Precision).ToArray();
        }
        public static double[] GetCurrencySortOrder(string currencyInfo)
        {
            var currencyInfos = FdkVars.GetValue<CurrencyInfo[]>(currencyInfo);
            return currencyInfos.Select(b => (double)b.SortOrder).ToArray();
        }
    }
}