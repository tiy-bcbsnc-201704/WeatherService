using System;
using System.ComponentModel;
using System.Windows.Forms;
using Weather.EventNotifier;

namespace WeatherService.Desktop
{
    public partial class MainWindow : Form
    {
        public MainWindow(WeatherDataSummary summary)
            : this()
        {
            _summary = summary;

            _summary.PropertyChanged += HandleSummaryChange;
        }

        private void HandleSummaryChange(object sender, PropertyChangedEventArgs args)
        {
            Invoke((MethodInvoker)delegate {
                if (args.PropertyName == "EarthquakeCount")
                {
                    _earthquakeCount.Text = _summary.EarthquakeCount.ToString();
                }
                if (args.PropertyName == "SolarWindCount")
                {
                    _solarWindCount.Text = _summary.SolarWindCount.ToString();
                }
                if (args.PropertyName == "WeatherCount")
                {
                    _weatherCount.Text = _summary.WeatherCount.ToString();
                }
                if (args.PropertyName == "TopLogs")
                {
                    _logViewer.Text = "";
                    foreach (ServiceEvent e in _summary.TopLogs)
                    {
                        _logViewer.Text += e.ServiceName + Environment.NewLine;
                        _logViewer.Text += e.EventDescription + Environment.NewLine;
                        _logViewer.Text += Environment.NewLine;
                    }
                }
            });
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly WeatherDataSummary _summary;
    }
}
