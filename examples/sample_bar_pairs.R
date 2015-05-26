endTime <- as.POSIXlt(Sys.time())
startTime <- strptime("20/3/2 11:16:16.683", "%d/%m/%y %H:%M:%OS")
st1 <- as.POSIXct(startTime)
et1 <- as.POSIXct(endTime)
barPairs = ttGetBarPairs(symbol = "EURUSD", barPeriodStr = "M1", startTimeEpoch = st1)


barPairsRange = ttGetBarPairsRange(symbol = "EURUSD", barPeriodStr = "M1", startTimeEpoch = st1, endTimeEpoch = et1)