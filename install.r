installBinary <- function(fdkRLibPackage){
  basicUrl = "https://github.com/SoftFx/FdkRLib/raw/master/dist/"
  fullUrl = paste(basicUrl, fdkRLibPackage, sep = "")
  
  download.file(fullUrl, fdkRLibPackage)
  install.packages(fdkRLibPackage, repos = NULL, type = "source")
  file.remove(fdkRLibPackage)
}

installBinary("rClr_0.7-4.zip")
library(rClr)

installBinary("FdkRLib_1.0.20150513.zip")
library(FdkRLib)
