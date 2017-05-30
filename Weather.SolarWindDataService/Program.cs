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

            EventNotifier.EventHandler log = new EventNotifier.EventHandler(connectionString);
            log.Record(ServiceName.SolarWindService, "Started");
            log.Record(ServiceName.SolarWindService, "Will refresh every 1 minute.");

            while (true)
            {
                using (WebClient webClient = new WebClient())
                {

                    // Download the file into a string
                    string solarWindData = webClient.DownloadString("http://services.swpc.noaa.gov/products/solar-wind/mag-5-minute.json");
                    //string solarWindData = webClient.DownloadString("http://services.swpc.noaa.gov/products/solar-wind/mag-7-day.json");
                    // Parse the JSON file data in an array
                    JArray solarWindDataArray = JArray.Parse(solarWindData);

                    bool errorFree;

                    // We know there are only 2 array downloaded at any time
                    // the "zeroith" row contians the row headers - we  do not need this row 
                    for (int i = 1; i < solarWindDataArray.Count; i += 1)
                    {
                        JArray dataRow = (JArray)solarWindDataArray[i];

                        // Create list that contains all fields in a row
                        List<JValue> windData = new List<JValue>();
                        foreach (JValue value in dataRow)
                        {
                            windData.Add(value);
                        }

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            SolarWind solarWind = new SolarWind();

                            // Test fields for null values. if null default to 0.00 value and set indicator to exclude row of data.
                            // Set database varibles equal to data downloaded (and converted)

                            errorFree = true;

                            if (windData[1].Value == null)
                            {
                                windData[1] = new JValue(0.00);
                                errorFree = false;
                            }
                            if (windData[2].Value == null)
                            {
                                windData[2] = new JValue(0.00);
                                errorFree = false;
                            }
                            if (windData[3].Value == null)
                            {
                                windData[3] = new JValue(0.00);
                                errorFree = false;
                            }
                            if (windData[4].Value == null)
                            {
                                windData[4] = new JValue(0.00);
                                errorFree = false;
                            }
                            if (windData[5].Value == null)
                            {
                                windData[5] = new JValue(0.00);
                                errorFree = false;
                            }
                            if (windData[6].Value == null)
                            {
                                windData[6] = new JValue(0.00);
                                errorFree = false;
                            }

                            solarWind.MeasurementDateTime = Convert.ToDateTime(windData[0].ToString());
                            solarWind.XCoordinate = Convert.ToDecimal(windData[1].ToString());
                            solarWind.YCoordinate = Convert.ToDecimal(windData[2].ToString());
                            solarWind.ZCoordinate = Convert.ToDecimal(windData[3].ToString());
                            solarWind.Longitude = Convert.ToDecimal(windData[4].ToString());
                            solarWind.Latitude = Convert.ToDecimal(windData[5].ToString());
                            solarWind.Temperature = Convert.ToDecimal(windData[6].ToString());


                            if (errorFree)
                            {
                                try
                                {
                                    connection.Insert(solarWind);
                                }
                                catch (SqlException sqlEx)
                                {
                                    if (sqlEx.Message.StartsWith("Violation of UNIQUE KEY constraint"))
                                    {
                                        log.Record(ServiceName.SolarWindService, $"Skipping record for {solarWind.MeasurementDateTime.ToString("yyyy-MM-dd hh:mm:ss")}");
                                        continue;
                                    }
                                    throw;
                                }
                            }
                        }
                    }

                    // Call the EventNotifier service to record the time the file was downloaded
                    log.Record(ServiceName.SolarWindService, "SolarWind table successfully updated");

                    Thread.Sleep(60000); // 60000 = 60 seconds
                }
            }
        }
    }
}
