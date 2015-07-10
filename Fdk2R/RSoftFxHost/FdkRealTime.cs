using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using SoftFX.Extended;
using SoftFX.Extended.Events;

namespace RHost
{
    public static class FdkRealTime
	{
		static readonly
            List<FdkRealTimeMonitor> Monitors
                = new List<FdkRealTimeMonitor>();

		private static int _eventCount;
		public static double MonitorSymbol(string symbol, double levelDbl)
		{
			try
			{
                var level = (int)levelDbl;
				Monitors.Add(new FdkRealTimeMonitor(symbol, level, DateTime.UtcNow, _eventCount));
				double result = _eventCount;
				_eventCount++;
				StartMonitoringOfSymbolIfNotEnabled(symbol, level);

				return result;
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw;
			}
		}
        static readonly Logger Log = LogManager.GetCurrentClassLogger();

		public static string SnapshotMonitoredSymbol(double id)
		{
			try
			{
				var quotes = BuildSnapshotFromMonitor(id);
				var resultVarName = FdkVars.RegisterVariable(quotes, "rt_quotes_snapshot");
				return resultVarName;
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw;
			}
		}

        static void StartMonitoringOfSymbolIfNotEnabled(string symbol, int level)
        {
			if (IsMonitoringStarted)
				return;
			IsMonitoringStarted = true;
            Feed.Server.SubscribeToQuotes(new[] { symbol }, level);
			Feed.Tick += OnTick;
		}

		static void OnTick(object sender, TickEventArgs e)
		{
			var tickSymbol = e.Tick.Symbol;
			foreach (var evnt in Monitors)
			{
				if (evnt.Symbol != tickSymbol)
					continue;
				evnt.LastEventData = (e);
			}
		}

		public static void RemoveEvent(double eventIndex)
		{
			try
			{
				var intIndex = (int)eventIndex;
				Monitors.RemoveAll(ev => ev.Id == intIndex);
				if(Monitors.Count == 0)
				{
					Feed.Tick -= OnTick;
					IsMonitoringStarted = false;
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw;
			}     
        }
        
        static DataFeed Feed
        {
            get { return FdkHelper.Wrapper.ConnectLogic.Feed; }
        }

        public static bool IsMonitoringStarted { get; set; }

        public static string[] SymbolsMonitored()
        {
        	return Monitors.Select(evItem => evItem.Symbol).ToArray();
        }

        public static FdkRealTimeMonitor GetEventById(double eventIndex)
        {
            var intIndex = (int)eventIndex;
            return Monitors.FirstOrDefault(ev => ev.Id == intIndex);
        }

        public static double[] EventIds()
        {
        	return Monitors.Select(evItem => (double)evItem.Id).ToArray();
        }
        
        static FdkRealTimeQuote[] BuildSnapshotFromMonitor(double id)
        {
            var eventData = GetEventById(id);
            var quotes = eventData.BuildSnapshot();
            return quotes;
        }

        public static string GetLocalQuoteSnapshot(double id)
        {
            var quotes = BuildSnapshotFromMonitor(id);           
            string result = FdkVars.RegisterVariable(quotes, "localSnapshot");
            return result;
        }

        public static double[] QuoteRealTimeBidPrice(string snapshotName)
        {
			var quotes = FdkVars.GetValue<FdkRealTimeQuote[]>(snapshotName);
			return quotes.SelectToArray(bid=>bid.BidPrice);
        }

		public static double[] QuoteRealTimeBidVolume(string snapshotName)
		{
			var quotes = FdkVars.GetValue<FdkRealTimeQuote[]>(snapshotName);
			return quotes.SelectToArray(bid=>bid.BidVolume);
		}

		public static double[] QuoteRealTimeAskPrice(string snapshotName)
		{
			var quotes = FdkVars.GetValue<FdkRealTimeQuote[]>(snapshotName);
			return quotes.SelectToArray(bid=>bid.AskPrice);
		}

		public static double[] QuoteRealTimeAskVolume(string snapshotName)
		{
			var quotes = FdkVars.GetValue<FdkRealTimeQuote[]>(snapshotName);
			return quotes.SelectToArray(bid=>bid.AskVolume);
		}

        public static DateTime[] QuoteRealTimeReceivingTime(string snapshotName)
        {
            var quotes = FdkVars.GetValue<FdkRealTimeQuote[]>(snapshotName);
            return quotes.SelectToArray(bid => bid.ReceivingTime);
        }


    }
}
