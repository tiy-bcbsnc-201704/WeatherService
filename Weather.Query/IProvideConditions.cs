using System;

namespace Weather.Query
{
    public interface IProvideConditions
    {
        IHaveConditions Query(DateTime when, double latitude, double longitude);
    }
}
