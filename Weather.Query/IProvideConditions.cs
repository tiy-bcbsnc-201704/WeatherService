using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Query
{
    public interface IProvideConditions
    {
        IHaveConditions Query(DateTime when, double latitude, double longitude);
    }
}
