using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace Weather.EarthquakeDataService
{
    public class InsertEarthQuack
    {
        internal void InsertEarthQuackM(Earthquake earthquake)
        {
            Earthquake _earthquakeInt = earthquake;
            string connectionstring = "Server=localhost;Database=WeatherService;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Insert(_earthquakeInt);
            }
        }
    }

    
}
