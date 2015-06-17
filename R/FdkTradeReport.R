#' Gets the account trades
#' 
#' @param fromDate Start time
#' @param toDate End time (fromDate has to be before toDate)
#' @export
ttTradeRecords <- function(fromDate, toDate){
  symInfo = GetTradeTransactionReport(fromDate, toDate)
  
  AgentCommission = GetTradeReportAgentCommission(symInfo)
  ClientId = GetTradeReportClientId(symInfo)
  CloseConversionRate = GetTradeReportCloseConversionRate(symInfo)
  InitialVolume = GetTradeReportInitialVolume(symInfo)
  Comment = GetTradeReportComment(symInfo)
  Commission = GetTradeReportCommission(symInfo)
  Id = GetTradeReportId(symInfo)
  LeavesQuantity = GetTradeReportLeavesQuantity(symInfo)
  OpenConversionRate = GetTradeReportOpenConversionRate(symInfo)
  OrderCreated = GetTradeReportOrderCreated(symInfo)
  OrderFillPrice = GetTradeReportOrderFillPrice(symInfo)
  OrderLastFillAmount = GetTradeReportOrderLastFillAmount(symInfo)
  OrderModified = GetTradeReportOrderModified(symInfo)
  PosOpenPrice = GetTradeReportPosOpenPrice(symInfo)
  PositionClosePrice = GetTradeReportPositionClosePrice(symInfo)
  PositionCloseRequestedPrice = GetTradeReportPositionCloseRequestedPrice(symInfo)
  PositionClosed = GetTradeReportPositionClosed(symInfo)
  PositionLastQuantity = GetTradeReportPositionLastQuantity(symInfo)
  PositionLeavesQuantity = GetTradeReportPositionLeavesQuantity(symInfo)
  PositionModified = GetTradeReportPositionModified(symInfo)
  PositionOpened = GetTradeReportPositionOpened(symInfo)
  PositionQuantity = GetTradeReportPositionQuantity(symInfo)
  Price = GetTradeReportPrice(symInfo)
  Quantity = GetTradeReportQuantity(symInfo)
  StopLoss = GetTradeReportStopLoss(symInfo)
  StopPrice = GetTradeReportStopPrice(symInfo)
  Swap = GetTradeReportSwap(symInfo)
  Symbol = GetTradeReportSymbol(symInfo)
  TakeProfit = GetTradeReportTakeProfit(symInfo)
  TradeRecordSide = GetTradeReportTradeRecordSide(symInfo)
  TradeRecordType = GetTradeReportTradeRecordType(symInfo)
  TradeTransactionReason = GetTradeReportTradeTransactionReason(symInfo)
  TradeTransactionReportType = GetTradeReportTradeTransactionReportType(symInfo)
  TransactionAmount = GetTradeReportTransactionAmount(symInfo)
  TransactionCurrency = GetTradeReportTransactionCurrency(symInfo)
  TransactionTime = GetTradeReportTransactionTime(symInfo)
  
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
GetTradeReportTransactionReport <- function(tradeSide, tradeType) {
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportTransactionReport', tradeSide, tradeType)
}

GetTradeReportAccountBalance <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportAccountBalance', varName)
}

GetTradeReportAgentCommission <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportAgentCommission', varName)
}

GetTradeReportClientId <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportClientId', varName)
}

GetTradeReportCloseConversionRate <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportCloseConversionRate', varName)
}

GetTradeReportInitialVolume <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportInitialVolume', varName)
}

GetTradeReportComment <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportComment', varName)
}

GetTradeReportCommission <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportCommission', varName)
}

GetTradeReportId <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportId', varName)
}

GetTradeReportLeavesQuantity <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportLeavesQuantity', varName)
}

GetTradeReportOpenConversionRate <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportOpenConversionRate', varName)
}

GetTradeReportOrderCreated <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportOrderCreated', varName)
}

GetTradeReportOrderFillPrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportOrderFillPrice', varName)
}

GetTradeReportOrderLastFillAmount <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportOrderLastFillAmount', varName)
}

GetTradeReportOrderModified <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportOrderModified', varName)
}

GetTradeReportPosOpenPrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPosOpenPrice', varName)
}

GetTradeReportPositionClosePrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPositionClosePrice', varName)
}

GetTradeReportPositionCloseRequestedPrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPositionCloseRequestedPrice', varName)
}

GetTradeReportPositionClosed <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPositionClosed', varName)
}

GetTradeReportPositionId <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPositionId', varName)
}

GetTradeReportPositionLastQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPositionLastQuantity', varName)
}

GetTradeReportPositionLeavesQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPositionLeavesQuantity', varName)
}

GetTradeReportPositionModified <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPositionModified', varName)
}

GetTradeReportPositionOpened <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPositionOpened', varName)
}

GetTradeReportPositionQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPositionQuantity', varName)
}

GetTradeReportPrice <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportPrice', varName)
}

GetTradeReportQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportQuantity', varName)
}

GetTradeReportStopLoss <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportStopLoss', varName)
}

GetTradeReportStopPrice <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportStopPrice', varName)
}

GetTradeReportSwap <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportSwap', varName)
}

GetTradeReportSymbol <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportSymbol', varName)
}

GetTradeReportTakeProfit <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportTakeProfit', varName)
}

GetTradeReportTradeRecordSide <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportTradeRecordSide', varName)
}

GetTradeReportTradeRecordType <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportTradeRecordType', varName)
}

GetTradeReportTradeTransactionReason <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportTradeTransactionReason', varName)
}

GetTradeReportTradeTransactionReportType <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportTradeTransactionReportType', varName)
}

GetTradeReportTransactionAmount <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportTransactionAmount', varName)
}

GetTradeReportTransactionCurrency <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportTransactionCurrency', varName)
}

GetTradeReportTransactionTime <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportTransactionTime', varName)
}