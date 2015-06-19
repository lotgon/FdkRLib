using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftFX.Extended;

namespace RHost
{
    public static class FdkSessionInfo
    {
        private static DataFeed Feed
        {
            get { return FdkHelper.Wrapper.ConnectLogic.Feed; }
        }
        public static string GetSessionInfo()
        {
            SessionInfo sessionInfo = Feed.Server.GetSessionInfo();
            var result = FdkVars.RegisterVariable(sessionInfo, "SessionInfo");
            return result;
        }

        public static string PlatformCompany(string varName)
        {
            var session = FdkVars.GetValue<SessionInfo>(varName);
            return session.PlatformCompany;
        }
        public static string PlatformName(string varName)
        {
            var session = FdkVars.GetValue<SessionInfo>(varName);
            return session.PlatformName;
        }
        public static string TradingSessionId(string varName)
        {
            var session = FdkVars.GetValue<SessionInfo>(varName);
            return session.TradingSessionId;
        }
        public static string PlatformCompany(string varName)
        {
            var session = FdkVars.GetValue<SessionInfo>(varName);
            return session.PlatformCompany;
        }
        public static string PlatformCompany(string varName)
        {
            var session = FdkVars.GetValue<SessionInfo>(varName);
            return session.PlatformCompany;
        }
    }
}
