using System;
using System.Configuration;
using System.Windows.Forms;
using Weather.LocationTranslator;

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
            WeatherDataSummary summary = new WeatherDataSummary(facade);
            LongLatCalcs translator = new LongLatCalcs(connectionString);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(summary, translator));
        }
    }
}
