using Dapper.Contrib.Extensions;
using System;
using Weather.WeatherDataService;

namespace Weather.Query
{
    [Table("WeatherDataService")]
    public class WeatherData :IHaveWeather
    {
        [Key]
        public int Id { get; set; }

        public string StationId { get; set; }

        public string Location { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime ObservationTime { get; set; }

        public string WeatherCondition { get; set; }

        public double Temperature { get; set; }

        public int Humidity { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
