using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.WeatherDataService
{
    [Table("WeatherDataService")]
    public class WeatherDataService
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
