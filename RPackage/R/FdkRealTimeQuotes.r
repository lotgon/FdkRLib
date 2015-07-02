
#' Gets the quotes history
#' 
#' @param symbol Symbol looked
#' @export
ttQuotesRealTime <- function(symbol){
  quotesHistory <- RealTimeComputeQuoteHistory(symbol)
  
  ask <- RealTimeQuotesAsk(quotesHistory)
  bid <- RealTimeQuotesBid(quotesHistory)
  createTime <- QuotesCreatingTime(quotesHistory)
  UnregisterVar(quotesHistory)
  df = data.frame(ask=ask, bid=bid, createTime=createTime)       
}

# ****
#' Gets the quotes as requested
#' 
#' @param symbol Symbol looked
RealTimeComputeQuoteHistory <- function(symbol) {
  rClr::clrCallStatic('RHost.FdkQuotesRealTime', 'ComputeQuoteHistory', symbol)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesAsk <- function(quotesVar) {
  rClr::clrCallStatic('RHost.FdkQuotes', 'QuotesAsk', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesBid <- function(quotesVar) {
  rClr::clrCallStatic('RHost.FdkQuotes', 'QuotesBid', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesCreatingTime <- function(quotesVar) {
  rClr::clrCallStatic('RHost.FdkQuotes', 'QuotesCreatingTime', quotesVar)
}
#' Gets the quotes' spread as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesSpread <- function(quotesVar) {
  rClr::clrCallStatic('RHost.FdkQuotes', 'QuotesSpread', quotesVar)
}
