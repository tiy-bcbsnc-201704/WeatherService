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
                    "SELECT *" + 
                    "FROM SolarWindData " +
                    "Where Id = @when " +
                    "and Latitude = @latitude " +
                    "and Longitude = @longitude");
                conditionreport.SolarWind = solar;

                WeatherData weatherData = new WeatherData();
                IEnumerable<WeatherData> weather = connection.Query<WeatherData>(
                    "SELECT *" +
                    "FROM WeatherDataService " +
                    "Where Id = @when " +
                    "and Latitude = @latitude " +
                    "and Longitude = @longitude");
                conditionreport.Weather = weather;

                EarthquakeData earthQuakeDate = new EarthquakeData();
                IEnumerable<EarthquakeData> earthQuake = connection.Query<EarthquakeData>(
                    "SELECT *" +
                    "FROM WeatherDataService " +
                    "Where Id = @when " +
                    "and Latitude = @latitude " +
                    "and Longitude = @longitude");
                conditionreport.Earthquakes = earthQuake;
            }
            return conditionreport;
        }
    }
}
