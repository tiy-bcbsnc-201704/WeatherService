using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using Weather.EventNotifier;

namespace WeatherService.Desktop
{
    internal class QueryFacade
    {
        public QueryFacade(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int GetSolarWindCount()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingle<int>(@"
                    SELECT COUNT(SolarWindId)
                      FROM SolarWind
                ");
            }
        }

        public int GetEarthquakeCount()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingle<int>(@"
                    SELECT COUNT(EarthquakeId)
                      FROM Earthquake
                ");
            }
        }

        public int GetWeatherCount()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingle<int>(@"
                    SELECT COUNT(Id)
                      FROM WeatherDataService
                ");
            }
        }

        public IEnumerable<ServiceEvent> GetTopLogs()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<ServiceEvent>(@"
                    SELECT TOP 10
                           EventId
                         , Servicename
                         , EventDescription
                         , EventDateTime
                      FROM ServiceEvents
                  ORDER BY EventDateTime DESC
                ");
            }
        }

        private readonly string _connectionString;
    }
}