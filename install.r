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

installBinaryHttr <- function(fdkRLibPackage){
  require(httr)
  basicUrl = "https://github.com/SoftFx/FdkRLib/raw/master/dist/"
  fullUrl = paste(basicUrl, fdkRLibPackage, sep = "")
  # this line fails on an clean machine with weird binary internal package error.
  # localTempFile <-tempfile()
  localTempFile <- fdkRLibPackage
  r <-GET(fullUrl)
  bin <- content(r, "raw")
  writeBin(bin, localTempFile)
  
  install.packages(localTempFile, repos = NULL, type = "source")
  file.remove(localTempFile)
}


installAllPackages <- function(packageVersion){
  setInternet2(TRUE)
  
  installBinary("rClr_0.7-4.zip")
  installBinary(packageVersion)  
}

#Use this function if you have issues with default 
# 'installAllPackages' function
installAllPackagesHttr <- function (packageVersion) {
  install.packages("httr", repos='http://cran.us.r-project.org')
  installBinaryHttr("rClr_0.7-4.zip")
  installBinaryHttr(packageVersion)
}

# Sets for R environment the command to allow downloading https files
installAllPackages("FdkRLib_1.0.20150629.zip")
# uncomment the next line if you have issues downloading with previous function
# installAllPackagesHttr("FdkRLib_1.0.20150629.zip")

library(rClr)
library(FdkRLib)