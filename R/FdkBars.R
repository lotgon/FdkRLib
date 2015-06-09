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
ttBars <- function(symbol, priceTypeStr, barPeriodStr, endTime, 
                    barCount, mode="range") {
  clrCallStatic('RHost.FdkBars', 'GetBars', symbol, priceTypeStr, barPeriodStr, endTime, 
                barCount, mode)
}

#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
ttBars <- function(symbol, priceTypeStr, barPeriodStr, endTime, 
                   barCount, mode="range") {
  clrCallStatic('RHost.FdkBars', 'GetBars', symbol, priceTypeStr, barPeriodStr, endTime, 
                barCount, mode)
}

ttTimeZero <- function(){
  tm <- as.POSIXct(0, origin = "1970-01-01")
}

ttStartTime <- function(dateTime){
  tt_EndTime <<- dateTime
}


ttEndTime <- function(dateTime){
  tt_EndTime <<- dateTime
}


#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @param endTimeEpoch Epoch time
#' @export
ttBars <- function(symbol, priceTypeStr, barPeriodStr, endTimeEpoch){
  symbolBars <- ComputeBarsRange(symbol, priceTypeStr, barPeriodStr, endTimeEpoch)
  getBarsFrame(symbolBars)
}

#' Gets the bars' low as requested
#' 
#' @param symbol Symbol looked
#' @param priceTypeStr Ask
#' @param barPeriodStr Values like: M1, H1
#' @export

ttBarsByCount <- function(symbol,priceTypeStr, barPeriodStr, endTime, barCount=10000){
  symbolBars <- GetBars(symbol,priceTypeStr, barPeriodStr, endTime, barCount)
  
  getBarsFrame(symbolBars)
}

#' Gets the bars' low as requested
#' 
#' @param symbol Symbol looked ('EURUSD')
#' @param priceTypeStr Ask, Bid
#' @param barPeriodStr Values like: M1, M5, H1
#' @param barCount Count of bars. Default: 10000000
#' @param mode "range" is default. Mode "list" allows just to get a range of items 
#' @export
ttGetBars <- function(symbol, priceTypeStr, barPeriodStr, endTime, 
                      barCount=10000, mode="range")
{
  symbolBars <- GetBars(symbol, priceTypeStr, barPeriodStr, tt_EndTime, 
                        barCount, mode)
  getBarsFrame(symbolBars)
}

getBarsFrame <- function(symbolBars){
  
  high <- BarHighs(symbolBars)
  low <- BarLows(symbolBars)
  open <- BarOpens(symbolBars)
  close <- BarCloses(symbolBars)
  volume <- BarVolumes(symbolBars)
  from <- BarFroms(symbolBars)
  to <- BarTos(symbolBars)
  UnregisterVar(symbolBars)
  data.frame(high, low, open, close, volume, from, to)
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
#' @param startTime Start of the time range
#' @param endTime End of the time range
ComputeBarsRange <- function(symbol, 
      priceTypeStr, barPeriodStr, startTune, endTime) {
  clrCallStatic('RHost.FdkBars', 'ComputeBarsRangeTime', symbol, 
                priceTypeStr, barPeriodStr, startTime, endTime)
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