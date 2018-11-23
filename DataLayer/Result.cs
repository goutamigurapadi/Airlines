using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    //To compute the flight summary
    public class Result
    {
        public int TotalPassengerCount { get; set; }
        public int GeneralPassengerCount { get; set; }
        public int AirlinePassengerCount { get; set; }
        public int LoyalityPassengerCount { get; set; }
        public int TotalNumberOfBags { get; set; }
        public int TotalLoyalityPointsRedeemed { get; set; }
        public double TotalCostOfFlight { get; set; }
        public double TotalUnadjustedTicketRevenue { get; set; }
        public double TotalAdjustedTicketRevenue { get; set; }
        public bool CanFlightProceed { get; set; }
        public string Summary { get; set; }        
    }
}
