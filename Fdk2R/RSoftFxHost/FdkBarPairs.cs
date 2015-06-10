using System;
using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    public class FdkBarPairs
    {
       
        public static string ComputeGetPairBars(string symbol, string barPeriodStr, DateTime startTime, DateTime endTime, double barCountDbl)
        {
            var barPeriod = FdkHelper.GetFieldByName<BarPeriod>(barPeriodStr);
            if (barPeriod == null)
                return String.Empty;
            PairBar[] barsData;
            if (FdkHelper.IsTimeZero(startTime))
            {
                int barCount = (int)barCountDbl;
                barsData = GetPairBarsSymbolArray(symbol, barPeriod, endTime, -barCount);
            }
            else
            {
                barsData = GetPairBarsSymbolArrayRangeTime(symbol, barPeriod, startTime, endTime);
            }
            var bars = FdkVars.RegisterVariable(barsData, "barPairs");
            return bars;
        }
        private static PairBar[] GetPairBarsSymbolArray(string symbol, BarPeriod period, DateTime startTime, int barsNumber)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetPairBars(symbol, period, startTime, barsNumber).ToArray();
        }

        internal static PairBar[] GetPairBarsSymbolArrayRangeTime(string symbol, BarPeriod period, DateTime startTime, DateTime endTime)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetPairBars(symbol, period, startTime, endTime).ToArray();
        }

        public static double[] GetBarsAskHigh(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsHigh(barData.SelectToArray(barPair => barPair.Ask));
        }

        public static double[] GetBarsAskLow(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsLow(barData.SelectToArray(barPair => barPair.Ask));
        }
        public static double[] GetBarsAskVolume(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsVolume(barData.SelectToArray(barPair => barPair.Ask));
        }
        public static double[] GetBarsAskOpen(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsOpen(barData.SelectToArray(barPair => barPair.Ask));
        }
        public static double[] GetBarsAskClose(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsClose(barData.SelectToArray(barPair => barPair.Ask));
        }
        public static DateTime[] GetBarsAskFrom(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsFrom(barData.SelectToArray(barPair => barPair.Ask));
        }
        public static DateTime[] GetBarsAskTo(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsTo(barData.SelectToArray(barPair => barPair.Ask));
        }


        public static double[] GetBarsBidLow(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsLow(barData.SelectToArray(barPair => barPair.Bid));
        }
       
        public static double[] GetBarsBidVolume(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsVolume(barData.SelectToArray(barPair => barPair.Bid));
        }

        public static double[] GetBarsBidHigh(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsHigh(barData.SelectToArray(barPair => barPair.Bid));
        }
        public static double[] GetBarsBidOpen(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsOpen(barData.SelectToArray(barPair => barPair.Bid));
        }
        public static double[] GetBarsBidClose(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsClose(barData.SelectToArray(barPair => barPair.Bid));
        }
        public static DateTime[] GetBarsBidFrom(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsFrom(barData.SelectToArray(barPair => barPair.Bid));
        }
        public static DateTime[] GetBarsBidTo(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsTo(barData.SelectToArray(barPair => barPair.Bid));
        }
    }
}