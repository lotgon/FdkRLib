using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using SharedFdkFunctionality;

namespace RHost
{
    public class FdkHelper
    {
        public  static void TestInvoke()
        {
            MessageBox.Show("SoftFX integration is working");
        }
        public static int ConnectToFdk(string address, string login, string password, string path)
        {
#if DEBUG
            //Library.Path = @"C:\Users\ciprian.khlud\Documents\R\win-library\3.2\FdkRLib\data";
#endif
            var addr = String.IsNullOrEmpty(address)
                ? "tpdemo.fxopen.com"
                : address;
            var loginStr = String.IsNullOrEmpty(login)
                ? "59932"
                : login;
            var passwordString = String.IsNullOrEmpty(login)
                ? "8mEx7zZ2"
                : password;
            if (Wrapper == null)
            {
                var wrapper = new FdkWrapper()
                {
                    Address = addr,
                    Login = loginStr,
                    Password = passwordString,

                };
                Wrapper = wrapper;
            }

            string localPath = String.Empty;

            if (!String.IsNullOrEmpty(path))
            {
                var localPathInfo = new DirectoryInfo(path);
                localPath = localPathInfo.FullName;
            }
            if (Wrapper.Connect(localPath))
            {
                return 0;
            }
            return -1;
        }

        public static FdkWrapper Wrapper { get; set; }

        public static void Disconnect()
        {
            Wrapper.Disconnect();
        }

        public static Double GetCreatedEpoch(DateTime created)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            TimeSpan span = (created.ToLocalTime() - epoch);
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
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            var created = epoch.AddSeconds(value);
            return created;
        }

        #region Accessors

        public static T? ParseEnumStr<T>(string text) where T : struct
        {
            T result;
            if (!Enum.TryParse(text, out result))
                return null;
            return result;
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
 