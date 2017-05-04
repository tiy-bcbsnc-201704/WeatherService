using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.EventNotifier
{
    public class ServiceEvent
    {
        [Key]
        public int EventId { get; set; }
        public string ServiceName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDateTime { get; set; } 
    }    
}
