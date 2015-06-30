using System;
using System.Collections.Generic;
using System.Linq;

namespace RHost
{
    struct QuoteLevel2Data
    {
        public double AsksPrice { get; set; }
        public double AskVolume { get; set; }
        public double BidPrice { get; set; }
        public double BidVolume { get; set; }
        public DateTime CreateTime { get; set; }
        public double IndexOrder { get; set; }
    }
    public class FdkLevel2
    {
        /// <summary>
        /// Get quote packed 
        /// </summary>
        /// <param name="symbol">Symbol to get quotes on</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="levelDbl"></param>
        /// <returns></returns>
        public static string GetQuotePacked(string symbol, DateTime startTime, DateTime endTime, double levelDbl = 2)
        {
            var level = (int) levelDbl;
            var quotesData = FdkQuotes.CalculateHistoryForSymbolArray(symbol, startTime, endTime, level);
            var itemsToAdd = new List<QuoteLevel2Data>();
            var prevTime = new DateTime(1970, 1, 1);
            var indexOrder = 0;

            foreach (var quote in quotesData)
            {
                if (prevTime == quote.CreatingTime)
                {
                    indexOrder++;
                }
                else
                {
                    indexOrder = 0;
                }
                var timeSpan = quote.CreatingTime.Subtract(prevTime).Milliseconds;
                
                for (var index = 0; index < quote.Asks.Length; index++)
                {
                    var quoteEntryAsk = quote.Asks[index];
                    var quoteEntryBid = quote.Bids[index];
                    
                    var newQuoteL2Data = new QuoteLevel2Data()
                    {
                        AskVolume = quoteEntryAsk.Volume,
                        AsksPrice = quoteEntryAsk.Price,
                        BidVolume = quoteEntryBid.Volume,
                        BidPrice = quoteEntryBid.Price,
                        CreateTime = quote.CreatingTime,
                        IndexOrder = timeSpan + indexOrder/100.0
                    };
                    itemsToAdd.Add(newQuoteL2Data);
                }
                prevTime = quote.CreatingTime;
            }

            var quoteLevel2Data = itemsToAdd.ToArray();

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

        public static double[] QuotesIndex(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);

            return quotes.Select(q => q.IndexOrder).ToArray();
        }
    }
}