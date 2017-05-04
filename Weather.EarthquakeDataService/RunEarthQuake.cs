using System.Net;
using System.IO;
using System;
using Weather.EventNotifier;

namespace Weather.EarthquakeDataService
{
    internal class RunEarthQuake
    {
        //public RunEarthQuake()
        //{

        //}

        public void DoStuff(string connectionString)
        {
            string _connectionString = connectionString;
            DownloadFile();
            EventNotifier.EventHandler eh = new EventNotifier.EventHandler(_connectionString);
            eh.Record(ServiceName.EarthquakeService, "Earthquake table successfully updated");
            ReadEarthQuack();
        }

        private void DownloadFile()
        {
            using (WebClient webClient = new WebClient())
            {
                DateTime localdate = DateTime.Today;
                webClient.DownloadFile("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_hour.csv", "Earthquake.Dat");
            }
                
        }
        private void ReadEarthQuack()
        {

            filepath = @"C:\Users\u330542\Source\Repos\WeatherService\Weather.EarthquakeDataService\bin\Debug";
            filename = "Earthquake.csv";
            fullpath = Path.Combine(filepath, filename);

             using (StreamReader reader = File.OpenText(fullpath))
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
                        insertEarthQuack.InsertEarthQuackM(earthquake);
                    }
                }
            }
        }
        string filename;
        string filepath;
        string fullpath;
        string[] parts;
    }
}