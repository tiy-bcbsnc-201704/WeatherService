using Dapper.Contrib.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace Weather.SolarWindDataService
{
    class Program
    {
        static void Main(string[] args)
        {

            // Download the file into a string
            using (WebClient webClient = new WebClient())
            {
                //webClient.DownloadFile("http://services.swpc.noaa.gov/products/solar-wind/mag-5-minute.json", @"C:\Users\u872059\Downloads\SolarWind.json");
                string SolarWindData = webClient.DownloadString("http://services.swpc.noaa.gov/products/solar-wind/mag-5-minute.json");
                Console.WriteLine(SolarWindData);

                // Parse the JSON file data
                JArray a = JArray.Parse(SolarWindData);
                //Console.WriteLine(a[0]);
                Console.WriteLine(a[1]);
                Console.WriteLine(a[2]);

                // Call the EventNotifier service to record the time the file was downloaded


                // Connect to the database
                string connectionString = "Server=LOCALHOST;Database=WeatherService;Trusted_Connection=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SolarWindDapper solarWind = new SolarWindDapper();
                    connection.Insert(new SolarWindDapper
                    {
                        MeasurementDateTime = solarWind.MeasurementDateTime,
                        XCoordinate = solarWind.XCoordinate,
                        YCoordinate = solarWind.YCoordinate,
                        ZCoordinate = solarWind.ZCoordinate,
                        Longitude = solarWind.Longitude,
                        Latitude = solarWind.Latitude,
                        Temperature = solarWind.Temperature
                    });
                    //IEnumerable<SolarWindDapper> solarWinds = connection.GetAll<SolarWindDapper>();


                    //foreach (SolarWindDapper rowOfData in solarWinds)
                    //{
                    //    Console.WriteLine($"{(DateTime)rowOfData.MeasurementDateTime} {(decimal)rowOfData.XCoordinate}");
                    //}
                    











                    ////Open the file              
                    //var stream = File.OpenText(@"C:\Users\u872059\Downloads\SolarWind.json");
                    ////Read the file              
                    //string st = stream.ReadToEnd();
                    //var jsonArray = JArray.Parse(st);

                    ////List<Treatment> treatments = JsonConvert.DeserializeObject<List<Treatment>>(Server.MapPath("~/Content/treatments.json")); 


                    //foreach (var item in jsonArray)
                    //{
                    //    JObject ob = new JObject(item);
                    //    foreach (var t in ob.Values<string>())
                    //    {
                    //        JObject oo = new JObject(t);
                    //        foreach (var x in oo)
                    //        {
                    //            Console.WriteLine("item");
                    //        }
                    //    }
                    //}
                }
            }
        }
    }
}
