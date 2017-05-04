using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.EventNotifier
{
    public interface IRecordAnEvent
    {
        void Record(ServiceName serviceName, string message);
    }
}
