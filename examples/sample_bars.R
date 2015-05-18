source("R/FdkRLib.R")

library(FdkRLib)
ttConnect("", "", "")

bars = ttGetBars("EURUSD", "Bid", "H1")

boxplot(bars$highs)

plot(highs, data = bars)

quotes <- ttGetQuotes("EURUSD", "05/05/2015", "05/07/2015", 1)
plot(quotes$ask, type="o")
