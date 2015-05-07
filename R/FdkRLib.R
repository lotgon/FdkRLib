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
ttConnect <- function(address = "", login= "", password= "", path= "", fdkPath = "") {
  ttInit()
  clrCallStatic('RHost.FdkHelper', 'ConnectToFdk', address, login, password, fdkPath)
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

# ****

#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @param barPeriodStr Values like: M1, H1
#' @export
ComputeQuoteHistory <- function(symbol,priceTypeStr, barPeriodStr, depth) {
  clrCallStatic('RHost.FdkQuotes', 'ComputeQuoteHistory', symbol,priceTypeStr, barPeriodStr, depth)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesAsk <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesAsk', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesBid <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesBid', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesCreatingTime <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesCreatingTime', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesSpread <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesSpread', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesHasAsk <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesHasAsk', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesHasBid <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesHasBid', quotesVar)
}

#' Gets the quotes history
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @export

ttGetQuotes <- function(symbol,priceTypeStr, barPeriodStr, depth){
  symbolBars <- ComputeQuoteHistory(symbol,priceTypeStr, barPeriodStr, depth)
  ask <- QuotesAsk(symbolBars)
  bid <- QuotesBid(symbolBars)
  createTime <- QuotesCreatingTime(symbolBars)
  hasAsk <- QuotesHasAsk(symbolBars)
  hasBid <- QuotesHasBid(symbolBars)
  spread <- QuotesSpread(symbolBars)  
  UnregisterVar(symbolBars)
  df = data.frame(ask, bid, createTime, hasAsk, hasBid, spread)       
}