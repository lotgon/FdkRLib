
#' Gets the quotes history
#' 
#' @param symbol Symbol looked
#' @export
ttQuotesRealTime <- function(symbol){
  quotesHistory <- RealTimeComputeQuoteHistory(symbol)
  
  ask <- RealTimeQuotesAsk(quotesHistory)
  bid <- RealTimeQuotesBid(quotesHistory)
  createTime <- RealTimeQuotesCreatingTime(quotesHistory)
  spread <- QuotesCreatingTime(RealTimeQuotesSpread)
  UnregisterVar(quotesHistory)
  
  df = data.frame(ask=ask, bid=bid, createTime=createTime, spread = spread)
}

# ****
#' Gets the quotes as requested
#' 
#' @param symbol Symbol looked
RealTimeComputeQuoteHistory <- function(symbol) {
  rClr::clrCallStatic('RHost.FdkQuotesRealTime', 'MonitorSymbol', symbol)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesAsk <- function(quotesVar) {
  rClr::clrCallStatic('RHost.FdkRealTime', 'QuoteArrayAsk', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesBid <- function(quotesVar) {
  rClr::clrCallStatic('RHost.FdkRealTime', 'QuoteArrayBid', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesCreatingTime <- function(quotesVar) {
  rClr::clrCallStatic('RHost.FdkRealTime', 'QuoteArrayCreateTime', quotesVar)
}
#' Gets the quotes' spread as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
RealTimeQuotesSpread <- function(quotesVar) {
  rClr::clrCallStatic('RHost.FdkRealTime', 'QuoteArraySpread', quotesVar)
}
