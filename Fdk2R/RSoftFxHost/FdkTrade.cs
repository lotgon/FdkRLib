﻿using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using SoftFX.Extended;

namespace RHost
{
	public static class FdkTrade
	{
		private static DataTrade Trade
		{
			get { return FdkHelper.Wrapper.ConnectLogic.TradeWrapper.Trade; }
		}

		public static string GetTradeRecords(DateTime startTime, DateTime endTime)
		{
			try
			{
				var tradeRecords = Trade.Server.GetTradeRecords()
                    .Where(tr=>tr.Created!= null && (tr.Created >= startTime && tr.Created <= endTime))
                    .ToArray();
				
				Log.Info("FdkTrade.GetTradeRecords( start: {0}, end: {1}",
					startTime, endTime);
				
				var varName = FdkVars.RegisterVariable(tradeRecords, "trades");
				return varName;
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw;
			}     
        }
        static readonly Logger Log = LogManager.GetCurrentClassLogger();

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
            return tradeData.SelectToArray(it => it.AgentCommission);
        }

        public static string[] GetTradeClientOrderId(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.ClientOrderId);
        }
        
        public static string[] GetTradeComment(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.Comment);
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
            return tradeData.SelectToArray(it => it.InitialVolume);
        }

        public static string[] GetTradeIsLimitOrder(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.IsLimitOrder.ToText());
        }

        public static string[] GetTradeIsPendingOrder(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.IsPendingOrder.ToText());
        }


        public static string[] GetTradeIsPosition(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.IsPosition.ToText());
        }
        public static string[] GetTradeIsStopOrder(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.IsStopOrder.ToText());
        }

        public static DateTime[] GetTradeModified(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
			return tradeData.SelectToArray(it => it.Modified).ExposeDatesNull();
        }
        public static string[] GetTradeOrderId(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.OrderId);
        }

        public static double[] GetTradePrice(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.Price);
        }
        public static double[] GetTradeProfit(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.Profit??0.0);
        }
        public static string[] GetTradeSide(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.Side.ToString());
        }
        public static double[] GetTradeStopLoss(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.StopLoss??0);
        }
        public static double[] GetTradeSwap(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.Swap);
        }
        public static double[] GetTradeTakeProfit(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.TakeProfit ?? 0.0);
        }
        public static string[] GetTradeType(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.Type.ToString());
        }

        public static double[] GetTradeVolume(string varName)
        {
            var tradeData = FdkVars.GetValue<TradeRecord[]>(varName);
            return tradeData.SelectToArray(it => it.Volume);
        }

        public static string ToText(this bool val)
        {
            return val ? "True" : "False";
        }

		public static DateTime[] ExposeDatesNull(this IEnumerable<DateTime?> values)
        {
			return values.Select(val => (val ?? new DateTime(1970, 1, 1)).AddUtc()).ToArray();
        }
    }
}
