using System;
using System.IO.Compression;
using System.Net;


namespace Weather.WeatherDataService
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (WebClient Webclient = new WebClient())
            {
                Console.WriteLine("downloading file");
                Webclient.Headers.Add("Accept", "text/html,application/xhtml + xml,application/xml; q = 0.9,image/webp,image/apng,*/*;q=0.8");
                Webclient.Headers.Add("Accept-Encoding", "gzip, deflate");
                Webclient.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                Webclient.Headers.Add("Cache-Control", "no-cache");
                Webclient.Headers.Add("Host", "w1.weather.gov");
                Webclient.Headers.Add("Pragma", "no-cache");
                Webclient.Headers.Add("Referer", "http://w1.weather.gov/xml/current_obs/");
                Webclient.Headers.Add("Upgrade-Insecure-Requests", "1");
                Webclient.Headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3088.0 Safari/537.36");
                Webclient.DownloadFile("http://w1.weather.gov/xml/current_obs/all_xml.zip", "WeatherData.zip");
                
                Console.WriteLine("Please press ENTER to continue.");
                Console.ReadLine();



                //ZipFile.ExtractToDirectory("WeatherData.zip", "WeatherUnzipped.txt");
            }


        }
    }
}
