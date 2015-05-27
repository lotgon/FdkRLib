#' Gets the symbol info
#' 
#' @export
ttGetCurrencyData <- function(){
  symInfo = GetCurrencyInfos()
  
  currency = GetCurrencyCurrency(symInfo)
  description = GetCurrencyDescription(symInfo)
  contractMultiplier = GetCurrencyContractMultiplier(symInfo)
  limitsCommission = GetCurrencyLimitsCommission(symInfo)
  
  UnregisterVar(symInfo)
  
  data.frame(currency, description, contractMultiplier, limitsCommission)
}
#' Get symbol field
GetCurrencyInfos <- function(symInfo) {
  clrCallStatic('RHost.FdkCurrencyInfo', 'GetCurrencyInfos', symInfo)
}
#' Get symbol field
GetCurrencyDescription <- function(symInfo) {
  clrCallStatic('RHost.FdkCurrencyInfo', 'GetCurrencyDescription', symInfo)
}
#' Get symbol field
GetCurrencyCurrency <- function(symInfo) {
  clrCallStatic('RHost.FdkCurrencyInfo', 'GetCurrencyCurrency', symInfo)
}
#' Get symbol field
GetCurrencyContractMultiplier <- function(symInfo) {
  clrCallStatic('RHost.FdkCurrencyInfo', 'GetCurrencyContractMultiplier', symInfo)
}
#' Get symbol field
GetCurrencyLimitsCommission <- function(symInfo) {
  clrCallStatic('RHost.FdkCurrencyInfo', 'GetCurrencyLimitsCommission', symInfo)
}