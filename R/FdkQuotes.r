
# ****
#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param startTimeEpoch Starting time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param endTimeEpoch Ending time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param depth Quotes depth
ComputeQuoteHistory <- function(symbol, startTimeEpoch, endTimeEpoch, depth) {
  clrCallStatic('RHost.FdkQuotes', 'ComputeQuoteHistory', symbol, startTimeEpoch, endTimeEpoch, depth)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesAsk <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesAsk', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesBid <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesBid', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesCreatingTime <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesCreatingTime', quotesVar)
}
#' Gets the quotes' spread as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesSpread <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesSpread', quotesVar)
}
#' Gets the quotes' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesHasAsk <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesHasAsk', quotesVar)
}
#' Gets the quotes' bid as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesHasBid <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesHasBid', quotesVar)
}

#' Sets the bar count inside calls
#' 
#' @param barCount Set a different bar count than the default (1 million)
#' @export
ttSetBarCount <- function(barCount) {
  clrCallStatic('RHost.FdkBars', 'SetBarCount', barCount)
}
#' Gets the bar count used in calls
#' 
#' @export
ttGetBarCount <- function() {
  clrCallStatic('RHost.FdkBars', 'GetBarCount')
}



#' Gets the quotes history
#' 
#' @param symbol Symbol looked
#' @param startTimeEpoch Starting time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param endTimeEpoch Ending time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param depth Quotes depth
#' @export

ttGetQuotes <- function(symbol,startTimeEpoch, endTimeEpoch, depth){
  symbolBars <- ComputeQuoteHistory(symbol,startTimeEpoch, endTimeEpoch, depth)
  
  ask <- QuotesAsk(symbolBars)
  bid <- QuotesBid(symbolBars)
  createTime <- QuotesCreatingTime(symbolBars)
  hasAsk <- QuotesHasAsk(symbolBars)
  hasBid <- QuotesHasBid(symbolBars)
  UnregisterVar(symbolBars)
  df = data.frame(ask, bid, createTime, hasAsk, hasBid)       
}
