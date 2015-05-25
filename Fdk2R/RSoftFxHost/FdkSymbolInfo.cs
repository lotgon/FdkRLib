using System.Linq;

namespace RHost
{
    public class FdkSymbolInfo
    {
        public static double[] GetSymbolComission()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.Commission).ToArray();
        }

        public static double[] GetSymbolContractMultiplier()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.ContractMultiplier).ToArray();
        }

        public static string[] GetSymbolCurrency()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.Currency).ToArray();
        }
        public static double[] GetSymbolLimitsCommission()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.LimitsCommission).ToArray();
        }
        public static double[] GetSymbolMaxTradeVolume()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.MaxTradeVolume).ToArray();
        }
        public static double[] GetSymbolMinTradeVolume()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.MinTradeVolume).ToArray();
        }
        public static string[] GetSymbolName()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.Name).ToArray();
        }
        public static double[] GetSymbolPrecision()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => (double)b.Precision).ToArray();
        }
        public static double[] GetRoundLot()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.RoundLot).ToArray();
        }
        public static string[] GetSymbolSettlementCurrency()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.SettlementCurrency).ToArray();
        }
        public static double[] GetSymbolSwapSizeLong()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.SwapSizeLong ?? 0.0).ToArray();
        }

        public static double[] GetSymbolSwapSizeShort()
        {
            return FdkHelper.Wrapper.Symbols.Select(b => b.SwapSizeShort ?? 0.0).ToArray();
        }
    }
}
