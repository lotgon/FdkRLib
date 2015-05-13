source("R/FdkRLib.R")

library(FdkRLib)
ttConnect("", "", "")


quotes = ttGetQuotes("EURUSD", "2051-05-05", "2015-05-06", 1)


bars = ttGetBars("EURUSD", "Bid", "H1")

boxplot(bars$highs)

plot(highs, data = bars)


if (!require("jsonlite")) 
  install.packages("jsonlite", repos="http://cran.rstudio.com/")
library(jsonlite)

str(fromJSON("http://tp.dev.soft-fx.eu:5021/api/v1/public/level2/EURUSD"))