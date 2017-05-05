using System;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Xml.XPath;
using System.Globalization;
using System.Linq;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using System.Threading;

namespace Weather.WeatherDataService
{
   class Program
   {
      static void Main(string[] args)
      {
         while (true)
         {
            //  download the zip file...
            using (WebClient webClient = new WebClient())
            {
               DateTime today = DateTime.Now;
               DateTime observationDateTime = today;
               Console.WriteLine($"Start downloading file, {today}");
               webClient.Headers.Add("Accept", "text/html,application/xhtml + xml,application/xml; q = 0.9,image/webp,image/apng,*/*;q=0.8");
               webClient.Headers.Add("Accept-Encoding", "gzip, deflate");
               webClient.Headers.Add("Accept-Language", "en-US,en;q=0.8");
               webClient.Headers.Add("Cache-Control", "no-cache");
               webClient.Headers.Add("Host", "w1.weather.gov");
               webClient.Headers.Add("Pragma", "no-cache");
               webClient.Headers.Add("Referer", "http://w1.weather.gov/xml/current_obs/");
               webClient.Headers.Add("Upgrade-Insecure-Requests", "1");
               webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3088.0 Safari/537.36");
               webClient.DownloadFile("http://w1.weather.gov/xml/current_obs/all_xml.zip", "WeatherData.zip");
               Console.WriteLine($"Finish downloading file, {today}");
               Console.ReadLine();
            }
           // create the subfolder.....?
           // unzip the file
            Console.WriteLine("Start unzipping files");
            string xmlFilePath = "C:/Users/u700656/Source/Repos/WeatherService/Weather.WeatherDataService/bin/Debug/XML";
            ZipFile.ExtractToDirectory("WeatherData.zip", xmlFilePath);
            Console.WriteLine("Finish unzipping file");

            string filePath = "C:/Users/u700656/Source/Repos/WeatherService/Weather.WeatherDataService/bin/Debug/XML";

            string[] fileNameIncludePath = Directory.GetFiles(filePath);

            Console.WriteLine($"File count: { fileNameIncludePath.Length}");
            Console.WriteLine($"File name is: {fileNameIncludePath[0]}");

            for (int i = 1; i < fileNameIncludePath.Length; i += 1)
            {
               Console.WriteLine($"File name is: {fileNameIncludePath[i]}");
               Readxml(fileNameIncludePath[i]);
            }
            // delete folder ?
            Thread.Sleep(30000); // 60000 = 60 seconds           
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
         decimal temperatureValue = 0.00m;
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
               Console.WriteLine($"observation_time: {observation_time_rfc822.Value}");
               Console.WriteLine($"converted observation_time: {observationDateTime}");

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