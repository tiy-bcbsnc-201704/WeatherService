using System.Net;
using System.IO;
using System;
using Weather.EventNotifier;

namespace Weather.EarthquakeDataService
{
    public class RunEarthQuake
    {
        public void DoStuff(string connectionString, string earthquackFileName)
        {
            //DownloadFile();

            _connectionString   = connectionString;
            _earthquackFileName = earthquackFileName;
            EventNotifier.EventHandler eh = new EventNotifier.EventHandler(_connectionString);
            eh.Record(ServiceName.EarthquakeService, "Earthquake table successfully updated");

            ReadEarthQuack();
        }

        //public void DownloadFile()
        //{
        //    using (WebClient webClient = new WebClient())
        //    {
        //        DateTime localdate = DateTime.Today;
        //        webClient.DownloadFile("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_hour.csv", "Earthquake.Dat");
        //    }
                
        //}
        public void ReadEarthQuack()
        {
             using (StreamReader reader = File.OpenText(_earthquackFileName))
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

    }
}