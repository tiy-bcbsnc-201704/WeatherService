using System.Net;
using System.IO;
using System;
using Weather.EventNotifier;
using System.Data.SqlClient;
using Dapper;

namespace Weather.EarthquakeDataService
{
    public class RunEarthQuake
    {
        public RunEarthQuake(IRecordAnEvent logger)
        {
            _logger = logger;
        }

        public void DoStuff(string connectionString, string earthquackFileName)
        {
            _connectionString = connectionString;
            _earthquackFileName = earthquackFileName;

            FileDownloadUrl();

            _logger.Record(ServiceName.EarthquakeService, "Earthquake table successfully updated");
            ReadEarthQuack();

            _logger.Record(ServiceName.EarthquakeService, "Database update completed.");
        }

        public void FileDownloadUrl()
        {
            string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_hour.csv";
            int timeoutInMilliSec = 1000;
            var success = FileDownloader.DownloadFile(url, fileFullPath, timeoutInMilliSec, _logger);
        }

        public void ReadEarthQuack()
        {
             using (StreamReader reader = File.OpenText(fileFullPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    parts = line.Split(',');
                    if (parts[0] != "time")
                    {
                        SetFields setFields = new SetFields();
                        Earthquake earthquake = setFields.SetField(parts);
                        networkIdentifier = parts[11];
                        if (Count() == 0)
                        {
                            InsertEarthQuack insertEarthQuack = new InsertEarthQuack();
                            insertEarthQuack.InsertEarthQuackM(earthquake, _connectionString);
                        }
                        else
                        {
                            _logger.Record(ServiceName.EarthquakeService, $"Found existing record: {networkIdentifier}");
                        }
                    }
                }
            }
        }

        public int Count()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                SELECT count(*)
                    FROM Earthquake 
                    Where NetworkIdentifier = @networkIdentifier";
#pragma warning disable CS0618 // Type or member is obsolete
                command.Parameters.Add("@networkIdentifier", networkIdentifier);
#pragma warning restore CS0618 // Type or member is obsolete
                return (int)command.ExecuteScalar();
            }
        }

        string[] parts;
        string _connectionString;
        string _earthquackFileName;
        public static string desktoppath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string filename = "Earthquake.csv";
        public static string fileFullPath = Path.Combine(desktoppath, filename);
        public static string networkIdentifier;
        private readonly IRecordAnEvent _logger;
    }
}