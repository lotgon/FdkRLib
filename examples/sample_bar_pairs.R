endTime <- as.POSIXlt(Sys.time())
startTime <- strptime("20/3/2 11:16:16.683", "%d/%m/%y %H:%M:%OS")
st1 <- as.POSIXct(startTime)
et1 <- as.POSIXct(endTime)

barPairs = ttBarsQuotes(symbol = "EURUSD", barPeriodStr = "M1", startTime = st1)

barPairsRange = ttBarsQuotes(symbol = "EURUSD", barPeriodStr = "M1", startTime= st1, endTime = et1)