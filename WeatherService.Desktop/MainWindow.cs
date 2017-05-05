using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Weather.EarthquakeDataService;
using Weather.EventNotifier;
using Weather.LocationTranslator;
using Weather.Query;
using Weather.SolarWindDataService;
using Weather.WeatherDataService;

namespace WeatherService.Desktop
{
    public partial class MainWindow : Form
    {
        public MainWindow(WeatherDataSummary summary, LongLatCalcs translator, IProvideConditions repo)
            : this()
        {
            _repo = repo;
            _translator = translator;
            _summary = summary;
            _summary.PropertyChanged += HandleSummaryChange;

            for (int i = 0; i <= (int)StateCode.XX; i += 1)
            {
                _currentState.Items.Add((StateCode)i);
            }
            _currentState.SelectedIndexChanged += HandleStateChange;
            _currentState.SelectedIndex = 0;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HandleStateChange(object sender, EventArgs e)
        {
            string selectedCode = _currentState.SelectedItem.ToString();
            StateCode code = (StateCode)Enum.Parse(typeof(StateCode), selectedCode);
            GeographicBounds bounds = _translator.BoundsForState(code);
            _latitude.Minimum = bounds.MinimumLatitude;
            _latitude.Maximum = bounds.MaximumLatitude;
            _longitude.Minimum = bounds.MinimumLongitude;
            _longitude.Maximum = bounds.MaximumLongitude;
        }

        private void HandleSummaryChange(object sender, PropertyChangedEventArgs args)
        {
            try
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
                        buffer.Append("<html><head><link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/foundation/6.2.4/foundation.min.css\"></head><body>");
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
            catch (Exception) {}
        }

        private void HandleFetch(object sender, EventArgs e)
        {
            DateTime when = _when.Value;
            double lat = Convert.ToDouble(_latitude.Value);
            double lon = Convert.ToDouble(_longitude.Value);

            IHaveConditions conditions = _repo.Query(when, lat, lon);

            StringBuilder buffer = new StringBuilder();
            buffer.Append("<html><head><link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/foundation/6.2.4/foundation.min.css\"></head><body>");
            buffer.Append("<h2>Solar Winds</h2><table><thead><tr><th>Temp</th><th>X</th><th>Y</th><th>Z</th></thead><tbody>");
            foreach (IBlow wind in conditions.SolarWind)
            {
                buffer.Append($"<tr><td>{wind.Temperature}</td><td>{wind.XCoordinate}</td><td>{wind.YCoordinate}</td><td>{wind.ZCoordinate}</td></tr>");
            }
            buffer.Append("</tbody></table>");
            buffer.Append("<h2>Weather</h2><table><thead><tr><th>Temp</th><th>Humidity</th><th>Location</th><th>Station Id</th></thead><tbody>");
            foreach (IHaveWeather weather in conditions.Weather)
            {
                buffer.Append($"<tr><td>{weather.Temperature}</td><td>{weather.Humidity}</td><td>{weather.Location}</td><td>{weather.StationId}</td></tr>");
            }
            buffer.Append("</tbody></table>");
            buffer.Append("<h2>Earthquake Data</h2><table><thead><tr><th>Depth</th><th>Magnitude</th><th>Epicenter Distance</th><th>Magnitude Type</th></thead><tbody>");
            foreach (IRumble quake in conditions.Earthquakes)
            {
                buffer.Append($"<tr><td>{quake.Depth}</td><td>{quake.Magnitude}</td><td>{quake.EpiCenterDistance}</td><td>{quake.MagnitudeType}</td></tr>");
            }
            buffer.Append("</tbody></table>");
            buffer.Append("</body></html>");
            _searchResults.DocumentText = buffer.ToString();
        }

        private readonly WeatherDataSummary _summary;
        private readonly LongLatCalcs _translator;
        private readonly IProvideConditions _repo;
    }
}
