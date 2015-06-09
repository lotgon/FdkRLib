using System;
using System.Collections.Generic;
using System.Linq;
using SoftFX.Extended;
using SoftFX.Extended.Storage;

namespace RHost
{
    public static class FdkBars
    {
        public static int SplitIntervals { get; set; }

        static FdkBars()
        {
            SplitIntervals = 10;
            BarCount = 1000000;
        }

        public static int BarCount { get; set; }
      
        #region Bars 

        public static void SetBarCount(double barCount)
        {
            BarCount = (int) barCount;
        }
        public static double GetBarCount()
        {
            return BarCount;
        }
#region Fdk direct wrapper
        private static Bar[] CalculateBarsForSymbolArray(
            string symbol, PriceType priceType, DateTime startTime, BarPeriod barPeriod, int barCount)
        { 
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetBars(symbol, priceType, barPeriod, startTime, -barCount).ToArray();
        }
        private static Bar[] CalculateBarsForSymbolArrayRangeTime(
         string symbol, PriceType priceType, DateTime startTime, BarPeriod barPeriod, DateTime endTime)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetBars(symbol, priceType, barPeriod, startTime, endTime).ToArray();
        }
        private static PairBar[] GetPairBarsSymbolArray(string symbol, BarPeriod period, DateTime startTime, int barsNumber)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetPairBars(symbol, period, startTime, barsNumber).ToArray();
        }
        private static PairBar[] GetPairBarsSymbolArrayRangeTime(string symbol, BarPeriod period, DateTime startTime, DateTime endTime)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetPairBars(symbol, period, startTime, endTime).ToArray();
        }

        private static HistoryInfo GetQuotesInfo(string symbol, int depth)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetQuotesInfo(symbol, depth);
        }
        private static HistoryInfo GetBarsInfo(string symbol, PriceType priceType, BarPeriod period)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetBarsInfo(symbol, priceType, period);
        }
#endregion


        public static string ComputeBars(string symbol, string priceTypeStr, string barPeriodStr, DateTime startTime, double barCountDbl)
        {
            var barPeriod = FdkHelper.GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return string.Empty;

            var priceType = FdkHelper.ParseEnumStr<PriceType>(priceTypeStr);
            if (priceType== null)
                return string.Empty;

            int barCount = (int) barCountDbl;

            var barsData = CalculateBarsForSymbolArray(symbol, priceType.Value, startTime, barPeriod, barCount);
            var bars = FdkVars.RegisterVariable(barsData, "bars");
            return bars;
        }

        public static string ComputeBarsRangeTime(string symbol, string priceTypeStr, string barPeriodStr,
            DateTime startTime, DateTime endTime)
        {
            var barPeriod = FdkHelper.GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return string.Empty;

            var priceType = FdkHelper.ParseEnumStr<PriceType>(priceTypeStr);
            if (priceType == null)
                return string.Empty;

            var barsData = CalculateBarsForSymbolArrayRangeTime(symbol, priceType.Value, startTime, barPeriod, endTime);
            var bars = FdkVars.RegisterVariable(barsData, "bars");
            return bars;
        }

        public static string ComputeGetPairBars(string symbol, string barPeriodStr, DateTime startTime)
        {
            var barPeriod = FdkHelper.GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return string.Empty;
            var barsData = GetPairBarsSymbolArray(symbol, barPeriod, startTime, BarCount);
            var bars = FdkVars.RegisterVariable(barsData, "barPairs");
            return bars;
        }

        public static DateTime[] ComputeGetQuotesInfo(string symbol, int depth)
        {
            var barsData = GetQuotesInfo(symbol, depth);
            var bars = new[]
            {
                barsData.AvailableFrom,
                barsData.AvailableTo
            };
            return bars;
        }

        public static DateTime[] ComputeGetBarsInfo(string symbol, string priceTypeStr, string barPeriodStr)
        {
            var barPeriod = FdkHelper.GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return new DateTime[0];
            var priceType = FdkHelper.ParseEnumStr<PriceType>(priceTypeStr);
            if (priceType == null)
                return new DateTime[0];
            var barsData = GetBarsInfo(symbol, priceType.Value, barPeriod);
            var bars = new[]
            {
                barsData.AvailableFrom,
                barsData.AvailableTo
            };
            return bars;
        }



        public static string ComputeGetPairBarsRange(string symbol, string barPeriodStr, DateTime startTime, DateTime endTime)
        {
            var barPeriod = FdkHelper.GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return string.Empty;
            var barsData = GetPairBarsSymbolArrayRangeTime(symbol, barPeriod, startTime, endTime);
            var bars = FdkVars.RegisterVariable(barsData, "barPairs");
            return bars;
        }

        #endregion


        #region Bar fields
        public static double[] BarHighs(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return GetBarsHigh(barData);
        }


        public static double[] BarLows(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return GetBarsLow(barData);
        }

        public static double[] BarVolumes(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return GetBarsVolume(barData);
        }

        public static double[] BarOpens(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return GetBarsOpen(barData);
        }

        public static double[] BarCloses(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return GetBarsClose(barData);
        }

        public static DateTime[] BarFroms(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return GetBarsFrom(barData);
        }

        public static DateTime[] BarTos(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return GetBarsTo(barData);
        }


        public static double[] GetBarsHigh(IList<Bar> barData)
        {
            return barData.SelectToArray(b => b == null ? 0.0 : b.High);
        }

        public static double[] GetBarsLow(IList<Bar> barData)
        {
            return barData.SelectToArray(b => b == null ? 0.0 : b.Low);
        }

        public static double[] GetBarsVolume(IList<Bar> barData)
        {
            return barData.SelectToArray(b => b == null ? 0.0 : b.Volume);
        }

        public static double[] GetBarsOpen(IList<Bar> barData)
        {
            return barData.SelectToArray(b => b == null ? 0.0 : b.Open);
        }

        public static double[] GetBarsClose(IList<Bar> barData)
        {
            return barData.SelectToArray(b => b == null ? 0.0 : b.Close);
        }


        private static DateTime[] GetBarsFrom(Bar[] barData)
        {
            return barData.ParititionProcess(b => b.From).ToArray();
            //return barData.Select(b => b.From).ToArray();
        }
        private static DateTime[] GetBarsTo(Bar[] barData)
        {
            return barData.ParititionProcess(b => b.To).ToArray();
            //return barData.Select(b => b.To).ToArray();
        }
        #endregion
    }
}