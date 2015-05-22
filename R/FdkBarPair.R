
#' Gets the bars' low as requested
#' 
#' @param symbol Symbol looked
#' @param barPeriodStr Values like: M1, H1
#' @param startTimeEpoch Epoch time
#' @export

ttGetBarPairs <- function(symbol,barPeriodStr, startTimeEpoch){
  bars = ComputeGetPairBars(symbol, barPeriodStr, startTimeEpoch);
  
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
