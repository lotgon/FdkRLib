using System;
using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    public class FdkQuotes
    {
        public static string ComputeQuoteHistory(string symbol, string startTimeStr, string endTimeStr, double depthDbl)
        {
            DateTime startTime;
            if (!DateTime.TryParse(startTimeStr, out startTime))
            {
                return String.Empty;
            }
            DateTime endTime;
            if (!DateTime.TryParse(endTimeStr, out endTime))
            {
                return String.Empty;
            }
            int depth = (int)depthDbl;

            var quotesData = CalculateHistoryForSymbolArray(symbol, startTime, endTime, depth);
            var quoteHistory = FdkVars.RegisterVariable(quotesData, "quotes");
            return quoteHistory;
        }

        private static Quote[] CalculateHistoryForSymbolArray(string symbol, DateTime startTime, DateTime endTime, int depth)
        {
            return FdkHelper.Wrapper.ConnectLogic.Storage.Online.GetQuotes(symbol, startTime, endTime, depth);
        }

        public static double[] QuotesAsk(string bars)
        {
            var barData = FdkVars.GetValue<Quote[]>(bars);

            return barData.Select(b => b.Ask).ToArray();
        }
        public static double[] QuotesBid(string bars)
        {
            var barData = FdkVars.GetValue<Quote[]>(bars);

            return barData.Select(b => b.Bid).ToArray();
        }
        public static string[] QuotesCreatingTime(string bars)
        {
            var barData = FdkVars.GetValue<Quote[]>(bars);

            return barData.Select(b => b.CreatingTime.ToString()).ToArray();
        }
        public static double[] QuotesSpread(string bars)
        {
            var barData = FdkVars.GetValue<Quote[]>(bars);

            return barData.Select(b => b.Spread).ToArray();
        }
        public static int[] QuotesHasAsk(string bars)
        {
            var barData = FdkVars.GetValue<Quote[]>(bars);

            return barData.Select(b => b.HasAsk?1:0).ToArray();
        }
        public static int[] QuotesHasBid(string bars)
        {
            var barData = FdkVars.GetValue<Quote[]>(bars);

            return barData.Select(b => b.HasBid ? 1 : 0).ToArray();
        }
    }
}