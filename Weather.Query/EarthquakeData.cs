using Dapper.Contrib.Extensions;
using System;
using Weather.EarthquakeDataService;

namespace Weather.Query
{
    [Table("Earthquake")]
    public class EarthquakeData :IRumble
    {
        [Key]
        public int EarthquakeId { get; set; }

        public DateTime EventTime { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public decimal Depth { get; set; }

        public decimal Magnitude { get; set; }

        public string MagnitudeType { get; set; }

        public int SeismicStations { get; set; }

        public decimal AzimuthalGap { get; set; }

        public decimal EpiCenterDistance { get; set; }

        public decimal RootMeanSquare { get; set; }

        public string DataContributorId { get; set; }

        public string NetworkIdentifier { get; set; }

        public DateTime RecentUpdateTime { get; set; }

        public string GeographicRegion { get; set; }

        public string SeismicEventType { get; set; }

        public decimal HorizontalError { get; set; }

        public decimal DepthError { get; set; }

        public decimal MagnitudeError { get; set; }

        public int MagniteOfEarthquake { get; set; }

        public string EventsReviewed { get; set; }

        public string LocationSource { get; set; }

        public string MagnitudeSource { get; set; }

    }
}
