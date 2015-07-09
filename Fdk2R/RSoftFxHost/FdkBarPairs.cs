using System;
using System.Linq;
using SoftFX.Extended;

namespace RHost
{
	public class FdkBarPairs
	{
		/// <summary>
		/// Get the bar data as pairs
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="barPeriodStr"></param>
		/// <param name="startTime"></param>
		/// <param name="endTime"></param>
		/// <param name="barCountDbl"></param>
		/// <returns></returns>
        public static string ComputeGetPairBars(string symbol, string barPeriodStr, DateTime startTime, DateTime endTime, double barCountDbl)
		{
			try {
				var barPeriod = FdkHelper.GetFieldByName<BarPeriod>(barPeriodStr);
				if (barPeriod == null)
					return String.Empty;
				PairBar[] barsData;
				if (FdkHelper.IsTimeZero(startTime))
				{
					var barCount = (int)barCountDbl;
					barsData = GetPairBarsSymbolArray(symbol, barPeriod, endTime, -barCount);
				}
				else
				{
					barsData = GetPairBarsSymbolArrayRangeTime(symbol, barPeriod, startTime, endTime);
				}

				var bars = FdkVars.RegisterVariable(barsData, "barPairs");
				return bars;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
            
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
            return barData
                .Select(barPair => ValidTimeFromTwoTimes(barPair.Bid.To, barPair.Ask.To))
                .ToArray();
        }

        static DateTime ValidTimeFromTwoTimes(DateTime bidTime, DateTime askTime)
        {
            return FdkHelper.IsTimeZero(bidTime) ? askTime : bidTime;
        }

        public static DateTime[] GetBarsAskTo(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return barData
                .Select(barPair => ValidTimeFromTwoTimes(barPair.Bid.To, barPair.Ask.To))
                .ToArray();
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