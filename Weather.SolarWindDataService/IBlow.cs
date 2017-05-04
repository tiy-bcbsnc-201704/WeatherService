using System;

namespace Weather.SolarWindDataService
{
    public interface IBlow
    {
        DateTime MeasurementDateTime { get; }
        decimal XCoordinate { get; }
        decimal YCoordinate { get; }
        decimal ZCoordinate { get; }
        decimal Longitude { get; }
        decimal Latitude { get; }
        decimal Temperature { get; }
    }
}
