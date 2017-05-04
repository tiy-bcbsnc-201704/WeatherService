using Dapper.Contrib.Extensions;
using System;
using Weather.SolarWindDataService;

namespace Weather.Query
{
    [Table("SolarWind")]
    public class SolarWindData :IBlow
    {
        [Key]
        public int SolarWindId { get; set; }

        public DateTime MeasurementDateTime { get; set; }

        public decimal XCoordinate { get; set; }

        public decimal YCoordinate { get; set; }

        public decimal ZCoordinate { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public decimal Temperature { get; set; }

    }
}
