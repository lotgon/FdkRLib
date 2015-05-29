#region Uses

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using SoftFX.Extended;
using SoftFX.Extended.Events;
using SoftFX.Extended.Storage;

#endregion

namespace SharedFdkFunctionality
{
    public class FdkConnectLogic : IDisposable
    {
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        private readonly AutoResetEvent syncEvent = new AutoResetEvent(false);

        public FdkConnectLogic(string address, string username, string password)
        {
            Address = address;
            Username = username;
            Password = password;
            // create and initialize fix connection string builder
            Builder = new FixConnectionStringBuilder
            {
                TargetCompId = "EXECUTOR",
                ProtocolVersion = FixProtocolVersion.TheLatestVersion.ToString(),
                SecureConnection = false,
                Port = 5001,
                DecodeLogFixMessages = true,
                Address = address,
                Username = username,
                Password = password,
                FixEventsFileName = string.Format("{0}.trade.events.log", username),
                FixMessagesFileName = string.Format("{0}.trade.messages.log", username)
            };
            TradeWrapper = new FdkTradeWrapper();
            //this.Builder.ExcludeMessagesFromLogs = "W";
        }

        internal FixConnectionStringBuilder Builder { get; private set; }
        public DataFeed Feed { get; private set; }
        public DataFeedStorage Storage { get; set; }
        public FdkTradeWrapper TradeWrapper { get; set; }
        public string RootPath { get; set; }
        public bool Initialized { get; set; }

        public void Dispose()
        {
            if (null != Feed)
            {
                Feed.Stop();
                Feed.Dispose();
                Feed = null;
            }

            if (null != Storage)
            {
                Storage.Dispose();
                Storage = null;
            }
        }

        public void SetupPathsAndConnect(string rootPath)
        {
            if (Initialized)
            {
                throw new InvalidOperationException("Fdk seems to be initialized for second time");
            }
            Initialized = true;


            // create and specify log directory
            string root;
            if (string.IsNullOrEmpty(rootPath))
            {
                var assembly = Assembly.GetEntryAssembly();
                root = assembly == null ? Directory.GetCurrentDirectory() : assembly.Location;
                root = Path.GetDirectoryName(root);
                if (root == null)
                    throw new InvalidDataException("FDK assembly's directory seems to be invalid");
            }
            else
            {
                root = rootPath;
            }
            var logsPath = Path.Combine(root, "Logs\\Fix");
            Directory.CreateDirectory(logsPath);

            Builder.FixLogDirectory = logsPath;

            Feed = new DataFeed(Builder.ToString()) {SynchOperationTimeout = 60000};

            var storagePath = Path.Combine(root, "Storage");
            Directory.CreateDirectory(storagePath);

            Storage = new DataFeedStorage(storagePath, StorageProvider.Ntfs, Feed, true);
        }


        static void EnsureDirectoriesCreated(string LogPath)
        {
            if (!Directory.Exists(LogPath))
                Directory.CreateDirectory(LogPath);
        }

        public bool DoConnect()
        {
            EnsureDirectoriesCreated(Builder.FixLogDirectory);
            var connectionString = Builder.ToString();

            SetupTradeConnection(Builder.FixLogDirectory);

            Feed.Initialize(connectionString);

            var timeoutInMilliseconds = Feed.SynchOperationTimeout;
            return Feed.Start(timeoutInMilliseconds);
        }

        private void SetupTradeConnection(string logPath)
        {
            TradeWrapper = new FdkTradeWrapper();
            TradeWrapper.Connect(Address, Username, Password, logPath);

        }

        private void OnBalanceOperaiton(object sender, NotificationEventArgs<BalanceOperation> e)
        {
        }

        private void OnNofity(object sender, NotificationEventArgs e)
        {
        }

        private void OnAccountInfo(object sender, AccountInfoEventArgs e)
        {
        }

        private void OnSessionInfo(object sender, SessionInfoEventArgs e)
        {
        }

        private void OnPositionReport(object sender, PositionReportEventArgs e)
        {
        }

        private void OnExecutionReport(object sender, ExecutionReportEventArgs e)
        {
        }

        private void OnLogout(object sender, LogoutEventArgs e)
        {
        }

        private void OnLogon(object sender, LogonEventArgs e)
        {
            syncEvent.Set();
        }

        public void Disconnect()
        {
            Dispose();
        }
    }
}