using System;
using Weather.LocationTranslator;

namespace WeatherService_ServiceTests
{
    class Program
    {
        static void Main(string[] args)
        {


            double inputLongitude;
            double inputLatitude;
            string outputState;
            LongLatCalcs function = new Weather.LocationTranslator.LongLatCalcs();


            inputLongitude = 271.60;
            inputLatitude = 241.60;
            outputState = function.StateForLongLat(inputLongitude, inputLatitude);
            Console.WriteLine($"{inputLongitude},{inputLatitude} was found anywhere?   {outputState}");


            inputLongitude = 71.60;
            inputLatitude = 41.60;
            outputState = function.StateForLongLat(inputLongitude, inputLatitude);
            Console.WriteLine($"{inputLongitude},{inputLatitude} was found in NY?   {outputState}");


            inputLongitude = -71.60;
            inputLatitude = 41.60;
            outputState = function.StateForLongLat(inputLongitude, inputLatitude);
            Console.WriteLine($"{inputLongitude},{inputLatitude} was found in RI?   {outputState}");


            inputLongitude = -71.10;
            inputLatitude = 41.50;
            outputState = function.StateForLongLat(inputLongitude, inputLatitude);
            Console.WriteLine($"{inputLongitude},{inputLatitude} was found in MA?   {outputState}");


            inputLongitude = -73.30;
            inputLatitude = 41.40;
            outputState = function.StateForLongLat(inputLongitude, inputLatitude);
            Console.WriteLine($"{inputLongitude},{inputLatitude} was found in CT?   {outputState}");


            inputLongitude = -73.30;
            inputLatitude = 41.40;
            outputState = function.StateForLongLat(inputLongitude, inputLatitude);
            Console.WriteLine($"{inputLongitude},{inputLatitude} was found in NY?   {outputState}");



        }
    }
}
