using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RHost;

namespace QuoteL2Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbxAddress.Text = MainSetting.Default.Address;
            tbxLogin.Text = MainSetting.Default.Login;
            maskedTextBox1.Text = MainSetting.Default.Password;
            tbxCachesTextBox.Text = MainSetting.Default.CachesPath;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveCredentialsToSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveCredentialsToSettings();
            var settings = MainSetting.Default;
            try
            {
                FdkHelper.ConnectToFdk(settings.Address, settings.Login, settings.Password, settings.CachesPath);
                MessageBox.Show("Connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Exception: {0}", ex));
                
            }
        }

        private void SaveCredentialsToSettings()
        {
            MainSetting.Default.Address = tbxAddress.Text.Trim();
            MainSetting.Default.Login = tbxLogin.Text.Trim();
            MainSetting.Default.Password = maskedTextBox1.Text.Trim();
            MainSetting.Default.CachesPath = tbxCachesTextBox.Text.Trim();

            MainSetting.Default.Save();
        }
    }
}

