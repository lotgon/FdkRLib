using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using log4net;
using SoftFX.Extended;
using SoftFX.Extended.Events;

namespace TickTrader.DeveloperConsole.Connectors
{
    public class FdkConnector
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof (FdkConnector));
        public string Address { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        private FdkConnectLogic _connectLogic;

        public bool IsConnected { get; set; }

        public static FdkConnector Instance {get { return StaticInstance; }}
        
        private static readonly FdkConnector StaticInstance = new FdkConnector();

		private List<SymbolInfo> _symbols = new List<SymbolInfo>();

        public bool Connect()
        {
            _connectLogic = new FdkConnectLogic(Address, Login, Password);
            _connectLogic.Feed.SessionInfo += OnSessionInfo;
            _connectLogic.Feed.SymbolInfo += OnSymbolInfo;
            _connectLogic.Feed.Logon += OnLogon;
            _connectLogic.Feed.Logout += OnLogout;
            var connectionSuccessful = _connectLogic.DoConnect();
            if (!connectionSuccessful)
	        {
                _logger.Warn("");
		        return false;
	        }
            var start = DateTime.Now;
            while (!IsConnected && (DateTime.Now - start).Seconds < 5)
            {
                Thread.Sleep(100);
            }
            
			return IsConnected;
        }

        public void Disconnect()
        {
            if (!IsConnected)
                return;
			//_logger.Warn("FdkConnector.Disconnecting");
			_connectLogic.Dispose();
            IsConnected = false;
        }

        void OnSymbolInfo(object sender, SymbolInfoEventArgs e)
        {
            _symbols = e.Information.ToList();
            _logger.DebugFormat("Symbols information is received. Symbols count = {0}", _symbols.Count);
			
			// to us means also that symbols are already availiable
			IsConnected = true;
		}

		private void OnSessionInfo(object sender, SessionInfoEventArgs e)
		{
            _logger.Debug(e.Information);
		}
		private void OnLogon(object sender, LogonEventArgs e)
		{
            _logger.DebugFormat("OnLogon(): {0}", e);
		}
		private void OnLogout(Object sender, LogoutEventArgs e)
		{
            //_logger.InfoFormat("OnLogout() ");
		    IsConnected = false;
		}

        public Bar GetClosestBar(string symbol, DateTime startTime)
        {
            var bars = new Bars(_connectLogic.Feed, symbol, PriceType.Bid, BarPeriod.S1, startTime, 1);
			var bar = bars.FirstOrDefault();
            return bar;
		}

		public List<SymbolInfo> GetSymbols()
		{
			return _symbols;
		}

        public Bar GetHistorical(string symbol)
        {
            var bars = _connectLogic.Storage.Online.GetBars(symbol, PriceType.Ask, BarPeriod.M1, DateTime.Now, -1000).ToArray();
            /*
            var bars = new Bars(_connectLogic.Storage.Online, symbol,
                PriceType.Bid, BarPeriod.S1, DateTime.Now, -1000);
             */
            var bar = bars.FirstOrDefault();
            return bar;
        }
    }
}