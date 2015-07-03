ttConnect()
idMonitor <- ttQuotesRealTimeMonitor('EURUSD')
# Wait for some time before running this line
# it can be run multiple times and the snapshot reflects
snapshot <- ttQuotesRealTimeSnapshot(idMonitor)
View(snapshot)

ttQuotesRealTimeStopMonitoring(idMonitor)
