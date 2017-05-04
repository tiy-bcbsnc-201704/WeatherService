using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Weather.EarthquakeDataService
{
    public class Program
    {
        static void Main(string[] args)
        {

            DateTimeStyles styles;
            DateTime result;
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("en-US");

            string[] parts = null;
            string connectionString = "Server=localhost;Database=WeatherService;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        WebClient wc = new WebClient();
                        wc.DownloadFile("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_hour.csv", @"C:\Users\u224764\Downloads\all_hour.csv");
                    }
                    catch (WebException)
                    {
                        Console.WriteLine("File download is not successful. Try again!!");
                    }
                }

                // Reading from the CSV file//
                using (StreamReader reader = File.OpenText("C:/Users/u224764/Downloads/all_hour.csv"))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        parts = line.Split(',');
                        Console.WriteLine(string.Join("\t", parts));
                        Console.WriteLine($"EventTime{parts[0]}");
                        Console.ReadLine();

                        //Add records to DB
                        // string dateString = "2017-05-03T19:37:33.190Z";
                        Earthquake earthquake = new Earthquake();
                        styles = DateTimeStyles.AssumeLocal;
                         try
                         {
                            result = DateTime.Parse(parts[0], culture, styles);
                            Console.WriteLine("{0} converted to {1} {2}.",
                                              parts[0], result, result.Kind.ToString());
                            earthquake.EventTime = DateTime.Parse(parts[0], culture, styles);
                        }
                         catch (FormatException)
                         {
                            Console.WriteLine("Unable to convert {0} to a date and time.", parts[0]);
                         }

                        earthquake.Latitude = Convert.ToDecimal(parts[1].ToString());
                        earthquake.Longitude = Convert.ToDecimal(parts[2].ToString());
                        earthquake.Depth = Convert.ToDecimal(parts[3].ToString());
                        earthquake.Magnitude = Convert.ToDecimal(parts[4].ToString());


                        // connection.Insert(earthquake);
                    }
                }
            }
         }
      }
  }
