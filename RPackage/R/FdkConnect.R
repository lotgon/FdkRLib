#' Initialize the CLR runtime and loads the FDK host assembly
#' 
#' @export 
ttInit <- function() {
  library(rClr)
  
  fileName <-system.file("data","RHost.dll", package="FdkRLib")
  clrLoadAssembly(fileName)
}

#' Connects to a TT server
#' 
#' @param address Url of the running server
#' @param login Account number you login
#' @param password Password for the account you login
#' @export
ttConnect <- function(address = "", login= "", password= "", fdkPath = "") {
  ttInit()
  rClr::clrCallStatic('RHost.FdkHelper', 'ConnectToFdk', address, login, password, fdkPath)
}

#' Disconnect from a TT server
#' 
#' @param address Url of the running server
#' @param login Account number you login
#' @param password Password for the account you login
#' @export
ttDisconnect <- function() {
  rClr::clrCallStatic('RHost.FdkHelper', 'Disconnect')
}

#' Displays a DateTime
#' 
#' @param dateToShow An R datetime
#' @export
ttDisplayDate <- function(dateToShow) {
  rClr::clrCallStatic('RHost.FdkHelper', 'DisplayDate', dateToShow)
}
