using System;
using System.Windows.Forms;

namespace RHost.Views
{
    public partial class DateTimeChooserForm : Form
    {
        public DateTimeChooserForm()
        {
            InitializeComponent();
             ViewModel = new DateTimeChooserViewModel();
        }

        internal readonly DateTimeChooserViewModel ViewModel;

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewModel.Accepted = true;
            ViewModel.ChosenTime = dateTimePicker1.Value;
            Close();
        }
    }
}
