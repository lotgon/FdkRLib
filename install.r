if(!require("devtools") )
{
  install.packages("devtools")
  library(devtools)
  
}

# Use this command if you want to build package yourself
# install_github("hadley/devtools")
# library(devtools)
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



