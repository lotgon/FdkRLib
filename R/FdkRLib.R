#' Initialize the CLR runtime and loads the FDK host assembly
#' 
#' @export 
ttInit <- function() {
  library(rClr)
  fileName <-system.file("data","RHost.dll", package="FdkRLib")
  clrLoadAssembly(fileName)
}



#' Connects to a TT server
#' 
#' @param address Url of the running server
#' @param login Account number you login
#' @param password Password for the account you login
#' @export
ttConnect <- function(address = "", login= "", password= "") {
  ttInit()
  clrCallStatic('RHost.FdkHelper', 'ConnectToFdk', address, login, password)
}

#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @export
ComputeBars <- function(symbol,priceTypeStr, barPeriodStr) {
  clrCallStatic('RHost.FdkBars', 'ComputeBars', symbol,priceTypeStr, barPeriodStr)
}

#' Gets the bars' high  as requested
#' 
#' @param barsVar RHost variable that stores bar array
BarHighs <- function(barsVar) {
  clrCallStatic('RHost.FdkBars', 'BarHighs', barsVar)
}
#' Gets the bars' low as requested
#' 
#' @param barsVar RHost variable that stores bar array
BarLows <- function(barsVar) {
  clrCallStatic('RHost.FdkBars', 'BarLows', barsVar)
}
#' Gets the bars' open as requested
#' 
#' @param barsVar RHost variable that stores bar array
BarOpens <- function(barsVar) {
  clrCallStatic('RHost.FdkBars', 'BarOpens', barsVar)
}
#' Gets the bars' volume as requested
#' 
#' @param barsVar RHost variable that stores bar array
BarVolumes <- function(barsVar) {
  clrCallStatic('RHost.FdkBars', 'BarVolumes', barsVar)
}

#' unregister a variable
#' 
#' @param varName .Net variable to be removed
UnregisterVar <- function(varName) {
  clrCallStatic('RHost.FdkVars', 'Unregister', varName)
}

#' Gets the bars' low as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @export

ttGetBars <- function(symbol,priceTypeStr, barPeriodStr){
  symbolBars <- ComputeBars(symbol,priceTypeStr, barPeriodStr)
  highs <- BarHighs(symbolBars)
  lows <- BarLows(symbolBars)
  opens <- BarOpens(symbolBars)
  volumes <- BarVolumes(symbolBars)
  UnregisterVar(symbolBars)
  df = data.frame(highs, lows, opens, volumes)       
}
