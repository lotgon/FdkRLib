#' Monitor a symbol
#' 
#' @param symbol Symbol looked
#' @export
ttQuotesRealTimeMonitor<- function(symbol){
  quotesHistory <- RealTimeComputeQuoteHistory(symbol)
}

#' Get a snapshot of current monitoring status
#' 
#' @param idMonitoring Id of monitoring session
#' @export
ttQuotesRealTimeSnapshot <- function(idMonitoring){
  snapshot <- SnapshotMonitoredSymbol(idMonitoring)
  
  ask <- RealTimeQuotesAsk(snapshot)
  bid <- RealTimeQuotesBid(snapshot)
  createTime <- RealTimeQuotesCreatingTime(snapshot)
  spread <- QuotesCreatingTime(snapshot)
  
  UnregisterVar(quotesHistory)
  
  df = data.frame(ask=ask, bid=bid, createTime=createTime, spread = spread)
}

#' Monitor a symbol
#' 
#' @param idMonitoring Id of monitoring session
#' @export
ttQuotesRealTimeStopMonitoring <- function(idMonitoring){
  RealTimeRemoveEvent(idMonitoring)
}

# ****
#' Gets the quotes as requested
#' 
#' @param symbol Symbol looked
RealTimeComputeQuoteHistory <- function(symbol) {
  rClr::clrCallStatic('RHost.FdkQuotesRealTime', 'MonitorSymbol', symbol)
}

# ****
#' Gets the a snapshot based on the monitoring Id
#' 
#' @param idMonitoring Id of monitoring session
SnapshotMonitoredSymbol <- function(idMonitoring) {
  rClr::clrCallStatic('RHost.FdkQuotesRealTime', 'SnapshotMonitoredSymbol', idMonitoring)
}


# ****
#' Remove monitoring id
#' 
#' @param idMonitoring Id of monitoring session
RealTimeRemoveEvent <- function(idMonitoring) {
  rClr::clrCallStatic('RHost.FdkQuotesRealTime', 'RemoveEvent', idMonitoring)
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
