using System.Threading;
using System.Configuration;
using Weather.EventNotifier;

namespace Weather.EarthquakeDataService
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WeatherService"].ConnectionString;
            string earthquackFileName = ConfigurationManager.AppSettings["EarthquackFileName"];
            IRecordAnEvent log = new EventHandler(connectionString);
            log.Record(ServiceName.EarthquakeService, "Started");
            log.Record(ServiceName.EarthquakeService, "Will refresh every 5 minutes.");

            for (;;)
            {
                RunEarthQuake runEarthQuake = new RunEarthQuake(log);
                runEarthQuake.DoStuff(connectionString, earthquackFileName);
                Thread.Sleep(1000 * 60 * 5);
            }
        }
    }
}

