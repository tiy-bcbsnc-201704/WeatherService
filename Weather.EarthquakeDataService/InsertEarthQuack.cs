using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace Weather.EarthquakeDataService
{
    public class InsertEarthQuack
    {
        public void InsertEarthQuackM(Earthquake earthquake, string connectionString)
        {
            Earthquake _earthquakeInt = earthquake;
            string _connectionString = connectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Insert(_earthquakeInt);
            }
        }
    }

    
}
