

source("R/FdkRLib.R")

library(FdkRLib)
ttConnect("", "", "")

getTickData <- function(symbolName){
  basicUrl = "http://tp.dev.soft-fx.eu:5021/api/v1/public/tick/"
  fullUrl = paste(basicUrl, symbolName, sep = "")
  fromJSON(fullUrl)
}
symbol = "EURUSD"
tickData <- getTickData(symbol)
bestBid <- tickData$BestBid$Price
oldTimeStamp <-tickData$Timestamp

summary(bidData)

tickData <- getTickData(symbol)

timeStamp <- tickData$Timestamp$Price
if(timeStamp!=oldTimeStamp)
{
  bestBid <- c(bestBid, tickData$BestBid$Price)
  plot(bestBid)
}
bars = ttGetBars("EURUSD", "Bid", "H1")

boxplot(bars$highs)

plot(highs, data = bars)

quotes = ttGetQuotes("EURUSD", "2051-05-05", "2015-05-06", 1)
