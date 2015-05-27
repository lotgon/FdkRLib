using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    public class FdkSymbolInfo
    {
        public static string GetSymbolInfos()
        {
            var symbolInfos = FdkHelper.Wrapper.ConnectLogic.Feed.Cache.Symbols;
            var varName = FdkVars.RegisterVariable(symbolInfos, "symbolsInfo");
            return varName;
        }

        public static double[] GetSymbolComission(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.Commission).ToArray();
        }

        public static double[] GetSymbolContractMultiplier(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.ContractMultiplier).ToArray();
        }

        public static string[] GetSymbolCurrency(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.Currency).ToArray();
        }
        public static double[] GetSymbolLimitsCommission(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.LimitsCommission).ToArray();
        }
        public static double[] GetSymbolMaxTradeVolume(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.MaxTradeVolume).ToArray();
        }
        public static double[] GetSymbolMinTradeVolume(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.MinTradeVolume).ToArray();
        }
        public static string[] GetSymbolName(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.Name).ToArray();
        }
        public static double[] GetSymbolPrecision(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => (double)b.Precision).ToArray();
        }
        public static double[] GetRoundLot(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.RoundLot).ToArray();
        }
        public static string[] GetSymbolSettlementCurrency(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.SettlementCurrency).ToArray();
        }
        public static double[] GetSymbolSwapSizeLong(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.SwapSizeLong ?? 0.0).ToArray();
        }

        public static double[] GetSymbolSwapSizeShort(string symbolsInfo)
        {
            var symbolInfos = FdkVars.GetValue<SymbolInfo[]>(symbolsInfo);
            return symbolInfos.Select(b => b.SwapSizeShort ?? 0.0).ToArray();
        }
    }
}

