using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using SoftFX.Extended;

namespace RHost
{
	class QuoteLevel2Data
	{
		public double AsksPrice { get; set; }
		public double AskVolume { get; set; }
		public double BidPrice { get; set; }
		public double BidVolume { get; set; }
		public DateTime CreateTime { get; set; }
		public double IndexOrder { get; set; }
		public int Level { get; set; }

		public override string ToString()
		{
			return string.Format("[QuoteLevel2Data AsksPrice={0}, BidPrice={1}]", AsksPrice, BidPrice);
		}
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
			try
			{
				var level = (int) levelDbl;

				Quote[] quotesData = FdkQuotes.CalculateHistoryForSymbolArray(symbol, startTime, endTime, level);
				var quoteLevel2Data = BuildQuoteMultiLevelData(quotesData, level);

				var quoteHistory = FdkVars.RegisterVariable(quoteLevel2Data, "quotesL2");
            	return quoteHistory;
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw;
			}
        }
        static readonly Logger Log = LogManager.GetCurrentClassLogger();

		static QuoteLevel2Data[] BuildQuoteMultiLevelData(Quote[] quotesData, int depth)
		{
			var itemsToAdd = new List<QuoteLevel2Data>(capacity: quotesData.Length*depth);
			var prevTime = new DateTime(1970, 1, 1);
			var indexOrder = 0;
			foreach (var quote in quotesData) {
				if (prevTime == quote.CreatingTime) {
					indexOrder++;
				} else {
					indexOrder = 0;
				}
				var timeSpan = quote.CreatingTime.Subtract(prevTime).TotalMilliseconds;
				if(depth != quote.Asks.Length)
				{
					throw new InvalidOperationException(
						string.Format(
							"Invalid number of quotes. Expected: {0}, but actual: {1}",
							depth, 
							quote.Asks.Length));
				}	
				if(depth != quote.Bids.Length)
				{
					throw new InvalidOperationException(
						string.Format(
							"Invalid number of quotes. Expected: {0}, but actual: {1}",
							depth, 
							quote.Asks.Length));
				}
				for (var index = 0; index < depth; index++) {
					var quoteEntryAsk = quote.Asks[index];
					var quoteEntryBid = quote.Bids[index];
					var newQuoteL2Data = new QuoteLevel2Data() {
						AskVolume = quoteEntryAsk.Volume,
						AsksPrice = quoteEntryAsk.Price,
						BidVolume = quoteEntryBid.Volume,
						BidPrice = quoteEntryBid.Price,
						CreateTime = quote.CreatingTime,
						IndexOrder = timeSpan + indexOrder / 100.0,
						Level = index+1
					};
					itemsToAdd.Add(newQuoteL2Data);
				}
			}
			QuoteLevel2Data[] quoteLevel2Data = itemsToAdd.ToArray();
			return quoteLevel2Data;
		}
        public static DateTime[] QuotesCreateTime(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);
            return quotes.SelectToArray(ql2=>ql2.CreateTime);
        }

        public static double[] QuotesVolumeAsk(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);
            return quotes.SelectToArray(q => q.AskVolume);
        }
        public static double[] QuotesVolumeBid(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);
            return quotes.SelectToArray(q=>q.BidVolume);
        }

        public static double[] QuotesPriceAsk(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars); 
            return quotes.SelectToArray(q => q.AsksPrice);
        }

        public static double[] QuotesPriceBid(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);

            return quotes.SelectToArray(q => q.BidPrice);
        }

        public static double[] QuotesIndex(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);

            return quotes.SelectToArray(q => q.IndexOrder);
        }

        public static double[] QuotesLevel(string bars)
        {
            var quotes = FdkVars.GetValue<QuoteLevel2Data[]>(bars);

            return quotes.SelectToArray(q => (double)q.Level);
        }
    }
}