#' Gets the symbol info
#' 
#' @export
ttGetSymbolData <- function(symbol,barPeriodStr, startTimeEpoch){
  symInfo = GetSymbolInfos()
  comission = GetSymbolComission(symInfo)
  contractMultiplier = GetSymbolContractMultiplier(symInfo)
  currency = GetSymbolCurrency(symInfo)
  limitsComission = GetSymbolLimitsCommission(symInfo)
  maxTradeVolume = GetSymbolMaxTradeVolume(symInfo)
  minTradeVolume = GetSymbolMinTradeVolume(symInfo)
  name = GetSymbolName(symInfo)
  precision = GetSymbolPrecision(symInfo)
  roundLog = GetRoundLot(symInfo)
  settlementCurrency = GetSymbolSettlementCurrency(symInfo)
  swapSizeLong = GetSymbolSwapSizeLong(symInfo)
  swapSizeShort = GetSymbolSwapSizeShort(symInfo)
  
  UnregisterVar(symInfo)
  
  data.frame(
    comission, contractMultiplier, currency, limitsComission,
    maxTradeVolume, minTradeVolume, name, precision,
    roundLog, settlementCurrency, swapSizeLong, swapSizeShort
             )
}
#' Get symbol field
GetSymbolInfos <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolInfos')
}
#' Get symbol field
GetSymbolComission <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolComission', symInfo)
}
#' Get symbol field
GetSymbolContractMultiplier <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolContractMultiplier', symInfo)
}
#' Get symbol field
GetSymbolCurrency <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolCurrency', symInfo)
}
#' Get symbol field
GetSymbolLimitsCommission <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolLimitsCommission', symInfo)
}
#' Get symbol field
GetSymbolMaxTradeVolume <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolMaxTradeVolume', symInfo)
}
#' Get symbol field
GetSymbolMinTradeVolume <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolMinTradeVolume', symInfo)
}
#' Get symbol field
GetSymbolName <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolName', symInfo)
}
#' Get symbol field
GetSymbolPrecision <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolPrecision', symInfo)
}
#' Get symbol field
GetRoundLot <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetRoundLot', symInfo)
}
#' Get symbol field
GetSymbolSettlementCurrency <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolSettlementCurrency', symInfo)
}
#' Get symbol field
GetSymbolSwapSizeLong <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolSwapSizeLong', symInfo)
}
#' Get symbol field
GetSymbolSwapSizeShort <- function(symInfo) {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolSwapSizeShort', symInfo)
}
