#' Gets the account trades
#' 
#' @param fromDate '' (unfiltered) or 'Buy' or 'Sell'
#' @param toDate '' (unfiltered) or 'Market' 'Position' 'Limit' 'Stop'
#' @export
ttTradeRecords <- function(fromDate, toDate){
  symInfo = GetTradeRecords(tradeSide, tradeType)
  
  AgentCommission = GetTradeAgentCommission(symInfo)
  ClientId = GetTradeClientId(symInfo)
  CloseConversionRate = GetTradeCloseConversionRate(symInfo)
  InitialVolume = GetTradeInitialVolume(symInfo)
  Comment = GetTradeComment(symInfo)
  Commission = GetTradeCommission(symInfo)
  Id = GetTradeId(symInfo)
  LeavesQuantity = GetTradeLeavesQuantity(symInfo)
  OpenConversionRate = GetTradeOpenConversionRate(symInfo)
  OrderCreated = GetTradeOrderCreated(symInfo)
  OrderFillPrice = GetTradeOrderFillPrice(symInfo)
  OrderLastFillAmount = GetTradeOrderLastFillAmount(symInfo)
  OrderModified = GetTradeOrderModified(symInfo)
  PosOpenPrice = GetTradePosOpenPrice(symInfo)
  PositionClosePrice = GetTradePositionClosePrice(symInfo)
  PositionCloseRequestedPrice = GetTradePositionCloseRequestedPrice(symInfo)
  PositionClosed = GetTradePositionClosed(symInfo)
  PositionLastQuantity = GetTradePositionLastQuantity(symInfo)
  PositionLeavesQuantity = GetTradePositionLeavesQuantity(symInfo)
  PositionModified = GetTradePositionModified(symInfo)
  PositionOpened = GetTradePositionOpened(symInfo)
  PositionQuantity = GetTradePositionQuantity(symInfo)
  Price = GetTradePrice(symInfo)
  Quantity = GetTradeQuantity(symInfo)
  StopLoss = GetTradeStopLoss(symInfo)
  StopPrice = GetTradeStopPrice(symInfo)
  Swap = GetTradeSwap(symInfo)
  Symbol = GetTradeSymbol(symInfo)
  TakeProfit = GetTradeTakeProfit(symInfo)
  TradeRecordSide = GetTradeTradeRecordSide(symInfo)
  TradeRecordType = GetTradeTradeRecordType(symInfo)
  TradeTransactionReason = GetTradeTradeTransactionReason(symInfo)
  TradeTransactionReportType = GetTradeTradeTransactionReportType(symInfo)
  TransactionAmount = GetTradeTransactionAmount(symInfo)
  TransactionCurrency = GetTradeTransactionCurrency(symInfo)
  TransactionTime = GetTradeTransactionTime(symInfo)
  
  UnregisterVar(symInfo)
  
  data.frame(AgentCommission, ClientId, CloseConversionRate, InitialVolume, Comment, Commission,
	Id, LeavesQuantity, OpenConversionRate, OrderCreated, OrderFillPrice, OrderLastFillAmount, OrderModified,
	PosOpenPrice, PositionClosePrice, PositionCloseRequestedPrice, PositionClosed,
	PositionLastQuantity, PositionLeavesQuantity, PositionModified, PositionOpened, PositionQuantity,
	Price, Quantity, StopLoss, Swap, Symbol, TakeProfit, TradeRecordSide, TradeRecordType, 
	TradeTransactionReason, TradeTransactionReportType, TransactionAmount, TransactionCurrency, TransactionTime
	)
}


#' Get symbol field
GetTradeRecords <- function(tradeSide, tradeType) {
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTransactionReport', tradeSide, tradeType)
}

GetTradeAccountBalance <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeAccountBalance', varName)
}

GetTradeAgentCommission <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeAgentCommission', varName)
}

GetTradeClientId <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeClientId', varName)
}

GetTradeCloseConversionRate <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeCloseConversionRate', varName)
}

GetTradeInitialVolume <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeInitialVolume', varName)
}

GetTradeComment <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeComment', varName)
}

GetTradeCommission <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeCommission', varName)
}

GetTradeId <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeId', varName)
}

GetTradeLeavesQuantity <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeLeavesQuantity', varName)
}

GetTradeOpenConversionRate <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeOpenConversionRate', varName)
}

GetTradeOrderCreated <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeOrderCreated', varName)
}

GetTradeOrderFillPrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeOrderFillPrice', varName)
}

GetTradeOrderLastFillAmount <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeOrderLastFillAmount', varName)
}

GetTradeOrderModified <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeOrderModified', varName)
}

GetTradePosOpenPrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePosOpenPrice', varName)
}

GetTradePositionClosePrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionClosePrice', varName)
}

GetTradePositionCloseRequestedPrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionCloseRequestedPrice', varName)
}

GetTradePositionClosed <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionClosed', varName)
}

GetTradePositionId <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionId', varName)
}

GetTradePositionLastQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionLastQuantity', varName)
}

GetTradePositionLeavesQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionLeavesQuantity', varName)
}

GetTradePositionModified <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionModified', varName)
}

GetTradePositionOpened <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionOpened', varName)
}

GetTradePositionQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionQuantity', varName)
}

GetTradePrice <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePrice', varName)
}

GetTradeQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeQuantity', varName)
}

GetTradeStopLoss <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeStopLoss', varName)
}

GetTradeStopPrice <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeStopPrice', varName)
}

GetTradeSwap <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeSwap', varName)
}

GetTradeSymbol <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeSymbol', varName)
}

GetTradeTakeProfit <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTakeProfit', varName)
}

GetTradeTradeRecordSide <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTradeRecordSide', varName)
}

GetTradeTradeRecordType <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTradeRecordType', varName)
}

GetTradeTradeTransactionReason <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTradeTransactionReason', varName)
}

GetTradeTradeTransactionReportType <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTradeTransactionReportType', varName)
}

GetTradeTransactionAmount <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTransactionAmount', varName)
}

GetTradeTransactionCurrency <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTransactionCurrency', varName)
}

GetTradeTransactionTime <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTransactionTime', varName)
}