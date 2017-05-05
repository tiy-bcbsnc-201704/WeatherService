using System;
using System.ComponentModel;
using System.Text;
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
                    StringBuilder buffer = new StringBuilder();
                    buffer.Append("<html><head><style>html, body { font-family: Verdana; font-size: 8.5pt; }</style></head><body>");
                    foreach (ServiceEvent e in _summary.TopLogs)
                    {
                        buffer.Append($@"
                            <p>
                                <b>{e.ServiceName}</b><br>
                                <i>{e.EventDateTime.ToShortDateString()} {e.EventDateTime.ToShortTimeString()}</i><br>
                                <div>{e.EventDescription}</div>
                            </p>");
                    }
                    buffer.Append("</body></html>");
                    _htmlLogViewer.DocumentText = buffer.ToString();
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
