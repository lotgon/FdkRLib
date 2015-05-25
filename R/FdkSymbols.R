#' Gets the symbol info
#' 
#' @export
ttGetSymbolData <- function(symbol,barPeriodStr, startTimeEpoch){
  comission = GetSymbolComission()
  contractMultiplier = GetSymbolContractMultiplier()
  currency = GetSymbolCurrency()
  limitsComission = GetSymbolLimitsCommission()
  maxTradeVolume = GetSymbolMaxTradeVolume()
  minTradeVolume = GetSymbolMinTradeVolume()
  name = GetSymbolName()
  precision = GetSymbolPrecision()
  roundLog = GetRoundLot()
  settlementCurrency = GetSymbolSettlementCurrency()
  swapSizeLong = GetSymbolSwapSizeLong()
  swapSizeShort = GetSymbolSwapSizeShort()
  
  data.frame(
    comission, contractMultiplier, currency, limitsComission,
    maxTradeVolume, minTradeVolume, name, precision,
    roundLog, settlementCurrency, swapSizeLong, swapSizeShort
             )
}

#' Get symbol field
GetSymbolComission <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolComission')
}
#' Get symbol field
GetSymbolContractMultiplier <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolContractMultiplier')
}
#' Get symbol field
GetSymbolCurrency <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolCurrency')
}
#' Get symbol field
GetSymbolLimitsCommission <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolLimitsCommission')
}
#' Get symbol field
GetSymbolMaxTradeVolume <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolMaxTradeVolume')
}
#' Get symbol field
GetSymbolMinTradeVolume <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolMinTradeVolume')
}
#' Get symbol field
GetSymbolName <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolName')
}
#' Get symbol field
GetSymbolPrecision <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolPrecision')
}
#' Get symbol field
GetRoundLot <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetRoundLot')
}
#' Get symbol field
GetSymbolSettlementCurrency <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolSettlementCurrency')
}
#' Get symbol field
GetSymbolSwapSizeLong <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolSwapSizeLong')
}
#' Get symbol field
GetSymbolSwapSizeShort <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolSwapSizeShort')
}
