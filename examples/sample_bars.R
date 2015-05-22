
library(FdkRLib)
ttConnect()

bars = ttGetBars("EURUSD", "Bid", "H1")

boxplot(bars$highs)

plot(highs, data = bars)

endTime <- as.POSIXlt(Sys.time())
startTime <- strptime("20/2/15 11:16:16.683", "%d/%m/%y %H:%M:%OS")

quotes <- ttGetQuotes("EURUSD", now, endTime, 1)
plot(quotes$ask, type="o")
