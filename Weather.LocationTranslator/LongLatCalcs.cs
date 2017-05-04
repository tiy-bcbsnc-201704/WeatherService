
using System.Data.SqlClient;


namespace Weather.LocationTranslator
{
    public class LongLatCalcs
    {

        public string StateForLongLat(double longitude, double latitude)
        {

            string longLatState = "";
            //longLatState = "AK";
            //return longLatState;


            // determine longLatState
            ///*
            while (true)
            {
                double plusOrminus = 0;
                double maxplusOrminus = 5.0;

                longLatState = CheckCoords(longitude, latitude, plusOrminus);  // select count(*)

                if (longLatState != "") // any found)
                {
                    return longLatState;
                }
                if (plusOrminus == maxplusOrminus)
                {
                    return "XX";
                }
                plusOrminus += .10;
            }
        }




        public string CheckCoords(double longitude, double latitude, double plusorminus)
        {
            string connectionString = "Server=localhost;Database=WeatherService;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
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

                    if (reader.FieldCount == 0)
                    {
                        return "";
                    }
                    return reader[0].ToString();

                }
                finally
                {

                    connection.Close();
                    connection.Dispose();

                }
            }
        }




    }
}

