using Dapper.Contrib.Extensions;
using System;

namespace Weather.Query
{
    [Table("WeatherDataService")]
    class WeatherData
    {
        [Key]
        public int id { get; set; }

        public string StationID { get; set; }

        public string Location { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public DateTime ObservationTime { get; set; }

        public string WeatherCondition { get; set; }

        public decimal Temperature { get; set; }

        public int Humidity { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
