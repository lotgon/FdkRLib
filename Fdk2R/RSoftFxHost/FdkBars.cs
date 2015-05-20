using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using SharedFdkFunctionality;
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

        public static void SetBarCount(int barCount)
        {
            BarCount = barCount;
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

        #region Accessors
        static T? ParseEnumStr<T>(string text) where T:struct 
        {
            T result;
            if (!Enum.TryParse(text, out result))
                return null;
            return result;
        }
        static T GetFieldByName<T>(string fieldName) 
        {
            var barPeriodField = typeof(T).GetField(fieldName);
            if (barPeriodField == null)
                return default(T);
            
            var result = (T) barPeriodField.GetValue(null);

            return result;
        }
        #endregion

        public static string ComputeBars(string symbol, string priceTypeStr, string barPeriodStr)
        {
            var barPeriod = GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return string.Empty;

            var priceType = ParseEnumStr<PriceType>(priceTypeStr);
            if (priceType== null)
                return string.Empty;

            var barsData = CalculateBarsForSymbolArray(symbol, priceType.Value, DateTime.Now, barPeriod, BarCount);
            var bars = FdkVars.RegisterVariable(barsData, "bars");
            return bars;
        }

        public static string ComputeBarsRangeTime(string symbol, string priceTypeStr, string barPeriodStr, double endTimeEpoch)
        {
            var barPeriod = GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return string.Empty;

            var priceType = ParseEnumStr<PriceType>(priceTypeStr);
            if (priceType == null)
                return string.Empty;

            var endTime = FdkHelper.GetCreatedEpoch(endTimeEpoch);
            var barsData = CalculateBarsForSymbolArrayRangeTime(symbol, priceType.Value, DateTime.Now, barPeriod, endTime);
            var bars = FdkVars.RegisterVariable(barsData, "bars");
            return bars;
        }


        public static string ComputeGetPairBars(string symbol, string barPeriodStr, double startTimeEpoch)
        {
            var barPeriod = GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return string.Empty;
            var startTime = FdkHelper.GetCreatedEpoch(startTimeEpoch);

            var barsData = GetPairBarsSymbolArray(symbol, barPeriod, startTime, BarCount);
            var bars = FdkVars.RegisterVariable(barsData, "barPairs");
            return bars;
        }

        public static string ComputeGetQuotesInfo(string symbol, int depth)
        {
            var barsData = GetQuotesInfo(symbol, depth);
            var bars = FdkVars.RegisterVariable(barsData, "barPairs");
            return bars;
        }

        public static string ComputeGetBarsInfo(string symbol, string priceTypeStr, string barPeriodStr)
        {
            var barPeriod = GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return string.Empty;
            var priceType = ParseEnumStr<PriceType>(priceTypeStr);
            if (priceType == null)
                return string.Empty;
            var barsData = GetBarsInfo(symbol, priceType.Value, barPeriod);
            var bars = FdkVars.RegisterVariable(barsData, "barPairs");
            return bars;
        }



        public static string ComputeGetPairBarsRange(string symbol, string barPeriodStr, double startTimeEpoch, double endTimeEpoch)
        {
            var barPeriod = GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return string.Empty;
            var startTime = FdkHelper.GetCreatedEpoch(startTimeEpoch);

            var endTime = FdkHelper.GetCreatedEpoch(endTimeEpoch);
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

        public static double[] BarFroms(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return GetBarsFrom(barData);
        }

        public static double[] BarTos(string bars)
        {
            var barData = FdkVars.GetValue<Bar[]>(bars);

            return GetBarsTo(barData);
        }


        private static double[] GetBarsHigh(IEnumerable<Bar> barData)
        {
            return barData.Select(b => b.High).ToArray();
        }
        private static double[] GetBarsLow(IEnumerable<Bar> barData)
        {
            return barData.Select(b => b.Low).ToArray();
        }
        private static double[] GetBarsVolume(IEnumerable<Bar> barData)
        {
            return barData.Select(b => b.Volume).ToArray();
        }
        private static double[] GetBarsOpen(IEnumerable<Bar> barData)
        {
            return barData.Select(b => b.Open).ToArray();
        }
        private static double[] GetBarsClose(IEnumerable<Bar> barData)
        {
            return barData.Select(b => b.Close).ToArray();
        }
        private static double[] GetBarsFrom(Bar[] barData)
        {
            return barData.Select(b => FdkHelper.GetCreatedEpoch(b.From)).ToArray();
        }
        private static double[] GetBarsTo(Bar[] barData)
        {
            return barData.Select(b => FdkHelper.GetCreatedEpoch(b.To)).ToArray();
        }




        public static double[] GetBarsAskHigh(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return GetBarsHigh(barData.Select(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidHigh(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return GetBarsHigh(barData.Select(barPair => barPair.Bid));
        }

        public static double[] GetBarsAskLow(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return GetBarsLow(barData.Select(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidLow(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return GetBarsLow(barData.Select(barPair => barPair.Bid));
        }
        public static double[] GetBarsAskVolume(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return GetBarsVolume(barData.Select(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidVolume(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return GetBarsVolume(barData.Select(barPair => barPair.Bid));
        }
        public static double[] GetBarsAskOpen(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return GetBarsOpen(barData.Select(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidOpen(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return GetBarsOpen(barData.Select(barPair => barPair.Bid));
        }
        public static double[] GetBarsAskClose(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return GetBarsClose(barData.Select(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidClose(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return GetBarsClose(barData.Select(barPair => barPair.Bid));
        }
        #endregion
        public static FdkWrapper Wrapper { get; set; }

    }
}