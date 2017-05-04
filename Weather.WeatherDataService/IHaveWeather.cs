using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.WeatherDataService
{
    public interface IHaveWeather
    {
        int Id { get; set; }
        string StationId { get; set; }
        string Location { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        DateTime ObservationTime { get; set; }
        string WeatherCondition { get; set; }
        double Temperature { get; set; }
        int Humidity { get; set; }
        DateTime CreationDateTime { get; set; }

    }
}
