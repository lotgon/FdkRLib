using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    public class FdkCurrencyInfo
    {
        public static string GetCurrencyInfos()
        {
            var symbolInfos = FdkHelper.Wrapper.ConnectLogic.Feed.Cache.Currencies;
            var varName = FdkVars.RegisterVariable(symbolInfos, "currencyInfo");
            return varName;
        }

        public static string[] GetCurrencyDescription(string currencyInfo)
        {
            var currencyInfos = FdkVars.GetValue<CurrencyInfo[]>(currencyInfo);
            return currencyInfos.SelectToArray(b => b.Description);
        }

        public static string[] GetCurrencyName(string currencyInfo)
        {
            var currencyInfos = FdkVars.GetValue<CurrencyInfo[]>(currencyInfo);
            return currencyInfos.SelectToArray(b => b.Name);
        }

        public static double[] GetCurrencyPrecision(string currencyInfo)
        {
            var currencyInfos = FdkVars.GetValue<CurrencyInfo[]>(currencyInfo);
            return currencyInfos.SelectToArray(b => (double)b.Precision);
        }
        public static double[] GetCurrencySortOrder(string currencyInfo)
        {
            var currencyInfos = FdkVars.GetValue<CurrencyInfo[]>(currencyInfo);
            return currencyInfos.SelectToArray(b => (double)b.SortOrder);
        }
    }
}