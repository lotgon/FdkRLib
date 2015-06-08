installBinary <- function(fdkRLibPackage){
  basicUrl = "https://github.com/SoftFx/FdkRLib/raw/master/dist/"
  fullUrl = paste(basicUrl, fdkRLibPackage, sep = "")
  # this line fails on an clean machine with weird binary internal package error.
  # localTempFile <-tempfile()
  localTempFile <- fdkRLibPackage
  download.file(fullUrl, localTempFile)
  install.packages(localTempFile, repos = NULL, type = "source")
  file.remove(localTempFile)
}

installBinary("rClr_0.7-4.zip")
library(rClr)

installBinary("FdkRLib_1.0.20150608.zip")
library(FdkRLib)

  install.packages('d:\Work\FDK\trunk\Concepts\Fdk2R\FdkGit\FdkRLib_1.0.20150608.zip', repos = NULL, type = "source")