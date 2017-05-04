using System;
using System.Collections.Generic;
using Weather.SolarWindDataService;
using Weather.WeatherDataService;

namespace Weather.Query
{
    public class ConditionReport : IHaveConditions
    {
        public DateTime When { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public IEnumerable<IRumble> Earthquakes { get; set; }

        public IEnumerable<IBlow> SolarWind { get; set; }

        public IEnumerable<IHaveWeather> Weather { get; set; }

    }
}
