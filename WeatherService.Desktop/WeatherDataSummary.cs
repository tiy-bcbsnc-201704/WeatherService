using System.Collections.Generic;
using System.ComponentModel;
using Weather.EventNotifier;

namespace WeatherService.Desktop
{
    public class WeatherDataSummary : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int EarthquakeCount
        {
            get { return _earthquakeCount; }
            set
            {
                _earthquakeCount = value;
                FirePropertyChanged("EarthquakeCount");
            }
        }

        public int SolarWindCount
        {
            get { return _solarWindCount; }
            set
            {
                _solarWindCount = value;
                FirePropertyChanged("SolarWindCount");
            }
        }

        public int WeatherCount
        {
            get { return _weatherCount; }
            set
            {
                _weatherCount = value;
                FirePropertyChanged("WeatherCount");
            }
        }

        public IEnumerable<ServiceEvent> TopLogs
        {
            get { return _logs; }
            set
            {
                _logs = value;
                FirePropertyChanged("TopLogs");
            }
        }

        private void FirePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        private int _earthquakeCount;
        private int _solarWindCount;
        private int _weatherCount;
        private IEnumerable<ServiceEvent> _logs;
    }
}