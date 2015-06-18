#' Gets the account trades
#' 
#' @param fromDate Start time
#' @param toDate End time (fromDate has to be before toDate)
#' @export
ttTradeRecords <- function(fromDate, toDate){
  symInfo = GetTradeReportTransactionReport(fromDate, toDate)
  GetTradeReportDataFrame(symInfo)
}

#' Gets the account trades
#' 
#' @export
ttTradeRecordAll <- function() {
  symInfo = GetTradeTransactionReportAll()
  GetTradeReportDataFrame(symInfo)
}

#' Get symbol field
GetTradeReportTransactionReport <- function(tradeSide, tradeType) {
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTransactionReport', tradeSide, tradeType)
}

#' Get symbol field
GetTradeTransactionReportAll <- function(tradeSide, tradeType) {
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTransactionReportAll', tradeSide, tradeType)
}



GetTradeReportDataFrame <- function(symInfo)
{
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

GetTradeReportAccountBalance <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeReportAccountBalance', varName)
}

GetTradeReportAgentCommission <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeAgentCommission', varName)
}

GetTradeReportClientId <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeClientId', varName)
}

GetTradeReportCloseConversionRate <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeCloseConversionRate', varName)
}

GetTradeReportInitialVolume <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeInitialVolume', varName)
}

GetTradeReportComment <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeComment', varName)
}

GetTradeReportCommission <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeCommission', varName)
}

GetTradeReportId <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeId', varName)
}

GetTradeReportLeavesQuantity <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeLeavesQuantity', varName)
}

GetTradeReportOpenConversionRate <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeOpenConversionRate', varName)
}

GetTradeReportOrderCreated <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeOrderCreated', varName)
}

GetTradeReportOrderFillPrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeOrderFillPrice', varName)
}

GetTradeReportOrderLastFillAmount <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeOrderLastFillAmount', varName)
}

GetTradeReportOrderModified <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeOrderModified', varName)
}

GetTradeReportPosOpenPrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePosOpenPrice', varName)
}

GetTradeReportPositionClosePrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionClosePrice', varName)
}

GetTradeReportPositionCloseRequestedPrice <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionCloseRequestedPrice', varName)
}

GetTradeReportPositionClosed <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionClosed', varName)
}

GetTradeReportPositionId <- function(varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionId', varName)
}

GetTradeReportPositionLastQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionLastQuantity', varName)
}

GetTradeReportPositionLeavesQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionLeavesQuantity', varName)
}

GetTradeReportPositionModified <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionModified', varName)
}

GetTradeReportPositionOpened <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionOpened', varName)
}

GetTradeReportPositionQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePositionQuantity', varName)
}

GetTradeReportPrice <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradePrice', varName)
}

GetTradeReportQuantity <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeQuantity', varName)
}

GetTradeReportStopLoss <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeStopLoss', varName)
}

GetTradeReportStopPrice <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeStopPrice', varName)
}

GetTradeReportSwap <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeSwap', varName)
}

GetTradeReportSymbol <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeSymbol', varName)
}

GetTradeReportTakeProfit <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTakeProfit', varName)
}

GetTradeReportTradeRecordSide <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTradeRecordSide', varName)
}

GetTradeReportTradeRecordType <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTradeRecordType', varName)
}

GetTradeReportTradeTransactionReason <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTradeTransactionReason', varName)
}

GetTradeReportTradeTransactionReportType <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTradeTransactionReportType', varName)
}

GetTradeReportTransactionAmount <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTransactionAmount', varName)
}

GetTradeReportTransactionCurrency <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTransactionCurrency', varName)
}

GetTradeReportTransactionTime <- function (varName)
{
  clrCallStatic('RHost.FdkTradeReports', 'GetTradeTransactionTime', varName)
}