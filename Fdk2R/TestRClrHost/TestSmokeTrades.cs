using System;
using System.IO;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using RHost;
using SoftFX.Extended;
using SoftFX.Extended.Events;

namespace TestRClrHost
{
    [TestFixture]
    public class TestSmokeTrades
    {
        [Test]
        public void TestGetTradeRecords()
        {
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.dev.soft-fx.eu", "100106", "123qwe123", ""));
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var bars = FdkTrade.GetTradeRecords("", "");
            var comission = FdkTrade.GetTradeAgentCommission(bars);
            FdkVars.Unregister(bars);
        }

        [Test]
        public void TestGetTradeRecordsFromStaging()
        {
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.st.soft-fx.eu", "100000", "123321", ""));
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var bars = FdkTrade.GetTradeRecords("", "");
            var comission = FdkTrade.GetTradeAgentCommission(bars);
            FdkVars.Unregister(bars);
        }
        [Test]
        public void TestGetTradeReportsAll()
        {
            Assert.AreEqual(0, FdkHelper.ConnectToFdk("tp.st.soft-fx.eu", "100000", "123321", ""));
            //Assert.AreEqual(0, FdkHelper.ConnectToFdk("", "", "", ""));
            var bars = FdkTradeReports.GetTradeTransactionReportAll();
            var comission = FdkTradeReports.GetTradeComment(bars);
            FdkVars.Unregister(bars);
        }

        [Test]
        public void TestDataTradeIsolation()
        {
            string address = "tpdemo.fxopen.com";
            string username = "59932";
            string password = "8mEx7zZ2";

            EnsureDirectoriesCreated();

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

                FixLogDirectory = LogPath,
                FixEventsFileName = string.Format("{0}.trade.events.log", username),
                FixMessagesFileName = string.Format("{0}.trade.messages.log", username)
            };
            var Trade = new DataTrade
            {
                SynchOperationTimeout = 30000
            };
            var connectionString = builder.ToString();
            Trade.Initialize(connectionString);
            Trade.Logon += OnLogon;
            Trade.Start();
            var timeoutInMilliseconds = Trade.SynchOperationTimeout;
            if (!syncEvent.WaitOne(timeoutInMilliseconds))
            {
                throw new TimeoutException("Timeout of logon waiting has been reached");
            }
            RunExample(Trade);
        }

        private void RunExample(DataTrade trade)
        {
            var records = trade.Server.GetTradeRecords();
        }

        static void EnsureDirectoriesCreated()
        {
            if (!Directory.Exists(LogPath))
                Directory.CreateDirectory(LogPath);
        }

        readonly AutoResetEvent syncEvent = new AutoResetEvent(false);
        private void OnLogon(object sender, LogonEventArgs e)
        {
            this.syncEvent.Set();
        }

        static string CommonPath
        {
            get
            {
                var assembly = Assembly.GetEntryAssembly();
                return assembly != null ? Path.GetDirectoryName(assembly.Location) : string.Empty;
            }
        }

        static string LogPath
        {
            get
            {
                return Path.Combine(CommonPath, "Logs");
            }
        }

    }
}