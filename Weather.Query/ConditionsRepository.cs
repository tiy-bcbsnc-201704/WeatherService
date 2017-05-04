using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Weather.Query
{
    public class ConditionsRepository : IProvideConditions
    {
       public IHaveConditions Query(DateTime when, double latitude, double longitude)
        {
            string connectionString = "Server=localhost;Database=WeatherService;Integrated Security=True";
            ConditionReport conditionreport = new ConditionReport();
            conditionreport.When = when;
            conditionreport.Latitude = latitude;
            conditionreport.Longitude = longitude;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SolarWindData solarWind = new SolarWindData();
                IEnumerable<SolarWindData> solar = connection.Query<SolarWindData>(
                    @"SELECT SolarWindId  
                          , MeasurementDateTime
                          , XCoordinate 
                          , YCoordinate
                          , ZCoordinate
                          , Longitude
                          , Latitude
                          , Temperature
                       FROM SolarWindData 
                      WHERE MeasurementDateTime = @when  
                        AND Latitude = @latitude  
                        AND Longitude = @longitude");
                conditionreport.SolarWind = solar;

                WeatherData weatherData = new WeatherData();
                IEnumerable<WeatherData> weather = connection.Query<WeatherData>(
                   @"SELECT   Id
                            , StationId
                            , Location
                            , Latitude
                            , Longitude
                            , ObservationTime
                            , WeatherCondition
                            , Temperature
                            , Humidity
                            , CreationDateTime
                       FROM WeatherDataService  
                      WHERE ObservationTime = @when  
                        AND Latitude = @latitude 
                        AND Longitude = @longitude");
                conditionreport.Weather = weather;

                EarthquakeData earthQuakeDate = new EarthquakeData();
                IEnumerable<EarthquakeData> earthQuake = connection.Query<EarthquakeData>(
                    @"SELECT  Id
                            , EventTime
                            , Latitude
                            , Longitude
                            , Depth
                            , Magnitude
                            , MagnitudeType
                            , SeismicStations
                            , AzimuthalGap
                            , EpiCenterDistance
                            , RootMeanSquare
                            , DataContributorId
                            , NetworkIdentifier
                            , RecentUpdateTime
                            , GeographicRegion
                            , SeismicEventType
                            , HorizontalError
                            , DepthError
                            , MagnitudeError
                            , MagniteOfEarthquake
                            , EventsReviewed
                            , LocationSource
                            , MagnitudeSource
                        FROM WeatherDataService 
                       WHERE EventTime = @when  
                         AND Latitude  = @latitude 
                         AND Longitude = @longitude");
                conditionreport.Earthquakes = earthQuake;
            }
            return conditionreport;
        }
    }
}
