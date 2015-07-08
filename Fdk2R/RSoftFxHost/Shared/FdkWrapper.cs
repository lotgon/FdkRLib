using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using log4net;
using SoftFX.Extended;
using SoftFX.Extended.Events;

namespace SharedFdkFunctionality
{
    public class FdkTradeWrapper
    {
        public void Connect(string address, string username, string password, string logPath)
        {
            EnsureDirectoriesCreated(logPath);

            // Create builder
            var builder = new FixConnectionStringBuilder
            {
                TargetCompId = "EXECUTOR",
                ProtocolVersion = FixProtocolVersion.TheLatestVersion.ToString(),
                SecureConnection = true,
                Port = 5004,
                //ExcludeMessagesFromLogs = "W",
                DecodeLogFixMessages = true,

                Address = address,
                Username = username,
                Password = password,

                FixLogDirectory = logPath,
                FixEventsFileName = string.Format("{0}.trade.events.log", username),
                FixMessagesFileName = string.Format("{0}.trade.messages.log", username)
            };
            Trade = new DataTrade
            {
                SynchOperationTimeout = 30000
            };
            var connectionString = builder.ToString();
            Trade.Initialize(connectionString);
            Trade.Logon += OnLogon;
            Trade.Start();
            var timeoutInMilliseconds = Trade.SynchOperationTimeout;
            if (!_syncEvent.WaitOne(timeoutInMilliseconds))
            {
                throw new TimeoutException("Timeout of logon waiting has been reached");
            }

        }

        public DataTrade Trade { get; set; }

        readonly AutoResetEvent _syncEvent = new AutoResetEvent(false);

        private void OnLogon(object sender, LogonEventArgs e)
        {
            _syncEvent.Set();
        }

        static void EnsureDirectoriesCreated(string logPath)
        {
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
        }

    }
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