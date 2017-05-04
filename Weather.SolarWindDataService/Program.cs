using Dapper.Contrib.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
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
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["SolarWindDataServices"].ConnectionString;

            while (true)
            {
                using (WebClient webClient = new WebClient())
                {

                    // Download the file into a string
                    string solarWindData = webClient.DownloadString("http://services.swpc.noaa.gov/products/solar-wind/mag-5-minute.json");

                    // Parse the JSON file data in an array
                    JArray solarWindDataArray = JArray.Parse(solarWindData);

                    // We know there are only 2 array downloaded at any time
                    // the "zeroith" row contians the row headers - we  do not need this row 
                    for (int i = 1; i < 3; i += 1)
                    {
                        // Create list that contains all fields in a row
                        List<object> windData = new List<object>(solarWindDataArray[i]);
                          
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            SolarWind solarWind = new SolarWind();
                            // Set database varibles equal to data downloaded (and converted)
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
                    EventNotifier.EventHandler eh = new EventNotifier.EventHandler(connectionString);
                    eh.Record(ServiceName.SolarWindService, "SolarWind table update");

                    Thread.Sleep(6000); // 60000 = 60 seconds
                }
            }
        }
    }
    //webClient.DownloadFile("http://services.swpc.noaa.gov/products/solar-wind/mag-5-minute.json", @"C:\Users\u872059\Downloads\SolarWind.json");

    //Console.WriteLine(a[0]);
    //Console.WriteLine(solarWindDataArray[1]);
    //Console.WriteLine(solarWindDataArray[2]);
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
}
