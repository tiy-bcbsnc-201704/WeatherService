using Dapper;
using Dapper.Contrib.Extensions;
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SolarWindData solarWind = new SolarWindData();
                IEnumerable<SolarWindData> solar = connection.Query<SolarWindData>(
                    "SELECT *" + 
                    "FROM SolarWindData " +
                    "Where Id = @when " +
                    "and Latitude = @latitude " +
                    "and Longitude = @longitude");

                WeatherData weatherData = new WeatherData();
                IEnumerable<WeatherData> weather = connection.Query<WeatherData>(
                    "SELECT *" +
                    "FROM WeatherDataService " +
                    "Where Id = @when " +
                    "and Latitude = @latitude " +
                    "and Longitude = @longitude");
            }
        }
    }
}
