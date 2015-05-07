using System;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using SharedFdkFunctionality;
using SoftFX.Extended;

namespace RHost
{
    public static class FdkBars
    {
        public static string ComputeBars(string symbol, string priceTypeStr, string barPeriodStr)
        {
            var barPeriodField = typeof(BarPeriod).GetField(barPeriodStr);
            if (barPeriodField == null)
                return string.Empty;
            var barPeriod = (BarPeriod)barPeriodField.GetValue(null);

            PriceType priceType;
            if (!PriceType.TryParse(priceTypeStr, out priceType))
                return string.Empty;
            
            var barsData = CalculateBarsForSymbolArray(symbol, priceType, DateTime.Now, barPeriod, 1000000);
            var bars = FdkVars.RegisterVariable(barsData, "bars");
            return bars;
        }
        public static string ComputeQuoteHistory(string symbol, string startTimeStr, string endTimeStr, int depth)
        {
            DateTime startTime;
            if (!DateTime.TryParse(startTimeStr, out startTime))
            {
                return String.Empty;
            }
            DateTime endTime;
            if (!DateTime.TryParse(endTimeStr, out endTime))
            {
                return String.Empty;
            }
            var barsData = CalculateHistoryForSymbolArray(symbol, startTime, endTime, depth);
            var bars = FdkVars.RegisterVariable(barsData, "bars");
            return bars;
        }

        public static double[] BarHighs(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return barData.Select(b => b.High).ToArray();
        }
        public static double[] BarLows(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return barData.Select(b => b.Low).ToArray();
        }
        public static double[] BarVolumes(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return barData.Select(b => b.Volume).ToArray();
        }

        public static double[] BarOpens(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return barData.Select(b => b.Open).ToArray();
        }
        private static Bar[] CalculateBarsForSymbolArray(
            string symbol, PriceType priceType, DateTime startTime, BarPeriod barPeriod, int barCount)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetBars(symbol, priceType, barPeriod, startTime, -barCount).ToArray();
        }

        private static Quote[] CalculateHistoryForSymbolArray(string symbol, DateTime startTime, DateTime endTime, int depth)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetQuotes(symbol,startTime,endTime, depth);
        }


        public static string GetTimeStamp()
        {
            var time = DateTime.Now;
            return time.ToString();
        }

        public static FdkWrapper Wrapper { get; set; }
    }
}