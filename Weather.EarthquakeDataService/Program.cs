using System;
using System.Threading;
using System.Configuration;

namespace Weather.EarthquakeDataService
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WeatherService"].ConnectionString;
            string earthquackFileName = ConfigurationManager.AppSettings["EarthquackFileName"];

            for (;;)
            {
                RunEarthQuake runEarthQuake = new RunEarthQuake();
                runEarthQuake.DoStuff(connectionString, earthquackFileName);
                Console.WriteLine("This process runs for every 5 minutes ...");
                Thread.Sleep(1000 * 60 * 1);
                Console.WriteLine("wait Time-End");
            }
        }

        private static void SomeAction()
        {
            throw new NotImplementedException();
        }

    }
}

