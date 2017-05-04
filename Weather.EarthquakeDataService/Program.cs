using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Weather.WeatherDataService
{
    class Program
    {
        static void Main(string[] args)
        {
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

        }
    }
}
