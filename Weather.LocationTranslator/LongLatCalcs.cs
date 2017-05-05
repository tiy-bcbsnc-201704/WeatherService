using Dapper;
using System;
using System.Data.SqlClient;

namespace Weather.LocationTranslator
{
    public class LongLatCalcs
    {

        private string _connectionString;


        public LongLatCalcs(string connectionString)
        {
            _connectionString = connectionString;
        }

        public GeographicBounds BoundsForState(StateCode code)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingle<GeographicBounds>(@"
                    SELECT MIN(Latitude) AS MinimumLatitude
                         , MAX(Latitude) AS MaximumLatitude
	                     , MIN(Longitude) AS MinimumLongitude
	                     , MAX(Longitude) AS MaximumLongitude
                      FROM LongLatLocs
                     WHERE StateCode = @Code
                ", new { Code = code.ToString() });
            }
        }


        public GeographicCenter CenterOfState(StateCode code)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingle<GeographicCenter>(@"
                    SELECT (SUM(Latitude) / COUNT(StateCode)) AS CenterLatitude
                           , (SUM(Longitude) / COUNT(StateCode)) AS CenterLongitude
                      FROM LongLatLocs
                     WHERE StateCode = @Code 
                ", new { Code = code.ToString() });
            }
        }


        public StateCode StateForLongLat(double longitude, double latitude)
        {


            string longlatState = "";
            double plusOrminus = 0;

            // !! search control !! 
            double incrplusOrminus = 0.1;
            double maxplusOrminus = 5.0;


            while (true)
            {

                longlatState = CheckCoords(longitude, latitude, plusOrminus);
                // Console.WriteLine($"Call: {longitude},{latitude},{plusOrminus} got {longlatState}");

                if (longlatState != "ZZ")
                {
                    // return longlatState;
                    return (StateCode)Enum.Parse(typeof(StateCode), longlatState);
                }
                if (plusOrminus >= maxplusOrminus)
                {
                    // return "XX";   
                    return (StateCode)Enum.Parse(typeof(StateCode), "XX");
                }
                plusOrminus += incrplusOrminus;
            }


        }




        public string CheckCoords(double longitude, double latitude, double plusorminus)
        {

            //string _connectionString = "Server=localhost;Database=WeatherService;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                    Select StateCode, COUNT(*) From LongLatLocs Where
                           (Longitude >= @longitude - @plusorminus and Longitude <= @longitude + @plusorminus) and
                           (Latitude  >= @latitude  - @plusorminus and Latitude  <= @latitude  + @plusorminus) 
                           Group By StateCode Order By 2 Desc";

                command.Parameters.AddWithValue("@longitude", longitude);
                command.Parameters.AddWithValue("@latitude", latitude);
                command.Parameters.AddWithValue("@plusorminus", plusorminus);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows == false)
                {
                    return "ZZ";
                }

                reader.Read();
                return reader.GetValue(0).ToString();

            }
        }




    }
}

