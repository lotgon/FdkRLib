#region Uses

using System;
using System.IO;
using System.Reflection;
using SoftFX.Extended;
using SoftFX.Extended.Storage;

#endregion

namespace SharedFdkFunctionality
{
    public class FdkConnectLogic : IDisposable
    {
		internal FixConnectionStringBuilder Builder { get; private set; }
        public DataFeed Feed { get; private set; }
		//protected DataFeedStorage Storage { get; private set; }
        public DataFeedStorage Storage { get; set; }
        public string RootPath { get; set; }

        public FdkConnectLogic()
        {
            // create and initialize fix connection string builder
            Builder = new FixConnectionStringBuilder
            {
                TargetCompId = "EXECUTOR",
                ProtocolVersion = FixProtocolVersion.TheLatestVersion.ToString(),
                SecureConnection = false,
                Port = 5001,
                DecodeLogFixMessages = true
            };
            //this.Builder.ExcludeMessagesFromLogs = "W";

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
            var is64Bit = Environment.Is64BitOperatingSystem;
            var intPtrSize = IntPtr.Size;
            Storage = new DataFeedStorage(storagePath, StorageProvider.Ntfs, Feed, true);
        }

        public bool Initialized { get; set; }


        public FdkConnectLogic(string address, string username, string password)
            : this()
        {
            Builder.Address = address;
            Builder.Username = username;
            Builder.Password = password;
        }

        public bool DoConnect()
        {
            var connectionString = Builder.ToString();
            Feed.Initialize(connectionString);

            var timeoutInMilliseconds = Feed.SynchOperationTimeout;
            return Feed.Start(timeoutInMilliseconds);
        }

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

        public void Disconnect()
        {
            Dispose();
        }
    }
}