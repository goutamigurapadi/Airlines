using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLogicLayer
{
    //Not using for now
    public interface IFlightSummary : IDisposable
    {
        Airline FeedData(string[] data);
        string GetSummary(Airline airlineData);
    }

    
}
