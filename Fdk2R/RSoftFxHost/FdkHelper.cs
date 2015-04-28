using System.Diagnostics;
using System.Windows.Forms;
using R2Cs;

namespace RHost
{
    public class FdkHelper
    {
        public  static void TestInvoke()
        {
            MessageBox.Show("SoftFX integration is working");
        }

        public static int ConnectToFdk(string address, string login, string password)
        {
            var addr = string.IsNullOrEmpty(address)
                ? "tpdemo.fxopen.com"
                : address;
            var loginStr = string.IsNullOrEmpty(login)
                ? "59932"
                : login;
            var passwordString = string.IsNullOrEmpty(login)
                ? "8mEx7zZ2"
                : password;
            var wrapper = new FdkWrapper()
            {
                Address = addr,
                Login = loginStr,
                Password = passwordString
            }; 
            Wrapper = wrapper;
            FdkBars.Wrapper = Wrapper;

            if (wrapper.Connect())
            {
                return 0;
            }
            return -1;
        }

        public static FdkWrapper Wrapper { get; set; }
    }
}
 