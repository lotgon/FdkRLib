#' Gets the symbol info
#' 
#' @export
ttGetCurrencyData <- function(){
  symInfo = GetCurrencyInfos()
  
  currency = GetCurrencyName(symInfo)
  description = GetCurrencyDescription(symInfo)
  precision = GetCurrencyPrecision(symInfo)
  sortOrder = GetCurrencySortOrder(symInfo)
  
  UnregisterVar(symInfo)
  
  data.frame(currency, description, precision, sortOrder)
}
#' Get symbol field
GetCurrencyInfos <- function() {
  clrCallStatic('RHost.FdkCurrencyInfo', 'GetCurrencyInfos')
}
#' Get symbol field
GetCurrencyName <- function(symInfo) {
  clrCallStatic('RHost.FdkCurrencyInfo', 'GetCurrencyName', symInfo)
}
#' Get symbol field
GetCurrencyDescription <- function(symInfo) {
  clrCallStatic('RHost.FdkCurrencyInfo', 'GetCurrencyDescription', symInfo)
}

#' Get symbol field
GetCurrencyPrecision <- function(symInfo) {
  clrCallStatic('RHost.FdkCurrencyInfo', 'GetCurrencyPrecision', symInfo)
}
#' Get symbol field
GetCurrencySortOrder <- function(symInfo) {
  clrCallStatic('RHost.FdkCurrencyInfo', 'GetCurrencySortOrder', symInfo)
}