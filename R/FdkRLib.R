

#' Gets the bars pairs as requested
#' 
#' @param symbol Symbol looked
#' @param barPeriodStr Values like: M1, H1
#' @param startTimeEpoch Epoch time
#' @export
ttGetQuotesInfo <- function(symbol, depth) {
  clrCallStatic('RHost.FdkBars', 'ComputeGetQuotesInfo', symbol, depth)
}

#' Gets the bars pairs as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask or bid
#' @param barPeriodStr Values like: M1, H1
#' @export
ttGetBarsInfo <- function(symbol, priceTypeStr, barPeriodStr) {
  clrCallStatic('RHost.FdkBars', 'ComputeGetBarsInfo', symbol, priceTypeStr, barPeriodStr)
}


#' unregister a variable
#' 
#' @param varName .Net variable to be removed
#' @export
UnregisterVar <- function(varName) {
  clrCallStatic('RHost.FdkVars', 'Unregister', varName)
}

#' Clear the environment variables
#' 
#' @param varName .Net variable to be removed
#' @export
ttUnregisterAllVariables <- function(varName) {
  clrCallStatic('RHost.FdkVars', 'ClearAll', varName)
}

#' Gives a default time (equivalent with NULL/NA/null)
#' 
#' @export
ttTimeZero <- function(){
  tm <- as.POSIXct(0, origin = "1970-01-02")
}
#' Gives current time
#' 
#' @export
ttNow <- function(){
  tm <- Sys.time()
}

#' Gets the epoch (double) time from a .Net date
#' 
#' @param currentTime .Net invariant time 
#' @export
ttGetEpochFromText <- function(currentTime) {
  clrCallStatic('RHost.FdkHelper', 'GetCreatedEpochFromText', currentTime)
}

