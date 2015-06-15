
#' Gets the quotes history
#' 
#' @param symbol Symbol looked
#' @param startTime Starting time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param endTime Ending time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param depth Quotes depth
#' @export
ttQuotes <- function(symbol,startTime= ttTimeZero() , endTime, depth=1){
  quotesHistory <- ComputeQuoteHistory(symbol,startTime, endTime, depth)
  
  ask <- QuotesAsk(quotesHistory)
  bid <- QuotesBid(quotesHistory)
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

#' Gets the bar count used in calls
#' 
#' @export
ttGetBarCount <- function() {
  clrCallStatic('RHost.FdkBars', 'GetBarCount')
}
#' Gets the bars' volume as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesVolume <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesVolume', quotesVar)
}