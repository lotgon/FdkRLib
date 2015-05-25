using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    public class FdkBarPairs
    {
        public static double[] GetBarsAskHigh(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsHigh(barData.Select(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidHigh(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsHigh(barData.Select(barPair => barPair.Bid));
        }

        public static double[] GetBarsAskLow(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsLow(barData.Select(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidLow(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsLow(barData.Select(barPair => barPair.Bid));
        }
        public static double[] GetBarsAskVolume(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsVolume(barData.Select(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidVolume(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsVolume(barData.Select(barPair => barPair.Bid));
        }
        public static double[] GetBarsAskOpen(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsOpen(barData.Select(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidOpen(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsOpen(barData.Select(barPair => barPair.Bid));
        }
        public static double[] GetBarsAskClose(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsClose(barData.Select(barPair => barPair.Ask));
        }
        public static double[] GetBarsBidClose(string pairBars)
        {
            var barData = FdkVars.GetValue<PairBar[]>(pairBars);
            return FdkBars.GetBarsClose(barData.Select(barPair => barPair.Bid));
        }        
    }
}