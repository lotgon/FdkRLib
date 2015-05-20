installBinary <- function(fdkRLibPackage){
  basicUrl = "https://github.com/SoftFx/FdkRLib/raw/master/dist/"
  fullUrl = paste(basicUrl, fdkRLibPackage, sep = "")
  localTempFile <-tempfile()
  download.file(fullUrl, localTempFile)
  install.packages(localTempFile, repos = NULL, type = "source")
  file.remove(localTempFile)
}

installBinary("rClr_0.7-4.zip")
library(rClr)

installBinary("FdkRLib_1.0.20150518.zip")
library(FdkRLib)