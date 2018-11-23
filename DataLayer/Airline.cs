using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    /// <summary>
    /// It is assumed that each airline has the following properties,
    /// Aircraft, Route, Passengers (and its types). 
    /// </summary>
    public class Airline
    {
        //Initializing passenger properties in constructor
        public Airline()
        {
            Passengers = new List<Passenger>();
            LoyalityPassengers = new List<LoyalityPassenger>();
            AirlinePassengers = new List<AirlinePassenger>();
        }
        public Route Route { get; set; }
        public Aircraft Aircraft { get; set; }
        public List<Passenger> Passengers { get; set; }
        public List<LoyalityPassenger> LoyalityPassengers { get; set; }
        public List<AirlinePassenger> AirlinePassengers { get; set; }
    }
}
