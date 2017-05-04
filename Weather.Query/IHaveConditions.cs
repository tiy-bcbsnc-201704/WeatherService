using System;
using System.Collections.Generic;
using Weather.EarthquakeDataService;
using Weather.SolarWindDataService;
using Weather.WeatherDataService;

namespace Weather.Query
{
    public interface IHaveConditions
    {
        DateTime When { get; }
        double Latitude { get; }
        double Longitude { get; }
        
        IEnumerable<IRumble> Earthquakes { get; }
        
        IEnumerable<IBlow> SolarWind { get; }
        
        IEnumerable<IHaveWeather> Weather { get; }
    }
}