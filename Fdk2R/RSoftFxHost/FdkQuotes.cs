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
            return QuoteArrayAsk(quotes);
        }

        public static double[] QuotesBid(string bars)
        {
            var quotes = FdkVars.GetValue<Quote[]>(bars);
            return QuoteArrayBid(quotes);
        }
        public static DateTime[] QuotesCreatingTime(string bars)
        {
            var quotes = FdkVars.GetValue<Quote[]>(bars);

            return QuoteArrayCreateTime(quotes);
        }

        public static double[] QuotesSpread(string bars)
        {
            var quotes = FdkVars.GetValue<Quote[]>(bars);
            return QuoteArraySpread(quotes);
        }

        internal static double[] QuoteArrayBid(Quote[] quotes)
        {
            return quotes.Select(b => b.HasBid ? b.Bid : -1).ToArray();
        }


        internal static double[] QuoteArrayAsk(Quote[] quotes)
        {
            return quotes.Select(b => b.HasAsk ? b.Ask : -1).ToArray();
        }

        internal static DateTime[] QuoteArrayCreateTime(Quote[] quotes)
        {
            var timesAsEpoch = quotes.Select(b => b.CreatingTime).ToArray();
            return timesAsEpoch;
        }

        internal static double[] QuoteArraySpread(Quote[] quotes)
        {
            return quotes.Select(b => b.Spread).ToArray();
        }
    }
}