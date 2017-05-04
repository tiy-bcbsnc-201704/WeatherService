using System;
using System.Threading;

namespace Weather.EarthquakeDataService
{
    class Program
    {
        public static object TemporaryCityTool { get; private set; }

        static void Main(string[] args)
        {
            for (;;)
            {
                RunEarthQuake runEarthQuake = new RunEarthQuake();
                runEarthQuake.DoStuff();
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

