using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.EarthquakeDataService
{
    public class SetFields
    {
        public Earthquake SetField(string[] parts)
        {
            Earthquake earthquake = new Earthquake();
            earthquake.EventTime = Convert.ToDateTime(parts[0]);
            earthquake.Latitude = SetDefaultDecimal(parts[1]);
            earthquake.Longitude = SetDefaultDecimal(parts[2]);
            earthquake.Depth = SetDefaultDecimal(parts[3]);
            earthquake.Magnitude = SetDefaultDecimal(parts[4]);
            earthquake.MagnitudeType = parts[5];
            earthquake.SeismicStations = SetDefaultInt(parts[6]);
            earthquake.AzimuthalGap = SetDefaultDecimal(parts[7]);
            earthquake.EpiCenterDistance = SetDefaultDecimal(parts[8]);
            earthquake.RootMeanSquare = SetDefaultDecimal(parts[9]);
            earthquake.DataContributorId = parts[10];
            earthquake.NetworkIdentifier = parts[11];
            earthquake.RecentUpdateTime = Convert.ToDateTime(parts[12]);
            earthquake.GeographicRegion = ($"{parts[13]},{parts[14]}");
            earthquake.SeismicEventType = parts[15];
            earthquake.HorizontalError = SetDefaultDecimal(parts[16]);
            earthquake.DepthError = SetDefaultDecimal(parts[17]);
            earthquake.MagnitudeError = SetDefaultDecimal(parts[18]);
            earthquake.MagniteOfEarthquake = SetDefaultInt(parts[19]);
            earthquake.EventsReviewed = parts[20];
            earthquake.LocationSource = parts[21];
            earthquake.MagnitudeSource = parts[22];
            return earthquake;
        }

        private decimal SetDefaultDecimal(string parts)
        {
            string _parts = parts;
            decimal SetDecimal = 0;
            if (!string.IsNullOrEmpty(_parts))
            {
                SetDecimal = Convert.ToDecimal(_parts);
                return SetDecimal;
            }
            return SetDecimal;
        }
        private int SetDefaultInt(string parts)
        {
            string _parts = parts;
            int SetInt = 0;
            if (!string.IsNullOrEmpty(_parts))
            {
                SetInt = Convert.ToInt32(_parts);
                return SetInt;
            }
            return SetInt;
        }

    }
}
