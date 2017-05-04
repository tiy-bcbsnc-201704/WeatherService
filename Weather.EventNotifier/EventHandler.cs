using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.EventNotifier
{
    public class EventHandler : IRecordAnEvent
    {
        public EventHandler(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public void Record(ServiceName serviceName, string message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                ServiceEvent theThingThatJustHappened = new ServiceEvent();
                theThingThatJustHappened.EventDescription = message;
                theThingThatJustHappened.ServiceName = serviceName.ToString();
                theThingThatJustHappened.EventDateTime = DateTime.Now;

                connection.Insert(theThingThatJustHappened);
            }
        }

        private string _connectionString;
    }
}
