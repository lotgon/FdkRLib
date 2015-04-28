using System;
using System.Linq;
using System.Windows;
using RDotNet;
using SoftFX.Extended;

namespace FdkRTest.Dialogs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainViewModel ViewModel
        {
            get { return (MainViewModel) DataContext; }
        }

        public MainWindow()
        {
            InitializeComponent();

            var loginWindow = new LoginDialog();
            var resultLogin = loginWindow.ShowDialog() ?? false;
            if (!resultLogin)
            {
                Environment.Exit(0);
                return;
            }
            ViewModel.Wrapper = loginWindow.ViewModel.Wrapper;
        }

        public void Setup()
        {
            var wrapper = ViewModel.Wrapper;

            var engine = ViewModel.Engine;
            wrapper.ConnectLogic.Feed.Tick += (o, args) =>
            {
                Action act = () =>
                {
                    if (string.IsNullOrEmpty(ViewModel.LineOfScript))
                    {
                        return;
                    }
                    try
                    {
                        NumericVector meanHigh = engine.Evaluate(ViewModel.LineOfScript).AsNumeric();
                        ViewModel.ResultScript = meanHigh.ToList().First().ToString();
                    }
                    catch (Exception ex)
                    {
                        ViewModel.ResultScript = ex.Message;
                    }
                };
                Application.Current.Dispatcher.Invoke(act);
            };
        }

        private void OnBarsCall(object sender, RoutedEventArgs e)
        {
            var engine = ViewModel.Engine;
            var wrapper = ViewModel.Wrapper;
            var bars = wrapper.ConnectLogic.Storage.Online.GetBars("EURUSD", PriceType.Ask, BarPeriod.M1, DateTime.Now, -1000000).ToArray();

            NumericVector lows = engine.CreateNumericVector(bars.Select(b => b.Low).ToArray());
            engine.SetSymbol("bar_lows", lows);
            NumericVector high = engine.CreateNumericVector(bars.Select(b => b.High).ToArray());
            engine.SetSymbol("bar_high", high);
            NumericVector opens = engine.CreateNumericVector(bars.Select(b => b.Open).ToArray());
            engine.SetSymbol("bar_opens", opens);
            NumericVector volumes = engine.CreateNumericVector(bars.Select(b => b.Volume).ToArray());
            engine.SetSymbol("bar_volumes", volumes);
        }

        private void OnScriptTick(object sender, RoutedEventArgs e)
        {
            ViewModel.LineOfScript = ViewModel.ScriptToRun;
        }
    }
}
