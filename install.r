if(!require("devtools") )
{
  install.packages("devtools")
}

library(devtools)
if( !require("rClr") )
{
  install_github("SoftFx/rClr")
}
library(rClr)

install_github("SoftFx/FdkRLib")
library(FdkRLib)
if( !require("quantmod"))
{
  install_github("joshuaulrich/quantmod")
}
library(quantmod)
