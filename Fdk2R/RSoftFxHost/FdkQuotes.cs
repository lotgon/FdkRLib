using System;
using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    public class FdkQuotes
    {
        public static string ComputeQuoteHistory(string symbol, DateTime startTime, DateTime endTime, double depthDbl)
        {   
            var depth = (int)depthDbl;
            var quotesData = CalculateHistoryForSymbolArray(symbol, startTime, endTime, depth);
            var quoteHistory = FdkVars.RegisterVariable(quotesData, "quotes");
            return quoteHistory;
        }

        internal static Quote[] CalculateHistoryForSymbolArray(string symbol, DateTime startTime, DateTime endTime, int depth)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetQuotes(symbol, startTime, endTime, depth);
        }

        public static double[] QuotesAsk(string bars)
        {
            var quotes = FdkVars.GetValue<Quote[]>(bars);
            return quotes.Select(b => b.HasAsk? b.Ask : -1).ToArray();
        }
        public static double[] QuotesBid(string bars)
        {
            var quotes = FdkVars.GetValue<Quote[]>(bars);
            return quotes.Select(b => b.HasBid? b.Bid:-1).ToArray();
        }
        public static DateTime[] QuotesCreatingTime(string bars)
        {
            var quotes = FdkVars.GetValue<Quote[]>(bars);

            var timesAsEpoch = quotes.Select(b =>b.CreatingTime).ToArray();
            return timesAsEpoch;
        }
        public static double[] QuotesSpread(string bars)
        {
            var quotes = FdkVars.GetValue<Quote[]>(bars);
            return quotes.Select(b => b.Spread).ToArray();
        }

    }
}