using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using NLog;
using RHost.Shared;

namespace RHost
{
	public class FdkHelper
	{
        static FdkHelper()
        {
            Wrapper = new FdkWrapper();
        }
		public static int ConnectToFdk(string address, string login, string password, string path)
		{
			#if DEBUG
			//Library.Path = @"C:\Users\ciprian.khlud\Documents\R\win-library\3.2\FdkRLib\data";
			#endif

            //Debugger.Launch();

            var addr = String.IsNullOrEmpty(address)
			? "tpdemo.fxopen.com"
                : address;
			var loginStr = String.IsNullOrEmpty(login)
			? "59932"
                : login;
			var passwordString = String.IsNullOrEmpty(login)
			? "8mEx7zZ2"
                : password;

			try
			{
				Wrapper.Address = addr;
				Wrapper.Login = loginStr;
				Wrapper.Password = passwordString;
				var localPath = String.Empty;

				if (!String.IsNullOrEmpty(path))
				{
					var localPathInfo = new DirectoryInfo(path);
					localPath = localPathInfo.FullName;
				}

                Wrapper.Path = localPath;

                Wrapper.SetupBuilder();

				return Wrapper.Connect() ? 0 : -1;
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw;
			}
        }
        static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static FdkWrapper Wrapper { get; set; }

        public static void Disconnect()
        {
            Wrapper.Disconnect();
        }
        public static void WriteMessage(string message)
        {
			Console.WriteLine("FdkRLib: {0}", message);
        }

        public static Double GetCreatedEpoch(DateTime created)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            var span = (created.ToLocalTime() - epoch);
            return span.TotalSeconds;
        }

        public static Double GetCreatedEpochFromText(string createdTimeStr)
        {
            var created = DateTime.Parse(createdTimeStr, CultureInfo.InvariantCulture);
            return GetCreatedEpoch(created);
        }

        public static void DisplayDate(DateTime time)
        {
            MessageBox.Show(time.ToString());
        }


        public static DateTime GetCreatedEpoch(Double value)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            var created = epoch.AddSeconds(value);
            return created;
        }


        public static bool IsTimeZero(DateTime startTime)
        {
            return startTime.Year == 1970 && startTime.Month == 1 && startTime.Day == 1;
        }

        #region Accessors

        public static T? ParseEnumStr<T>(string text) where T : struct
        {
            T result;
			if (Enum.TryParse(text, out result))
				return result;
			else 
				return null;
        }

        public static T GetFieldByName<T>(string fieldName)
        {
            var barPeriodField = typeof(T).GetField(fieldName);
            if (barPeriodField == null)
                return default(T);

            var result = (T)barPeriodField.GetValue(null);

            return result;
        }
        #endregion
    }

}
 