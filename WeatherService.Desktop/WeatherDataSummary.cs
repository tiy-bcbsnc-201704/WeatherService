using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Weather.EventNotifier;

namespace WeatherService.Desktop
{
    public class WeatherDataSummary : INotifyPropertyChanged
    {
        internal WeatherDataSummary(QueryFacade facade)
        {
            _facade = facade;
            _logs = new List<ServiceEvent>();

            Task summarizer = new Task(() =>
            {
                try
                {
                    while (true)
                    {
                        EarthquakeCount = facade.GetEarthquakeCount();
                        SolarWindCount = facade.GetSolarWindCount();
                        WeatherCount = facade.GetWeatherCount();
                        TopLogs = facade.GetTopLogs();
                        Thread.Sleep(250);
                    }
                }
                catch (Exception) {}
            });
            summarizer.Start();
        }

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
                ServiceEvent valued = value.FirstOrDefault() ?? new ServiceEvent();
                ServiceEvent logged = _logs.FirstOrDefault() ?? new ServiceEvent();
                if (valued.EventId != logged.EventId)
                {
                    _logs = value;
                    FirePropertyChanged("TopLogs");
                }
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
        private readonly QueryFacade _facade;
    }
}