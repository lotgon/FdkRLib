#' Gets the account trades
#' 
#' @export
ttTradesHistory <- function(){
  symInfo = GetTradeHistory()
  
  agentComission = GetTradeAgentCommission(symInfo)
  tradeClientOrderId = GetTradeClientOrderId(symInfo)
  tradeComment = GetTradeComment(symInfo)
  created = GetTradeCreated(symInfo)
  expiration = GetTradeExpiration(symInfo)
  initialVolume = GetTradeInitialVolume(symInfo)
  symbol = GetTradeSymbol(symInfo)
  
  isLimitOrder = GetTradeIsLimitOrder(symInfo)
  isPendingOrder = GetTradeIsPendingOrder(symInfo)
  isPosition = GetTradeIsPosition(symInfo)
  isStopOrder = GetTradeIsStopOrder(symInfo)
  
  modified = GetTradeModified(symInfo)
  orderId = GetTradeOrderId(symInfo)
  price = GetTradePrice(symInfo)
  profit = GetTradeProfit(symInfo)
  side = GetTradeSide(symInfo)
  stopLoss = GetTradeStopLoss(symInfo)
  swap = GetTradeSwap(symInfo)
  takeProfit = GetTradeTakeProfit(symInfo)
  type = GetTradeType(symInfo)
  volume = GetTradeVolume(symInfo)
  
  UnregisterVar(symInfo)
  
  data.table(agentComission, tradeClientOrderId, tradeComment, created,
	 expiration, symbol, initialVolume, isLimitOrder, isPendingOrder,
   isPosition, isStopOrder, modified, orderId, price, profit, 
   side, stopLoss, swap, takeProfit, type, volume)
}
#' Get trade history
GetTradeHistory <- function() {
  rClr::clrCallStatic('RHost.FdkTrade', 'GetTradeHistory')
}
