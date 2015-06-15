using System;
using System.Linq;
using SoftFX.Extended;

namespace RHost
{
    struct QuoteLevel2Data
    {
        public QuoteEntry[] Asks { get; set; }
        public QuoteEntry[] Bids { get; set; }
        public DateTime CreateTime { get; set; }
    }
    public class FdkLevel2
    {
        public static string GetQuotePacked(string symbol, DateTime startTime, DateTime endTime)
        {
            var quotesData =FdkQuotes.CalculateHistoryForSymbolArray(symbol, startTime, endTime, 2);

            QuoteLevel2Data[] quoteLevel2Data = quotesData.Select(quote => new QuoteLevel2Data()
            {
                Asks = quote.Asks,
                Bids = quote.Bids,
                CreateTime = quote.CreatingTime
            }).ToArray();

            var quoteHistory = FdkVars.RegisterVariable(quoteLevel2Data, "quotesL2");
            return quoteHistory;
        }

        public static DateTime[] QuotesCreateTime(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);
            return quotes.Select(ql2=>ql2.CreateTime).ToArray();
        }

        public static double[][] QuotesVolumeAsk(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);
            return quotes.Select(CalculateVolumeAsk).ToArray();
        }
        public static double[][] QuotesVolumeBid(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);
            return quotes.Select(CalculateVolumeBid).ToArray();
        }

        private static double[] CalculateVolumeBid(QuoteLevel2Data b)
        {
            return b.Bids.Select(bid=>bid.Volume).ToArray();
        }
        private static double[] CalculateVolumeAsk(QuoteLevel2Data b)
        {
            return b.Asks.Select(ask => ask.Volume).ToArray();
        }
    }
}