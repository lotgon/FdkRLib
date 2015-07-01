# FdkRLib
Added the SoftFX R wrapper package over FDK (Financial Development Kit)

# Prerequisites
If you see this error: "You are probably missing the Visual C++ Redistributable for Visual Studio 2013", then please download it from here:
https://www.microsoft.com/en-us/download/details.aspx?id=40784

# How to install it?
Look inside [install.r](https://github.com/SoftFx/FdkRLib/blob/master/install.r)  file (you can copy/paste the content into your R environment).

For later sessions of R environment will require just to reload the library with this command:
library(FdkRLib)

# How to test it?
You have sample code inside examples/sample_bars.r with various snippets of code. 

A simple code sample code is the following:

trades = ttTrades()
bars = ttBars("EURUSD", barCount = 1000000)
barPairs = ttBarPairs('EURUSD')
now <-as.POSIXct(Sys.time())
prevNow <-as.POSIXct(Sys.time()-1000)
qt = ttQuotes('EURUSD', startTime = prevNow, endTime=now)
quotesHistory <- ComputeQuoteHistory('EURUSD', startTime = prevNow, endTime=now, 1)
qt2= ttQuotesLevel2('EURUSD', prevNow, now)

Follow this link with expanded example and output:
http://rpubs.com/ciplogic/89507
