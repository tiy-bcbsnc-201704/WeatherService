using System;

public interface IRumble
    {
    DateTime EventTime { get; }
    decimal Latitude { get; }
    decimal Longitude { get; }
    decimal Ddepth  { get; }
    decimal Magnitude  { get; }
    string MagnitudeType { get; }
    int SeismicStations { get; }
    decimal AzimuthalGap  { get; }
    decimal EpiCenterDistance { get; }
    decimal RootMeanSquare { get; }
    string DataContributorId { get; }
    string NetworkIdentifie { get; }
    DateTime RecentUpdateTime { get; }
    string GeographicRegion { get; }
    string SeismicEventType { get; }
    decimal HorizontalError { get; }
    decimal DepthError { get; }
    decimal MagnitudeError { get; }
    int MagniteOfEarthQuake { get; }
    string EventsReviewed { get; }
    string LocationSource { get; }
    string MagnitudeSource { get; }
}
