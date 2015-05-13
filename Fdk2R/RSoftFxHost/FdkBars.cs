using System;
using System.Collections.Generic;
using System.Linq;
using SharedFdkFunctionality;
using SoftFX.Extended;

namespace RHost
{
    public static class FdkBars
    {
        public static int SplitIntervals { get; set; }

        static FdkBars()
        {
            SplitIntervals = 10;
        }
      
        #region Bars 
        
        private static Bar[] CalculateBarsForSymbolArray(
            string symbol, PriceType priceType, DateTime startTime, BarPeriod barPeriod, int barCount)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetBars(symbol, priceType, barPeriod, startTime, -barCount).ToArray();
        }

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

        public static string[] SplitIterations<T>(IList<T> items, int splitIntervals)
        {
            var list = new List<string>();
            for (var i = 0; i < splitIntervals; i++)
            {
                list.Add(i.ToString());
            }
            var resultList = new List<string>();
            var count = items.Count;
            for (var pos = 0; pos<count;pos++)
            {
                var index = pos*splitIntervals / count;
                resultList.Add(list[index]);
                pos++;
            }
            return resultList.ToArray();
        }

        public static string[] GetBarsIntervals(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);
            return SplitIterations(barData, SplitIntervals);
        }

        #endregion

        public static string GetTimeStamp()
        {
            var time = DateTime.Now;
            return time.ToString();
        }

        public static FdkWrapper Wrapper { get; set; }
    }
}