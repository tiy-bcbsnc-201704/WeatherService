using System;

namespace Weather.EarthquakeDataService
{
    public interface IRumble
    {
        int EarthquakeId {get;}
        DateTime EventTime { get; }
        decimal Latitude { get; }
        decimal Longitude { get; }
        decimal Depth { get; }
        decimal Magnitude { get; }
        string MagnitudeType { get; }
        int SeismicStations { get; }
        decimal AzimuthalGap { get; }
        decimal EpiCenterDistance { get; }
        decimal RootMeanSquare { get; }
        string DataContributorId { get; }
        string NetworkIdentifier { get; }
        DateTime RecentUpdateTime { get; }
        string GeographicRegion { get; }
        string SeismicEventType { get; }
        decimal HorizontalError { get; }
        decimal DepthError { get; }
        decimal MagnitudeError { get; }
        int MagniteOfEarthquake { get; }
        string EventsReviewed { get; }
        string LocationSource { get; }
        string MagnitudeSource { get; }
    }
}
