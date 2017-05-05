using Dapper.Contrib.Extensions;
using System;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Xml.XPath;

namespace Weather.WeatherDataService
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //using (WebClient Webclient = new WebClient())
                //{
                //    Console.WriteLine("downloading file");
                //    Webclient.Headers.Add("Accept", "text/html,application/xhtml + xml,application/xml; q = 0.9,image/webp,image/apng,*/*;q=0.8");
                //    Webclient.Headers.Add("Accept-Encoding", "gzip, deflate");
                //    Webclient.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                //    Webclient.Headers.Add("Cache-Control", "no-cache");
                //    Webclient.Headers.Add("Host", "w1.weather.gov");
                //    Webclient.Headers.Add("Pragma", "no-cache");
                //    Webclient.Headers.Add("Referer", "http://w1.weather.gov/xml/current_obs/");
                //    Webclient.Headers.Add("Upgrade-Insecure-Requests", "1");
                //    Webclient.Headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3088.0 Safari/537.36");
                //    Webclient.DownloadFile("http://w1.weather.gov/xml/current_obs/all_xml.zip", "Data.zip");

                //    Console.WriteLine("Please press ENTER to continue.");
                //    Console.ReadLine();
                //}

                //CREATE THE FOLDER
                //    Console.WriteLine("Unzipping file");
                //    ZipFile.ExtractToDirectory("Data.zip", "C:/Users/u847301/Source/Repos/WeatherService/Weather.WeatherDataService/bin/Debug/XML");
                //    Console.WriteLine("Please press ENTER to continue.");

                //  while loop
                string filePath = "C:/Users/u847301/Source/Repos/WeatherService/Weather.WeatherDataService/bin/Debug/XML";

                string[] fileNameIncludePath = Directory.GetFiles(filePath);
                // .Select(Path.GetFileName)
                // .ToArray();

                Console.WriteLine($"File count: { fileNameIncludePath.Length}");
                Console.WriteLine($"File name is: {fileNameIncludePath[0]}");

                for (int i = 1; i < fileNameIncludePath.Length; i += 1)
                {
                    Console.WriteLine($"File name is: {fileNameIncludePath[i]}");
                    Readxml(fileNameIncludePath[i]);

                }

                //DELETE FOLDER HERE
                Thread.Sleep(6000); // 60000 = 60 seconds
            }

        }

        public static void Readxml(string filePath)
        {
            decimal latitudeValue = 0.00m;
            decimal longitudeValue = 0.00m;
            string stationIDValue = "";
            string locationValue = "";
            DateTime today = DateTime.Now;
            DateTime observationDateTime = today;
            string weatherConditionValue = "";
            decimal temperatureValue = 0;
            int humidityValue = 0;


      string content = null;
         using (StreamReader reader = new StreamReader(filePath))
         {
            content = reader.ReadToEnd();
         }

         using (StreamWriter writer = new StreamWriter(filePath))
         {
            writer.Write(content.Replace("& ", "&amp; "));
         } 

            XPathDocument doc = new XPathDocument(filePath);
            XPathNavigator nav = doc.CreateNavigator();

            while (true)
            {
                foreach (XPathNavigator latitude in nav.Select("current_observation/latitude"))
                {
                    latitudeValue = (decimal)latitude.ValueAsDouble;
                    Console.WriteLine($"latitude: {latitude.ValueAsDouble}");
                }
                if (latitudeValue != 0.00m)
                {
                    Console.WriteLine($"latitude: {latitudeValue}");
                }
                else
                {
                    Console.WriteLine($"No latitude");
                    break;
                }

                foreach (XPathNavigator longitude in nav.Select("current_observation/longitude"))
                {
                    longitudeValue = (decimal)longitude.ValueAsDouble;
                    Console.WriteLine($"longitude: {longitude.ValueAsDouble}");
                }
                if (longitudeValue != 0.00m)
                {
                    Console.WriteLine($"longitude: {longitudeValue}");
                }
                else
                {
                    Console.WriteLine($"No longitude");
                    break;
                }

                foreach (XPathNavigator station_id in nav.Select("current_observation/station_id"))
                {
                    Console.WriteLine($"station_id: {station_id.Value}");
                    stationIDValue = station_id.Value;

                }
                foreach (XPathNavigator location in nav.Select("current_observation/location"))
                {
                    locationValue = location.Value;
                    if (locationValue.Contains("&"))
                    {
                        Console.WriteLine($"Bad location");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"location: {location.Value}");
                        locationValue = location.Value;
                    }
                }
                foreach (XPathNavigator observation_time_rfc822 in nav.Select("current_observation/observation_time_rfc822"))
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    observationDateTime = DateTime.ParseExact(observation_time_rfc822.Value, "ddd, dd MMM yyyy HH:mm:ss zzz", provider);
                   // DateTime today = DateTime.Now;
                    Console.WriteLine($"observation_time: {observation_time_rfc822.Value}");
                    Console.WriteLine($"converted observation_time: {observationDateTime}");
                    //Console.WriteLine($"today: {today}");
                }
                foreach (XPathNavigator weather in nav.Select("current_observation/weather"))
                {
                    Console.WriteLine($"weather: {weather.Value}");
                    weatherConditionValue = weather.Value;
                }
                foreach (XPathNavigator temp_f in nav.Select("current_observation/temp_f"))
                {
                    Console.WriteLine($"temp: {temp_f.ValueAsDouble}");
                }
                foreach (XPathNavigator relative_humidity in nav.Select("current_observation/relative_humidity"))
                {
                    Console.WriteLine($"humidity: {relative_humidity.ValueAsInt}");
                }
                //  InsertIntoDatabase();

                string connectionString = "Server=localhost;Database=WeatherService;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    WeatherDataService WeatherDataService = new WeatherDataService();
                    //styles = DateTimeStyles.AssumeLocal;
                    //    WeatherDataService.EventTime = DateTime.Parse(parts[0], culture, styles);
                    WeatherDataService.StationID = stationIDValue;
                    WeatherDataService.Location = locationValue;
                    WeatherDataService.Latitude = latitudeValue;
                    WeatherDataService.Longitude = longitudeValue;
                    WeatherDataService.ObservationTime = observationDateTime;
                    WeatherDataService.WeatherCondition = weatherConditionValue;
                    WeatherDataService.Temperature = temperatureValue;
                    WeatherDataService.Humidity = humidityValue;
                    WeatherDataService.CreationDateTime = today;
                    connection.Insert(WeatherDataService);
                }

                break;
            }
        }


    }
}
