
#' Gets the quotes history
#' 
#' @param symbol Symbol looked
#' @param startTime Starting time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param endTime Ending time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param depth Quotes depth
#' @export
ttQuotesRealTime <- function(symbol){
  quotesHistory <- ComputeQuoteHistory(symbol,startTime, endTime, depth)
  
  ask <- RealTimeQuotesAsk(quotesHistory)
  bid <- RealTimeQuotesBid(quotesHistory)
  createTime <- QuotesCreatingTime(quotesHistory)
  UnregisterVar(quotesHistory)
  df = data.frame(ask=ask, bid=bid, createTime=createTime)       
}

# ****
#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param startTimeEpoch Starting time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param endTimeEpoch Ending time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param depth Quotes depth
ComputeQuoteHistory <- function(symbol, startTime, endTime, depth) {
  clrCallStatic('RHost.FdkQuotes', 'ComputeQuoteHistory', symbol, startTime, endTime, depth)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesAsk <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesAsk', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesBid <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesBid', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesCreatingTime <- function(id) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesCreatingTime', quotesVar)
}
#' Gets the quotes' spread as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesSpread <- function(id) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesSpread', quotesVar)
}
