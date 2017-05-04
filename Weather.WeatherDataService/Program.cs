using System;
using System.Globalization;
using System.IO.Compression;
using System.Net;
using System.Xml.XPath;

namespace Weather.WeatherDataService
{
    public class Program
    {
        static void Main(string[] args)
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


            //    Console.WriteLine("Unzipping file");
            //    ZipFile.ExtractToDirectory("Data.zip", "C:/Users/u847301/Source/Repos/WeatherService/Weather.WeatherDataService/bin/Debug/XML");
            //    Console.WriteLine("Please press ENTER to continue.");

                // while loop
                // string xmlFileName = "C:/Users/u700656/Source/Repos/WeatherService/Weather.WeatherDataService/bin/Debug/XML/";
                Readxml();

            }

            static void Readxml()
             {

                string xmlFileName = "C:/Users/u847301/Source/Repos/WeatherService/Weather.WeatherDataService/bin/Debug/XML/KFLD.xml";
                // XPathDocument doc = new XPathDocument("KFLD.xml");
                XPathDocument doc = new XPathDocument(xmlFileName);
                XPathNavigator nav = doc.CreateNavigator();


                foreach (XPathNavigator latitude in nav.Select("current_observation/latitude"))
                {
                    Console.WriteLine($"latitude: {latitude.ValueAsDouble}");
                }
                foreach (XPathNavigator longitude in nav.Select("current_observation/longitude"))
                {
                    Console.WriteLine($"longitude: {longitude.ValueAsDouble}");
                }
                foreach (XPathNavigator station_id in nav.Select("current_observation/station_id"))
                {
                    Console.WriteLine($"station_id: {station_id.Value}");
                }
                foreach (XPathNavigator location in nav.Select("current_observation/location"))
                {
                    Console.WriteLine($"location: {location.Value}");
                }
                foreach (XPathNavigator observation_time_rfc822 in nav.Select("current_observation/observation_time_rfc822"))
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime observationDateTime = DateTime.ParseExact(observation_time_rfc822.Value, "ddd, dd MMM yyyy HH:mm:ss zzz", provider);
                    DateTime today = DateTime.Now;
                    Console.WriteLine($"observation_time: {observation_time_rfc822.Value}");
                    Console.WriteLine($"converted observation_time: {observationDateTime}");
                    Console.WriteLine($"today: {today}");
                }
                foreach (XPathNavigator weather in nav.Select("current_observation/weather"))
                {
                    Console.WriteLine($"weather: {weather.Value}");
                }
                foreach (XPathNavigator temp_f in nav.Select("current_observation/temp_f"))
                {
                    Console.WriteLine($"temp: {temp_f.ValueAsDouble}");
                }
                foreach (XPathNavigator relative_humidity in nav.Select("current_observation/relative_humidity"))
                {
                    Console.WriteLine($"humidity: {relative_humidity.ValueAsInt}");
                }



            }
        }
}
