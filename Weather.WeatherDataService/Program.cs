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
using Weather.EventNotifier;
using System.Configuration;

namespace Weather.WeatherDataService
{
   class Program
   {
      static void Main(string[] args)
      {
         string connectionString;
         connectionString = ConfigurationManager.ConnectionStrings["WeatherDataService"].ConnectionString;

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
            }

            // create the subfolder.....
            string directorName = Directory.GetCurrentDirectory();
            string subDirectoryName = "\\xmls";
            Directory.CreateDirectory("xmls");

            string xmlFilePath = directorName + subDirectoryName;
            Directory.Delete(xmlFilePath, true);

                // unzip the file
            ZipFile.ExtractToDirectory("WeatherData.zip", xmlFilePath);

            string[] fileNameIncludePath = Directory.GetFiles(xmlFilePath);

            for (int i = 1; i < fileNameIncludePath.Length; i += 1)
            {
               Readxml(fileNameIncludePath[i], connectionString);
            }

            // Call the EventNotifier service to record the time the file was downloaded
            EventNotifier.EventHandler eh = new EventNotifier.EventHandler(connectionString);
            eh.Record(ServiceName.WeatherService, "WeatherDataService table successfully updated");

            // Delete the subfolder and files
            Directory.Delete(xmlFilePath, true);
            Thread.Sleep(3600000); // 3600000 = one hour                     
         }
      }

      public static void Readxml(string filePath, string connectionString)
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

         // reassign & to &amp so XML can be read
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
            }
            if (latitudeValue == 0.00m)
            { break; }

            foreach (XPathNavigator longitude in nav.Select("current_observation/longitude"))
            {
               longitudeValue = (decimal)longitude.ValueAsDouble;
            }
            if (longitudeValue == 0.00m)
            { break; }

            foreach (XPathNavigator station_id in nav.Select("current_observation/station_id"))
            {
               stationIDValue = station_id.Value;

            }

            foreach (XPathNavigator location in nav.Select("current_observation/location"))
            {
               locationValue = location.Value;
            }

            foreach (XPathNavigator observation_time_rfc822 in nav.Select("current_observation/observation_time_rfc822"))
            {
               CultureInfo provider = CultureInfo.InvariantCulture;
               observationDateTime = DateTime.ParseExact(observation_time_rfc822.Value, "ddd, dd MMM yyyy HH:mm:ss zzz", provider);
            }

            foreach (XPathNavigator weather in nav.Select("current_observation/weather"))
            {
               weatherConditionValue = weather.Value;
            }

            foreach (XPathNavigator temp_f in nav.Select("current_observation/temp_f"))
            {
               temperatureValue = (decimal)temp_f.ValueAsDouble;
            }

            foreach (XPathNavigator relative_humidity in nav.Select("current_observation/relative_humidity"))
            {
               humidityValue = relative_humidity.ValueAsInt;
            }

            //  InsertIntoDatabase();
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