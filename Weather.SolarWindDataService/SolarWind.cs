using Dapper.Contrib.Extensions;
using System;

namespace Weather.SolarWindDataService
{
    class SolarWind
    {
        private DateTime _measurementDateTime;
        private decimal _xCoordinate;
        private decimal _yCoordinate;
        private decimal _zCoordinate;
        private decimal _longitude;
        private decimal _latitude;
        private decimal _temperature;

        public SolarWind() { }

        public SolarWind(DateTime MeasurementDateTime, decimal XCoordinate, decimal YCoordinate, decimal ZCoordinate, decimal Longitude, decimal Latitude, decimal Temperature)
        {
            _measurementDateTime = MeasurementDateTime;
            _xCoordinate = XCoordinate;
            _yCoordinate = YCoordinate;
            _zCoordinate = ZCoordinate;
            _longitude = Longitude;
            _latitude = Latitude;
            _temperature = Temperature;
        }

        [Key]
        public int SolarWindId { get; set; }

        public DateTime MeasurementDateTime
        {
            get { return _measurementDateTime; }
            set { _measurementDateTime = value; }
        }

        public decimal XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }

        public decimal YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public decimal ZCoordinate
        {
            get { return _zCoordinate; }
            set { _zCoordinate = value; }
        }

        public decimal Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public decimal Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public decimal Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
    }
}
