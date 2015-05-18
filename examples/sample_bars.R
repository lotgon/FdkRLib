source("R/FdkRLib.R")

library(FdkRLib)
ttConnect("", "", "")

bars = ttGetBars("EURUSD", "Bid", "H1")

boxplot(bars$highs)

plot(highs, data = bars)

startTime <- ttGetEpochFromText("05/05/2015")
endTime <- ttGetEpochFromText("05/07/2015")

quotes <- ttGetQuotes("EURUSD", startTime, endTime, 1)
plot(quotes$ask, type="o")
