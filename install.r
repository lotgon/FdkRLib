installBinary <- function(fdkRLibPackage){
  basicUrl = "https://github.com/SoftFx/FdkRLib/raw/master/dist/"
  fullUrl = paste(basicUrl, fdkRLibPackage, sep = "")
  
  download.file(fullUrl, fdkRLibPackage)
  install.packages(fdkRLibPackage, repos = NULL, type = "source")
  file.remove(fdkRLibPackage)
  
}


installBinary("rClr_0.7-4.zip")
library(rClr)

install_github("SoftFx/FdkRLib")
library(FdkRLib)



