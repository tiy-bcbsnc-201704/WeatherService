using Dapper.Contrib.Extensions;
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
        static decimal ParseOrZeroDecimal(string input)
        {
            decimal output = 0;
            decimal.TryParse(input, out output);
            return output;
        }
        static int ParseOrZeroInt(string input)
        {
            int output = 0;
            int.TryParse(input, out output);
            return output;
        }
        static void Main(string[] args)
        {

            DateTimeStyles styles;
            //DateTime result;
            CultureInfo culture;
            decimal defaultToZeroDecimal  = 0;
            int defaultToZeroInt = 0;
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

                      //  line = line.Replace("\"", " ");
                      //  string[] parts = string.Split(line [] { ",\"" }, StringSplitOptions.None);

                        parts = line.Split(',');

                        Console.WriteLine(string.Join("\t", parts));
                        Console.WriteLine($"EventTime{parts[0]}");
                        Console.ReadLine();

                        //Add records to DB
 
                        Earthquake earthquake = new Earthquake();
                        styles = DateTimeStyles.AssumeLocal;
                        earthquake.EventTime = DateTime.Parse(parts[0], culture, styles);
                        earthquake.Latitude = ParseOrZeroDecimal(parts[1]);
                        earthquake.Longitude = ParseOrZeroDecimal(parts[2]);
                        earthquake.Depth = ParseOrZeroDecimal(parts[3]);
                        earthquake.Magnitude =  ParseOrZeroDecimal(parts[4]);                                        
                        earthquake.MagnitudeType =  parts[5].ToString();
                        earthquake.SeismicStations = ParseOrZeroInt(parts[6]);
                        earthquake.AzimuthalGap = ParseOrZeroDecimal(parts[7]);
                        earthquake.EpiCenterDistance = ParseOrZeroDecimal(parts[8]); ;
                        earthquake.RootMeanSquare = ParseOrZeroDecimal(parts[9]);
                        earthquake.DataContributorId =  parts[10].ToString();
                        earthquake.NetworkIdentifier = parts[11].ToString();                
                        earthquake.RecentUpdateTime = DateTime.Parse(parts[12], culture, styles);
                        earthquake.GeographicRegion = parts[13].ToString().Trim();
                        earthquake.SeismicEventType = parts[15].ToString();
                        earthquake.HorizontalError = ParseOrZeroDecimal(parts[16]);
                        earthquake.DepthError = ParseOrZeroDecimal(parts[17]);
                        earthquake.MagnitudeError = ParseOrZeroDecimal(parts[18]);
                        earthquake.MagniteOfEarthquake = ParseOrZeroInt(parts[19]);
                        earthquake.EventsReviewed = parts[20].ToString();
                        earthquake.LocationSource = parts[21].ToString();
                        earthquake.MagnitudeSource = parts[22].ToString();
                        connection.Insert(earthquake);
                    }
                }
            }
         }
      }
  }
