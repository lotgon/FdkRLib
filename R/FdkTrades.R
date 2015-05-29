#' Gets the account trades
#' 
#' @export
ttTrades <- function(){
  symInfo = GetTradeRecords()
  
  comission = GetTradeAgentCommission(symInfo)
  
  UnregisterVar(symInfo)
  
  data.frame(currency, description, precision, sortOrder)
}
#' Get symbol field
GetTradeRecords <- function() {
  clrCallStatic('RHost.FdkTrade', 'GetTradeRecords')
}
#' Get symbol field
GetTradeAgentCommission <- function(symInfo) {
  clrCallStatic('RHost.FdkTrade', 'GetTradeAgentCommission', symInfo)
}
