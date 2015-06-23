using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftFX.Extended;
using SoftFX.Extended.Events;

namespace RHost
{
    public class FdkRealTimeItem
    {
        public int Id { get; private set; }

        public FdkRealTimeItem(string symbol, DateTime utcNow, int id)
        {
            Id = id;
            Symbol = symbol;
            TimeToMonitor = utcNow;
            Events = new List<TickEventArgs>();
        }

        public string Symbol { get; set; }
        public DateTime TimeToMonitor { get; set; }
        public List<TickEventArgs> Events { get; set; }
    }
    public static class FdkRealTime
    {
        static readonly
            List<FdkRealTimeItem> Events
                = new List<FdkRealTimeItem>();

        private static int _eventCount;
        public static double MonitorSymbol(string symbol)
        {
            Events.Add(new FdkRealTimeItem(symbol, DateTime.UtcNow, _eventCount));
            double result = _eventCount;
            _eventCount++;
            StartMonitoringOfSymbolIfNotEnabled();

            return result;
        }

        private static void StartMonitoringOfSymbolIfNotEnabled()
        {
            if (IsMonitoringStarted)
                return;
            IsMonitoringStarted = true;
            Feed.Tick += OnTick;

        }

        private static void OnTick(object sender, TickEventArgs e)
        {
            var tickSymbol = e.Tick.Symbol;
            foreach (var evnt in Events)
            {
                if (evnt.Symbol != tickSymbol)
                    continue;
                evnt.Events.Add(e);
            }
        }

        private static void RemoveEvent(double eventIndex)
        {
            var intIndex = (int)eventIndex;
            Events.RemoveAll(ev => ev.Id == intIndex);
        }

        private static DataFeed Feed
        {
            get { return FdkHelper.Wrapper.ConnectLogic.Feed; }
        }

        public static bool IsMonitoringStarted { get; set; }

        public static string[] SymbolsMonitored()
        {
            return Events.Select(evItem => evItem.Symbol).ToArray();
        }

        public static FdkRealTimeItem GetEventById(double eventIndex)
        {
            var intIndex = (int)eventIndex;
            return Events.FirstOrDefault(ev => ev.Id == intIndex);
        }

        public static double[] EventIds()
        {
            return Events.Select(evItem => (double)evItem.Id).ToArray();
        }

        public static double[] QuotesSpread(double id)
        {
            var quotes = GetQuotesById(id);
            return  FdkQuotes.QuoteArraySpread(quotes);
        }

        private static Quote[] GetQuotesById(double id)
        {
            var eventData = GetEventById(id);
            var quotes = eventData.Events.Select(evnt => evnt.Tick).ToArray();
            return quotes;
        }

        public static string GetLocalQuoteSnapshot(double id)
        {
            var quotes = GetQuotesById(id);
           
            string result = FdkVars.RegisterVariable(quotes, "localSnapshot");

            return result;
        }

        public static double[] QuoteArrayBid(double id)
        {
            var quotes = GetQuotesById(id);
            return FdkQuotes.QuoteArrayBid(quotes);
        }

        public static double[] QuoteArrayAsk(double id)
        {
            var quotes = GetQuotesById(id);
            return FdkQuotes.QuoteArrayAsk(quotes);
        }

        public static DateTime[] QuoteArrayCreateTime(double id)
        {
            var quotes = GetQuotesById(id);
            return FdkQuotes.QuoteArrayCreateTime(quotes);
        }

        public static double[] QuoteArraySpread(double id)
        {
            var quotes = GetQuotesById(id);
            return FdkQuotes.QuoteArraySpread(quotes);
        }

    }
}
