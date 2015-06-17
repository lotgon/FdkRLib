
#' Gets the quotes history
#' 
#' @param symbol Symbol looked
#' @param startTime Starting time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param endTime Ending time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param depth The market depth. Default is 2
#' @export
ttQuotesLevel2 <- function(symbol,startTime, endTime, depth = 2){
  quotesHistory <- GetQuotePacked(symbol,startTime, endTime, depth)
  
  createTime <- QuotesL2CreatingTime(quotesHistory)
  volumeBid <- QuotesVolumeBid(quotesHistory)
  volumeAsk <- QuotesVolumeAsk(quotesHistory)
  priceBid <- QuotesPriceBid(quotesHistory)
  priceAsk <- QuotesPriceAsk(quotesHistory)
  index <- QuotesIndex(quotesHistory)
  
  UnregisterVar(quotesHistory)
  df = data.frame(volumeBid=volumeBid, volumeAsk=volumeAsk, 
         priceBid=priceBid, priceAsk=priceAsk, createTime=createTime,
         quoteIndex=index)
}


# ****
#' Gets the bars as requested
#' 
#' @param symbol Symbol looked
#' @param startTimeEpoch Starting time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param endTimeEpoch Ending time. Use ttGetEpochFromText if you want to take from text a valid date.
#' @param depth Quotes depth
GetQuotePacked <- function(symbol, startTime, endTime, depth) {
  clrCallStatic('RHost.FdkLevel2', 'GetQuotePacked', symbol, startTime, endTime, depth)
}

#' Gets the bars' time
#'
#' @param quotesVar RHost variable that stores quotes array
#' 
QuotesL2CreatingTime <- function(quotesVar) {
  clrCallStatic('RHost.FdkLevel2', 'QuotesCreateTime', quotesVar)
}

#' Gets the quote's bid as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesVolumeBid <- function(quotesVar) {
  clrCallStatic('RHost.FdkLevel2', 'QuotesVolumeBid', quotesVar)
}

#' Gets the quote's ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesVolumeAsk <- function(quotesVar) {
  clrCallStatic('RHost.FdkLevel2', 'QuotesVolumeAsk', quotesVar)
}
#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesPriceAsk <- function(quotesVar) {
  clrCallStatic('RHost.FdkLevel2', 'QuotesPriceAsk', quotesVar)
}

#' Gets the bars' ask as requested
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesPriceAsk <- function(quotesVar) {
  clrCallStatic('RHost.FdkLevel2', 'QuotesPriceAsk', quotesVar)
}

#' Gets the quote's index
#' 
#' @param quotesVar RHost variable that stores quotes array
QuotesIndex <- function(quotesVar) {
  clrCallStatic('RHost.FdkLevel2', 'QuotesIndex', quotesVar)
}
