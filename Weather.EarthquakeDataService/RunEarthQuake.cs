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
        public void DoStuff(string connectionString, string earthquackFileName)
        {
            _connectionString = connectionString;
            _earthquackFileName = earthquackFileName;
            FileDownloadUrl();
            EventNotifier.EventHandler eh = new EventNotifier.EventHandler(_connectionString);
            eh.Record(ServiceName.EarthquakeService, "Earthquake table successfully updated");
            ReadEarthQuack();
            Console.WriteLine("Database Update Completed with Downloaded File");
        }

        public static void FileDownloadUrl()
        {
            string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_hour.csv";
            int timeoutInMilliSec = 1000;
            var success = FileDownloader.DownloadFile(url, fileFullPath, timeoutInMilliSec);
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
                        InsertEarthQuack insertEarthQuack = new InsertEarthQuack();
                        insertEarthQuack.InsertEarthQuackM(earthquake,_connectionString);
                    }
                }
            }
        }

        string[] parts;
        string _connectionString;
        string _earthquackFileName;
        public static string desktoppath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string filename = "Earthquake.csv";
        public static string fileFullPath = Path.Combine(desktoppath, filename);
    }
}