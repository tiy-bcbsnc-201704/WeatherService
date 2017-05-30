using Dapper.Contrib.Extensions;
using System;
using System.Data.SqlClient;

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

                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}: {message}");
            }
        }

        private string _connectionString;
    }
}
