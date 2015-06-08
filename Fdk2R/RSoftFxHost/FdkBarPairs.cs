using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    public class FdkBarPairs
    {
        public static double[] GetBarsAskHigh(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsHigh(barData.SelectToArray(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidHigh(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsHigh(barData.SelectToArray(barPair => barPair.Bid));
        }

        public static double[] GetBarsAskLow(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsLow(barData.SelectToArray(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidLow(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsLow(barData.SelectToArray(barPair => barPair.Bid));
        }
        public static double[] GetBarsAskVolume(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsVolume(barData.SelectToArray(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidVolume(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsVolume(barData.SelectToArray(barPair => barPair.Bid));
        }
        public static double[] GetBarsAskOpen(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsOpen(barData.SelectToArray(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidOpen(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsOpen(barData.SelectToArray(barPair => barPair.Bid));
        }
        public static double[] GetBarsAskClose(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsClose(barData.SelectToArray(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidClose(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsClose(barData.SelectToArray(barPair => barPair.Bid));
        }        
    }
}