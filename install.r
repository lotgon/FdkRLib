if(!require("devtools") )
{
  install.packages("devtools")
  library(devtools)
  
}

# Use this command if you want to build package yourself
install_github("hadley/devtools")
library(devtools)


if( !require("rClr") )
{
  # uncomment this if you want to use installation from source.
  # install_github("SoftFx/rClr")
  download.file("https://github.com/SoftFx/FdkRLib/raw/master/Lib/RClr/rClr_0.7-4.zip", "rClr_0.7-4.zip")
  install.packages("rClr_0.7-4.zip", repos = NULL, type = "source")
  file.remove("rClr_0.7-4.zip")
}
library(rClr)

install_github("SoftFx/FdkRLib")
library(FdkRLib)



