#' Gets the session fields
#' 
#' @export
ttSessionInfo <- function(){
  varName = GetSessionInfo()
  
  platformCompany = PlatformCompany(varName)
  platformName = PlatformName(varName)
  tradingSessionId = TradingSessionId(varName)
  closeTime = CloseTime(varName)
  endTime = EndTime(varName)
  openTime = OpenTime(varName)
  startTime = StartTime(varName)
  serverTimeZoneOffset = ServerTimeZoneOffset(varName)
  status = Status(varName)
  
  UnregisterVar(varName)
  df = data.frame(platformCompany, platformName, tradingSessionId, 
	closeTime, endTime, openTime, startTime,
	serverTimeZoneOffset, status)      
}

# ****
#' Gets the bars as requested
#' 
GetSessionInfo <- function() {
  clrCallStatic('RHost.FdkSessionInfo', 'GetSessionInfo')
}

PlatformCompany <- function(varName)
{
	clrCallStatic('RHost.FdkSessionInfo', 'PlatformCompany', varName)
}

PlatformName <- function(varName)
{
	clrCallStatic('RHost.FdkSessionInfo', 'PlatformName', varName)
}

TradingSessionId <- function(varName)
{
	clrCallStatic('RHost.FdkSessionInfo', 'TradingSessionId', varName)
}

CloseTime <- function(varName)
{
	clrCallStatic('RHost.FdkSessionInfo', 'CloseTime', varName)
}

EndTime <- function(varName)
{
	clrCallStatic('RHost.FdkSessionInfo', 'EndTime', varName)
}

OpenTime <- function(varName)
{
	clrCallStatic('RHost.FdkSessionInfo', 'OpenTime', varName)
}

StartTime <- function(varName)
{
	clrCallStatic('RHost.FdkSessionInfo', 'StartTime', varName)
}

IsClosed <- function(varName)
{
	clrCallStatic('RHost.FdkSessionInfo', 'IsClosed', varName)
}

ServerTimeZoneOffset <- function(varName)
{
	clrCallStatic('RHost.FdkSessionInfo', 'ServerTimeZoneOffset', varName)
}

Status <- function(varName)
{
	clrCallStatic('RHost.FdkSessionInfo', 'Status', varName)
}
