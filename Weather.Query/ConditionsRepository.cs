using System;
using System.Data.SqlClient;

namespace Weather.Query
{
    class ConditionsRepository : IProvideConditions
    {
        public IHaveConditions Query(DateTime when, double latitude, double longitude)
        {
            string connectionString = "Server=localhost;Database=WeatherService;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

            }


        }


    }
}
