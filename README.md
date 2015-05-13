# FdkRLib
Added the SoftFX R wrapper package over FDK

# How to install it?
Look inside install.r file (you can copy/paste the content into your R environment).

For later sessions of R environment will require just to reload the library with this command:
library(FdkRLib)

# How to test it?
You have sample code inside examples/sample_bars.r with various snippets of code. 

A simple code sample code is the following:

ttConnect("", "", "")

quotes = ttGetQuotes("EURUSD", "2015-05-05", "2015-05-06", 1)

bars = ttGetBars("EURUSD", "Bid", "H1")

The data given by ttGetQuotes and ttGetBars is for now Data Frame.

