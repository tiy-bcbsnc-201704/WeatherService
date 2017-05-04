using Dapper.Contrib.Extensions;
using System;

namespace Weather.Query
{
    [Table("Earthquake")]
    class EarthquakeData
    {
        [Key]
        public int id { get; set; }

        public DateTime Etime { get; set; }

        public decimal EElatitude { get; set; }

        public decimal Elongitude { get; set; }

        public decimal Edepth { get; set; }

        public decimal Emag { get; set; }

        public string EmagType { get; set; }

        public int Enst { get; set; }

        public decimal Egap { get; set; }

        public decimal Edmin { get; set; }

        public decimal Erms { get; set; }

        public string Enet { get; set; }

        public string Eid { get; set; }

        public DateTime Eupdated { get; set; }

        public string Eplace { get; set; }

        public string Etype { get; set; }

        public decimal EhorizontalError { get; set; }

        public decimal EdepthError { get; set; }

        public decimal EmagError { get; set; }

        public int EmagNst { get; set; }

        public string Estatus { get; set; }

        public string ElocationSource { get; set; }

        public string EmagSource { get; set; }

    }
}
