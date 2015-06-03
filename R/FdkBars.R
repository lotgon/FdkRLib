#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @export
ComputeBars <- function(symbol,priceTypeStr, barPeriodStr) {
  clrCallStatic('RHost.FdkBars', 'ComputeBars', symbol,priceTypeStr, barPeriodStr)
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

#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @param endTimeEpoch Epoch time
#' @export
ttGetBarsRange <- function(symbol, priceTypeStr, barPeriodStr, endTimeEpoch){
  symbolBars <- ComputeBarsRange(symbol, priceTypeStr, barPeriodStr, endTimeEpoch)
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


#' Gets the bars as requested range
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @param endTimeEpoch Epoch time
ComputeBars <- function(symbol, priceTypeStr, barPeriodStr) {
  clrCallStatic('RHost.FdkBars', 'ComputeBars', symbol, priceTypeStr, barPeriodStr)
}

#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @param endTimeEpoch Epoch time
ComputeBarsRange <- function(symbol, priceTypeStr, barPeriodStr, endTimeEpoch) {
  clrCallStatic('RHost.FdkBars', 'ComputeBarsRangeTime', symbol, priceTypeStr, barPeriodStr, endTimeEpoch)
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