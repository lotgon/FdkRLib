using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using RHost.Shared;
using log4net;
using SoftFX.Extended;
using SoftFX.Extended.Events;

namespace RHost.Shared
{
    public class FdkWrapper
    {
        public bool Connect(string rootPath)
        {
            if (IsConnected)
            {
                ConnectLogic.Disconnect();
            }
            ConnectLogic = new FdkConnectLogic(Address, Login, Password)
            {
                RootPath = rootPath
            };
            ConnectLogic.SetupPathsAndConnect(rootPath);
            ConnectLogic.Feed.CacheInitialized += OnCacheInitialize;
            ConnectLogic.Feed.SessionInfo += OnSessionInfo;
            ConnectLogic.Feed.SymbolInfo += OnSymbolInfo;
            ConnectLogic.Feed.Logon += OnLogon;
            ConnectLogic.Feed.Logout += OnLogout;
            var connectionSuccessful = ConnectLogic.DoConnect();
            if (!connectionSuccessful)
            {
                Logger.Warn("");
                return false;
            }
            var start = DateTime.Now;
            while (!IsConnected && (DateTime.Now - start).Seconds < 180)
            {
                Thread.Sleep(100);
            }

            return IsConnected;
        }

        private void OnCacheInitialize(object sender, CacheEventArgs e)
        {
            IsConnected = true;
        }

        public void Disconnect()
        {
            if (!IsConnected)
                return;
            //_logger.Warn("FdkConnector.Disconnecting");
            ConnectLogic.Dispose();
            IsConnected = false;
        }
        private void OnSymbolInfo(object sender, SymbolInfoEventArgs e)
        {
            _symbols = e.Information.ToList();
            Logger.DebugFormat("Symbols information is received. Symbols count = {0}", _symbols.Count);

            // to us means also that symbols are already availiable
            IsConnected = true;
        }

        private void OnSessionInfo(object sender, SessionInfoEventArgs e)
        {
            Logger.Debug(e.Information);
        }
        private void OnLogon(object sender, LogonEventArgs e)
        {
            Logger.DebugFormat("OnLogon(): {0}", e);
            
        }
        private void OnLogout(Object sender, LogoutEventArgs e)
        {
            //_logger.InfoFormat("OnLogout() ");
            IsConnected = false;
        }

        private List<SymbolInfo> _symbols = new List<SymbolInfo>();


        public string Address { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public FdkConnectLogic ConnectLogic { get; private set; }

        private static readonly ILog Logger = LogManager.GetLogger(typeof(FdkConnector));
        public bool IsConnected { get; set; }

        public List<SymbolInfo> Symbols
        {
            get { return _symbols; }
            set { _symbols = value; }
        }
    }
}