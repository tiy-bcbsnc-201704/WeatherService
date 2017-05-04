using Dapper.Contrib.Extensions;
using System;

namespace Weather.SolarWindDataService
{
    [Table("SolarWind")]
    public class SolarWindDapper
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