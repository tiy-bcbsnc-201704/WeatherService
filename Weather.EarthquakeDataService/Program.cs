using System;
using System.Threading;
using System.Configuration;

namespace Weather.EarthquakeDataService
{
    class Program
    {


        static void Main(string[] args)
        {
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["WeatherService"].ConnectionString;

            for (;;)
            {
                RunEarthQuake runEarthQuake = new RunEarthQuake();
                runEarthQuake.DoStuff(connectionString);
                Console.WriteLine("waiting 5 minutes...");
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

