using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherService.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WeatherService"].ConnectionString;
            QueryFacade facade = new QueryFacade(connectionString);
            WeatherDataSummary summary = new WeatherDataSummary();

            Task summarizer = new Task(() =>
            {
                while (true)
                {
                    summary.EarthquakeCount = facade.GetEarthquakeCount();
                    summary.SolarWindCount = facade.GetSolarWindCount();
                    summary.WeatherCount = facade.GetWeatherCount();
                    summary.TopLogs = facade.GetTopLogs();
                    Thread.Sleep(1000);
                }
            });
            summarizer.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(summary));
        }
    }
}
