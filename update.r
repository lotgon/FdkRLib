installBinaryHttr <- function(fdkRLibPackage){
  basicUrl = "https://github.com/SoftFx/FdkRLib/raw/master/dist/"
  fullUrl = paste(basicUrl, fdkRLibPackage, sep = "")
  localTempFile <- fdkRLibPackage
  r <-GET(fullUrl)
  bin <- content(r, "raw")
  writeBin(bin, localTempFile)
  
  install.packages(localTempFile, repos = NULL, type = "source")
  file.remove(localTempFile)
}

updatePackage <- function (packageVersion) {
  installBinaryHttr(packageVersion)
}
require(httr)
# Run code to package
updatePackage("FdkRLib_1.0.20150714.zip")

require(rClr)
require(FdkRLib)