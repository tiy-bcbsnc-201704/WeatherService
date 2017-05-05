using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace Weather.EarthquakeDataService
{
    public class InsertEarthQuack
    {
        private readonly string _connectionString;

        public InsertEarthQuack(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal void InsertEarthQuackM(Earthquake earthquake)
        {
            Earthquake _earthquakeInt = earthquake;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Insert(_earthquakeInt);
            }
        }
    }

    
}
