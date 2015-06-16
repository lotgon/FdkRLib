using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using SoftFX.Extended;

namespace RHost
{
    struct QuoteLevel2Data
    {
        public double AsksPrice { get; set; }
        public double AskVolume { get; set; }
        public double BidPrice { get; set; }
        public double BidVolume { get; set; }
        public DateTime CreateTime { get; set; }
    }
    public class FdkLevel2
    {
        public static string GetQuotePacked(string symbol, DateTime startTime, DateTime endTime, double levelDbl = 2)
        {
            var level = (int) levelDbl;
            var quotesData = FdkQuotes.CalculateHistoryForSymbolArray(symbol, startTime, endTime, level);
            var itemsToAdd = new List<QuoteLevel2Data>();
            foreach (var quote in quotesData)
            {
                for (int index = 0; index < quote.Asks.Length; index++)
                {
                    var quoteEntryAsk = quote.Asks[index];
                    var quoteEntryBid = quote.Bids[index];

                    var newQuoteL2Data = new QuoteLevel2Data()
                    {
                        AskVolume = quoteEntryAsk.Volume,
                        AsksPrice = quoteEntryAsk.Price,
                        BidVolume = quoteEntryBid.Volume,
                        BidPrice = quoteEntryBid.Price,
                        CreateTime = quote.CreatingTime
                    };
                    itemsToAdd.Add(newQuoteL2Data);
                }
            }

            QuoteLevel2Data[] quoteLevel2Data = itemsToAdd.ToArray();

            var quoteHistory = FdkVars.RegisterVariable(quoteLevel2Data, "quotesL2");
            return quoteHistory;
        }

        public static DateTime[] QuotesCreateTime(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);
            return quotes.Select(ql2=>ql2.CreateTime).ToArray();
        }

        public static double[] QuotesVolumeAsk(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);
            return quotes.Select(q => q.AskVolume).ToArray();
        }
        public static double[] QuotesVolumeBid(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);
            return quotes.Select(q=>q.BidVolume).ToArray();
        }

        public static double[] QuotesPriceAsk(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars); 
            return quotes.Select(q => q.AsksPrice).ToArray();
        }
        public static double[] QuotesPriceBid(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);

            return quotes.Select(q => q.BidPrice).ToArray();
        }
    }
}