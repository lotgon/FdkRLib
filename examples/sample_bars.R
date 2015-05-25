
# Connect to server before running the sample
# ttConnect()

bars = ttGetBars("EURUSD", "Bid", "H1")

boxplot(bars$highs)

plot(highs, data = bars)

endTime <- as.POSIXlt(Sys.time())
startTime <- strptime("20/3/2 11:16:16.683", "%d/%m/%y %H:%M:%OS")

st1 <- as.POSIXct(startTime)
et1 <- as.POSIXct(endTime)

quotes <- ttGetQuotes("EURUSD", st1, et1, 1)
plot(quotes$ask, type="o")

barPairs = ttGetBarPairs(symbol = "EURUSD", barPeriodStr = "M1", startTimeEpoch = startTime)
