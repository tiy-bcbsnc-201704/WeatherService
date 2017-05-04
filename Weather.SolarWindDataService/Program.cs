using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace Weather.SolarWindDataService
{
    class Program
    {
        static void Main(string[] args)
        {

            // Download the file into a string
            using (WebClient webClient = new WebClient())
            {
                //webClient.DownloadFile("http://services.swpc.noaa.gov/products/solar-wind/mag-5-minute.json", @"C:\Users\u872059\Downloads\SolarWind.json");
                string SolarWindData = webClient.DownloadString("http://services.swpc.noaa.gov/products/solar-wind/mag-5-minute.json");
                Console.WriteLine(SolarWindData);

                // Parse the JSON file data
                JArray a = JArray.Parse(SolarWindData);
                Console.WriteLine(a[0]);
                Console.WriteLine(a[1]);
                Console.WriteLine(a[2]);
            }


            // Call the EventNotifier service to record the time the file was downloaded



            // Store the new measurements in the SolarWind table
            using (SqlConnection connection = new SqlConnection("Server=LOCALHOST;Database=AddressBook;Trusted_Connection=True"))
            {
                //connection.Insert();
            }














            ////Open the file              
            //var stream = File.OpenText(@"C:\Users\u872059\Downloads\SolarWind.json");
            ////Read the file              
            //string st = stream.ReadToEnd();
            //var jsonArray = JArray.Parse(st);

            ////List<Treatment> treatments = JsonConvert.DeserializeObject<List<Treatment>>(Server.MapPath("~/Content/treatments.json")); 


            //foreach (var item in jsonArray)
            //{
            //    JObject ob = new JObject(item);
            //    foreach (var t in ob.Values<string>())
            //    {
            //        JObject oo = new JObject(t);
            //        foreach (var x in oo)
            //        {
            //            Console.WriteLine("item");
            //        }
            //    }
            //}
        }
    }
}
