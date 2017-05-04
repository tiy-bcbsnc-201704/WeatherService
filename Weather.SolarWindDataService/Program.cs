using Dapper.Contrib.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Threading;
using Weather.EventNotifier;

namespace Weather.SolarWindDataService
{
    class Program
    {
        static void Main(string[] args)
        {

            // Download the file into a string
            while (true)
            {
                using (WebClient webClient = new WebClient())
                {
                    //webClient.DownloadFile("http://services.swpc.noaa.gov/products/solar-wind/mag-5-minute.json", @"C:\Users\u872059\Downloads\SolarWind.json");
                    string solarWindData = webClient.DownloadString("http://services.swpc.noaa.gov/products/solar-wind/mag-5-minute.json");
                    //Console.WriteLine(solarWindData);

                    // Parse the JSON file data
                    JArray solarWindDataArray = JArray.Parse(solarWindData);

                    //Console.WriteLine(a[0]);
                    //Console.WriteLine(solarWindDataArray[1]);
                    //Console.WriteLine(solarWindDataArray[2]);

                    for (int i = 1; i < 3; i += 1)
                    {
                        List<object> windData = new List<object>(solarWindDataArray[i]);

                        //Console.WriteLine("------------------------------------");
                        //Console.WriteLine(windData[0]);
                        //Console.WriteLine(windData[1]);
                        //Console.WriteLine(windData[2]);
                        //Console.WriteLine(windData[3]);
                        //Console.WriteLine(windData[4]);
                        //Console.WriteLine(windData[5]);
                        //Console.WriteLine(windData[6]);
                        //Console.WriteLine("------------------------------------");
                        //Console.ReadLine();

                        string connectionString = "Server=LOCALHOST;Database=WeatherService;Trusted_Connection=True";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            SolarWind solarWind = new SolarWind();

                            solarWind.MeasurementDateTime = Convert.ToDateTime(windData[0].ToString());
                            solarWind.XCoordinate = Convert.ToDecimal(windData[1].ToString());
                            solarWind.YCoordinate = Convert.ToDecimal(windData[2].ToString());
                            solarWind.ZCoordinate = Convert.ToDecimal(windData[3].ToString());
                            solarWind.Longitude = Convert.ToDecimal(windData[4].ToString());
                            solarWind.Latitude = Convert.ToDecimal(windData[5].ToString());
                            solarWind.Temperature = Convert.ToDecimal(windData[6].ToString());

                            try
                            {
                                connection.Insert(solarWind);
                            }
                            catch (SqlException sqlEx)
                            {
                                if (sqlEx.Message.StartsWith("Violation of UNIQUE KEY constraint"))
                                {
                                    continue;
                                }
                            }
                        }
                    }

                    // Call the EventNotifier service to record the time the file was downloaded
                    EventNotifier.EventHandler eh = new EventNotifier.EventHandler();
                    eh.Record(ServiceName.SolarWindService, "SolarWind table update");
                    
                    Thread.Sleep(6000); // 60000 = 60 seconds
                }
            }
        }
    }
}
