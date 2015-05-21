#' Initialize the CLR runtime and loads the FDK host assembly
#' 
#' @export 
ttInit <- function() {
  library(rClr)

  if (!require("jsonlite")) 
    install.packages("jsonlite", repos="http://cran.rstudio.com/")
  library(jsonlite)
  
  fileName <-system.file("data","RHost.dll", package="FdkRLib")
  clrLoadAssembly(fileName)
}

#' Connects to a TT server
#' 
#' @param address Url of the running server
#' @param login Account number you login
#' @param password Password for the account you login
#' @export
ttConnect <- function(address = "", login= "", password= "", fdkPath = "") {
  ttInit()
  clrCallStatic('RHost.FdkHelper', 'ConnectToFdk', address, login, password, fdkPath)
}

#' Disconnect from a TT server
#' 
#' @param address Url of the running server
#' @param login Account number you login
#' @param password Password for the account you login
#' @export
ttDisconnect <- function() {
  ttInit()
  clrCallStatic('RHost.FdkHelper', 'Disconnect')
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

#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @param endTimeEpoch Epoch time
#' @export
ComputeBars <- function(symbol, priceTypeStr, barPeriodStr, endTimeEpoch) {
  clrCallStatic('RHost.FdkBars', 'ComputeBarsRangeTime', symbol, priceTypeStr, barPeriodStr, endTimeEpoch)
}

#' Gets the bars pairs as requested
#' 
#' @param symbol Symbol looked
#' @param barPeriodStr Values like: M1, H1
#' @param startTimeEpoch Epoch time
#' @export
ComputeGetPairBars <- function( symbol, barPeriodStr, startTimeEpoch) {
  clrCallStatic('RHost.FdkBars', 'ComputeGetPairBars', symbol, barPeriodStr, startTimeEpoch)
}
#' Gets the bars pairs as requested
#' 
#' @param symbol Symbol looked
#' @param barPeriodStr Values like: M1, H1
#' @param startTimeEpoch Epoch time
#' @param endTimeEpoch Epoch time
#' @export
ComputeGetPairBarsRange <- function(symbol, barPeriodStr, startTimeEpoch, endTimeEpoch) {
  clrCallStatic('RHost.FdkBars', 'ComputeGetPairBarsRange', symbol, barPeriodStr, startTimeEpoch, endTimeEpoch)
}

#' Gets the bars pairs as requested
#' 
#' @param symbol Symbol looked
#' @param barPeriodStr Values like: M1, H1
#' @param startTimeEpoch Epoch time
#' @export
ComputeGetQuotesInfo <- function(symbol, depth) {
  clrCallStatic('RHost.FdkBars', 'ComputeGetQuotesInfo', symbol, depth)
}

#' Gets the bars pairs as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask or bid
#' @param barPeriodStr Values like: M1, H1
#' @export
ComputeGetBarsInfo <- function(symbol, priceTypeStr, barPeriodStr) {
  clrCallStatic('RHost.FdkBars', 'ComputeGetBarsInfo', symbol, priceTypeStr, barPeriodStr)
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

#' Gets the bars' closed as requested
#' 
#' @param barsVar RHost variable that stores bar array
BarCloses <- function(barsVar) {
  clrCallStatic('RHost.FdkBars', 'BarCloses', barsVar)
}

#' Gets the bars' volume as requested
#' 
#' @param barsVar RHost variable that stores bar array
BarVolumes <- function(barsVar) {
  clrCallStatic('RHost.FdkBars', 'BarVolumes', barsVar)
}

#' Gets the bars' volume as requested
#' 
#' @param barsVar RHost variable that stores bar array
BarFroms <- function(barsVar) {
  clrCallStatic('RHost.FdkBars', 'BarFroms', barsVar)
}

#' Gets the bars' volume as requested
#' 
#' @param barsVar RHost variable that stores bar array
BarTos <- function(barsVar) {
  clrCallStatic('RHost.FdkBars', 'BarTos', barsVar)
}

#' Gets the bars' split intervals
#' 
#' @param barsVar RHost variable that stores bar array
GetBarsIntervals <- function(barsVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsIntervals', barsVar)
}
#' unregister a variable
#' 
#' @param varName .Net variable to be removed
UnregisterVar <- function(varName) {
  clrCallStatic('RHost.FdkVars', 'Unregister', varName)
}

# ****
#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param startTimeEpoch Starting time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param endTimeEpoch Ending time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param depth Quotes depth
ComputeQuoteHistory <- function(symbol, startTimeEpoch, endTimeEpoch, depth) {
  clrCallStatic('RHost.FdkQuotes', 'ComputeQuoteHistory', symbol, startTimeEpoch, endTimeEpoch, depth)
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
#' Gets the quotes' spread as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesSpread <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesSpread', quotesVar)
}
#' Gets the quotes' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesHasAsk <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesHasAsk', quotesVar)
}
#' Gets the quotes' bid as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesHasBid <- function(quotesVar) {
  clrCallStatic('RHost.FdkQuotes', 'QuotesHasBid', quotesVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
GetBarsAskHigh <- function(barsPairVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsAskHigh', barsPairVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
GetBarsAskLow <- function(barsPairVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsAskLow', barsPairVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
GetBarsAskOpen <- function(barsPairVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsAskOpen', barsPairVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
GetBarsAskClose <- function(barsPairVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsAskClose', barsPairVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
GetBarsAskVolume <- function(barsPairVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsAskVolume', barsPairVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
GetBarsBidHigh <- function(barsPairVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsBidHigh', barsPairVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
GetBarsBidLow <- function(barsPairVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsBidLow', barsPairVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
GetBarsBidOpen <- function(barsPairVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsBidOpen', barsPairVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
GetBarsBidClose <- function(barsPairVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsBidClose', barsPairVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
GetBarsBidVolume <- function(barsPairVar) {
  clrCallStatic('RHost.FdkBars', 'GetBarsBidVolume', barsPairVar)
}

#' Gets the bars' ask as requested
#' 
#' @param barCount Set a different bar count than the default (1 million)
#' @export
ttSetBarCount <- function(barCount) {
  clrCallStatic('RHost.FdkBars', 'SetBarCount', barCount)
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
  closes <- BarCloses(symbolBars)
  volumes <- BarVolumes(symbolBars)
  froms <- BarFroms(symbolBars)
  tos <- BarTos(symbolBars)
  UnregisterVar(symbolBars)
  data.frame(highs, lows, opens, closes, volumes, froms, tos)
}
#' Gets the bars' low as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @export

ttGetBarsRange <- function(symbol,priceTypeStr, barPeriodStr){
  symbolBars <- ComputeBars(symbol,priceTypeStr, barPeriodStr)
  highs <- BarHighs(symbolBars)
  lows <- BarLows(symbolBars)
  opens <- BarOpens(symbolBars)
  closes <- BarCloses(symbolBars)
  volumes <- BarVolumes(symbolBars)
  froms <- BarFroms(symbolBars)
  tos <- BarTos(symbolBars)
  UnregisterVar(symbolBars)
  data.frame(highs, lows, opens, closes, volumes, froms, tos)
}

#' Gets the bars' low as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @export

ttGetBarPairs <- function(symbol,priceTypeStr, barPeriodStr){
  bars = ComputeGetPairBars(symbol, priceTypeStr, barPeriodStr);
  
  askhighs = GetBarsAskHigh(bars);
  asklows = GetBarsAskLow(bars);
  askopen = FdkBars.GetBarsAskOpen(bars);
  askClose = FdkBars.GetBarsAskClose(bars);
  askVolume = FdkBars.GetBarsAskVolume(bars);
  
  bidhighs = FdkBars.GetBarsBidHigh(bars);
  bidlows = FdkBars.GetBarsBidLow(bars);
  bidOpen = FdkBars.GetBarsBidOpen(bars);
  bidClose = FdkBars.GetBarsBidClose(bars);
  bidVolume = FdkBars.GetBarsBidVolume(bars);
  
  UnregisterVar(symbolBars)
  data.frame(askhighs, asklows, askopen, askClose, askVolume, 
             bidhighs, bidlows, bidOpen, bidClose, bidVolume)
}

#' Gets the bars' low as requested
#' 
#' @param symbol Symbol looked
#' @param barPeriodStr Values like: M1, H1
#' @param startTimeEpoch Epoch time
#' @param endTimeEpoch Epoch time
#' @export

ttGetBarPairsRange <- function(symbol, barPeriodStr, startTimeEpoch, endTimeEpoch){
  bars = ComputeGetPairBarsRange(symbol, barPeriodStr, startTimeEpoch, endTimeEpoch);
  
  askhighs = GetBarsAskHigh(bars);
  asklows = GetBarsAskLow(bars);
  askopen = FdkBars.GetBarsAskOpen(bars);
  askClose = FdkBars.GetBarsAskClose(bars);
  askVolume = FdkBars.GetBarsAskVolume(bars);
  
  bidhighs = FdkBars.GetBarsBidHigh(bars);
  bidlows = FdkBars.GetBarsBidLow(bars);
  bidOpen = FdkBars.GetBarsBidOpen(bars);
  bidClose = FdkBars.GetBarsBidClose(bars);
  bidVolume = FdkBars.GetBarsBidVolume(bars);
  
  UnregisterVar(symbolBars)
  data.frame(askhighs, asklows, askopen, askClose, askVolume, 
             bidhighs, bidlows, bidOpen, bidClose, bidVolume)
}

#' Gets the quotes history
#' 
#' @param symbol Symbol looked
#' @param startTimeEpoch Starting time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param endTimeEpoch Ending time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param depth Quotes depth
#' @export

ttGetQuotes <- function(symbol,startTimeEpoch, endTimeEpoch, depth){
  symbolBars <- ComputeQuoteHistory(symbol,startTimeEpoch, endTimeEpoch, depth)
  ask <- QuotesAsk(symbolBars)
  bid <- QuotesBid(symbolBars)
  createTime <- QuotesCreatingTime(symbolBars)
  hasAsk <- QuotesHasAsk(symbolBars)
  hasBid <- QuotesHasBid(symbolBars)
  UnregisterVar(symbolBars)
  df = data.frame(ask, bid, createTime, hasAsk, hasBid)       
}

#' Gets the epoch (double) time from a .Net date
#' 
#' @param currentTime .Net invariant time 
#' @export
ttGetEpochFromText <- function(currentTime) {
  clrCallStatic('RHost.FdkHelper', 'GetCreatedEpochFromText', currentTime)
}

