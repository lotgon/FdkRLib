using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedFdkFunctionality;
using SoftFX.Extended;

namespace RHost
{
    public class FdkTrade
    {
        private static DataTrade Trade
        {
            get { return FdkHelper.Wrapper.ConnectLogic.TradeWrapper.Trade; }
        }

        public static string GetTradeRecords()
        {
            var tradeRecords = Trade.Server.GetTradeRecords();
            var varName = FdkVars.RegisterVariable(tradeRecords, "trades");
            return varName;
        }

        public static AccountInfo GetAccountInfo()
        {
            return Trade.Server.GetAccountInfo();
        }

        public static TradeRecord SendOrder(string symbol, string tradeCommandStr, string sideStr, double price, double volume, double stopLoss, double takeProfit, DateTime expiration, string comment)
        {
            var tradeCommand = FdkHelper.GetFieldByName<TradeCommand>(tradeCommandStr);
            var tradeSide = FdkHelper.GetFieldByName<TradeRecordSide>(sideStr);

            return Trade.Server.SendOrder(symbol, tradeCommand, tradeSide, price, volume, stopLoss,takeProfit, expiration, comment);
        }

        public static double[] GetTradeAgentCommission(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.AgentCommission).ToArray();
        }

        public static string[] GetTradeClientOrderId(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.ClientOrderId).ToArray();
        }

    }
}
