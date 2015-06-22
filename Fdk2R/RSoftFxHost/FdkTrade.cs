﻿using System;
using System.Collections.Generic;
using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    public static class FdkTrade
    {
        private static DataTrade Trade
        {
            get { return FdkHelper.Wrapper.ConnectLogic.TradeWrapper.Trade; }
        }

        public static string GetTradeRecords(string tradeSideStr, string tradeTypeStr)
        {
            var tradeRecords = Trade.Server.GetTradeRecords();
            if (!string.IsNullOrEmpty(tradeSideStr))
            {
                var tradeSide = FdkHelper.ParseEnumStr<TradeRecordSide>(tradeSideStr);
                tradeRecords = tradeRecords.Where(tr => tr.Side == tradeSide).ToArray();
            }
            if (!string.IsNullOrEmpty(tradeSideStr))
            {
                var tradeType = FdkHelper.ParseEnumStr<TradeRecordType>(tradeTypeStr);
                tradeRecords = tradeRecords.Where(tr => tr.Type == tradeType).ToArray();
            }
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
            return tradeData.Select(it => it.Created).ExposeDatesNull();
        }


        public static DateTime[] GetTradeExpiration(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.Expiration).ExposeDatesNull();
        }

        public static double[] GetTradeInitialVolume(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.InitialVolume).ToArray();
        }

        public static string[] GetTradeIsLimitOrder(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.IsLimitOrder.ToText()).ToArray();
        }

        public static string[] GetTradeIsPendingOrder(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.IsPendingOrder.ToText()).ToArray();
        }


        public static string[] GetTradeIsPosition(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.IsPosition.ToText()).ToArray();
        }
        public static string[] GetTradeIsStopOrder(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.Select(it => it.IsStopOrder.ToText()).ToArray();
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

        public static string ToText(this bool val)
        {
            return val ? "True" : "False";
        }

        private static DateTime[] ExposeDatesNull(this IEnumerable<DateTime?> values)
        {
            return values.Select(val => (val??new DateTime(1970,1,1))).ToArray();
        }
    }
}
