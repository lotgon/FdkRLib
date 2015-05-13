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
                Password = passwordString,
                
            }; 
            Wrapper = wrapper;
            FdkBars.Wrapper = Wrapper;

            var localPathInfo = new DirectoryInfo(path);
            var localPath = localPathInfo.FullName;

            if (wrapper.Connect(localPath))
            {
                return 0;
            }
            return -1;
        }

        public static FdkWrapper Wrapper { get; set; }
    }
}
 