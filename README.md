# FdkRLib
Added the SoftFX R wrapper package over FDK (Financial Development Kit)

# Prerequisites
If you see this error: "You are probably missing the Visual C++ Redistributable for Visual Studio 2013", then please download it from here:
https://www.microsoft.com/en-us/download/details.aspx?id=40784

# How to install it?
Look inside install.r file (you can copy/paste the content into your R environment).

For later sessions of R environment will require just to reload the library with this command:
library(FdkRLib)

# How to test it?
You have sample code inside examples/sample_bars.r with various snippets of code. 

A simple code sample code is the following:

bars = ttGetBars(symbol = "EURUSD", barPeriodStr = "M1", priceTypeStr = "Ask")

endTime <- as.POSIXlt(Sys.time())

startTime <- strptime("20/3/15 11:16:16.683", "%d/%m/%y %H:%M:%OS")

st1 <- as.POSIXct(startTime)

et1 <- as.POSIXct(endTime)

quotes <- ttGetQuotes("EURUSD", st1, et1, 1)

plot(quotes$ask, type="o")

The data given by ttGetQuotes and ttGetBars is for now Data Frame.

