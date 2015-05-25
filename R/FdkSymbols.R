
#' Gets the symbol info
#' 
#' @export

ttGetSymbolData <- function(symbol,barPeriodStr, startTimeEpoch){
  comission = GetSymbolComission()
  contractMultiplier = GetSymbolContractMultiplier
  currency = GetSymbolCurrency
  limitsComission = GetSymbolLimitsCommission
  maxTradeVolume = GetSymbolMaxTradeVolume
  minTradeVolume = GetSymbolMinTradeVolume
  name = GetSymbolName
  precision = GetSymbolPrecision
  roundLog = GetRoundLot
  settlementCurrency = GetSymbolSettlementCurrency
  swapSizeLong = GetSymbolSwapSizeLong
  swapSizeShort = GetSymbolSwapSizeShort
  
  data.frame(comission, contractMultiplier, currency, limitsComission,
             maxTradeVolume, minTradeVolume, name, precision,
             roundLog, settlementCurrency, swapSizeLong, swapSizeShort
             )
}

#' Get symbol field
#' 
#' @export
GetSymbolComission <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolComission')
}
#' Get symbol field
#' 
#' @export
GetSymbolContractMultiplier <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolContractMultiplier')
}
#' Get symbol field
#' 
#' @export
GetSymbolCurrency <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolCurrency')
}
#' Get symbol field
#' 
#' @export
GetSymbolLimitsCommission <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolLimitsCommission')
}
#' Get symbol field
#' 
#' @export
GetSymbolMaxTradeVolume <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolMaxTradeVolume')
}
#' Get symbol field
#' 
#' @export
GetSymbolMinTradeVolume <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolMinTradeVolume')
}
#' Get symbol field
#' 
#' @export
GetSymbolName <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolName')
}
#' Get symbol field
#' 
#' @export
GetSymbolPrecision <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolPrecision')
}
#' Get symbol field
#' 
#' @export
GetRoundLot <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetRoundLot')
}
#' Get symbol field
#' 
#' @export
GetSymbolSettlementCurrency <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolSettlementCurrency')
}

#' Get symbol field
#' 
#' @export
GetSymbolSwapSizeLong <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolSwapSizeLong')
}

#' Get symbol field
#' 
#' @export
GetSymbolSwapSizeShort <- function() {
  clrCallStatic('RHost.FdkSymbolInfo', 'GetSymbolSwapSizeShort')
}
