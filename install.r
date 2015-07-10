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


installAllPackages <- function (packageVersion) {
  installBinaryHttr("rClr_0.7-4.zip")
  installBinaryHttr(packageVersion)
}

# Step 1: may require to restart R enviornment. 
# Run it before you install packages. Should be run once
install.packages("httr", repos='http://cran.us.r-project.org')
install.packages("data.table", repos='http://cran.us.r-project.org')
require(httr)

# Run it before you install packages. Should be run once
installAllPackages("FdkRLib_1.0.20150629.zip")

library(rClr)
library(FdkRLib)