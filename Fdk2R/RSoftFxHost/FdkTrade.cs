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
        
        public static string[] GetTradeComment(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Comment).ToArray();
        }

        public static DateTime[] GetTradeCreated(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Created??new DateTime()).ToArray();
        }

        public static DataTrade[] GetTradeData(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.DataTrade).ToArray();
        }

        public static DateTime[] GetTradeExpiration(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Expiration ?? new DateTime()).ToArray();
        }

        public static double[] GetTradeInitialVolume(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.InitialVolume).ToArray();
        }

        public static bool[] GetTradeIsLimitOrder(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.IsLimitOrder).ToArray();
        }

        public static bool[] GetTradeIsPendingOrder(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.IsPendingOrder).ToArray();
        }


        public static bool[] GetTradeIsPosition(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.IsPosition).ToArray();
        }
        public static bool[] GetTradeIsStopOrder(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.IsStopOrder).ToArray();
        }

        public static DateTime[] GetTradeModified(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Modified ?? new DateTime()).ToArray();
        }
        public static string[] GetTradeOrderId(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.OrderId).ToArray();
        }

        public static double[] GetTradePrice(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Price).ToArray();
        }
        public static double[] GetTradeProfit(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Profit??0.0).ToArray();
        }
        public static string[] GetTradeSide(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Side.ToString()).ToArray();
        }
        public static double[] GetTradeStopLoss(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.StopLoss??0).ToArray();
        }
        public static double[] GetTradeSwap(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Swap).ToArray();
        }
        public static double[] GetTradeTakeProfit(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.TakeProfit ?? 0.0).ToArray();
        }
        public static string[] GetTradeType(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Type.ToString()).ToArray();
        }

        public static double[] GetTradeVolume(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Volume).ToArray();
        }

    }
}
