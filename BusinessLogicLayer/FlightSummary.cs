using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AdapterLayer;
using DataLayer;
using Microsoft.Win32.SafeHandles;
using System.Globalization;
using Utilitiess;

namespace BusinessLogicLayer
{
    //calling adapter methods
    public class FlightSummary : IDisposable
    {
        private readonly ABNFResultAdapter _resultAdapter;
        private readonly ABNFAirlineAdapter _airlineAdapter;

        public FlightSummary()
        {
            _resultAdapter = new ABNFResultAdapter();
            _airlineAdapter= new ABNFAirlineAdapter();
        }

        //Feed input to adapter
        public Airline FeedData(string[] data)
        {
            var airlineData = _airlineAdapter.Add(data);
            return airlineData;
        }

        //fecth output from adapter
        public string GetSummary(Airline airlineData)
        {
            var computedResult = CalculateFlightSummary(airlineData);
            var reportString = _resultAdapter.Get(computedResult);
            return reportString;
        }
        
        #region Logic

        public Result CalculateFlightSummary(Airline airlineData)
        {
            //Calculate total passengers 
            var totalPassengersCount = GetTotalPassengersCount(airlineData);

            //Calculate Loyality points used by passengers
            var loyalityPointsUsed = GetTotlaLoyalityPointsUsed(airlineData);

            //get ticket price
            var ticketPrice = (airlineData.Route.TicketPrice);

            //get cost per passenger
            var costPerPassenger = airlineData.Route.CostPerPassenger;

            //Total un-adjusted revenue
            var totalUnAdjustedRevenue = ticketPrice * totalPassengersCount;

            //Total adjusted revenue
            var totalAdjustedRevenue = ((totalUnAdjustedRevenue) -
                                        ((ticketPrice - costPerPassenger) + loyalityPointsUsed +
                                         (costPerPassenger)));

            //computing the flight summary

            var output = new Result()
            {
                TotalPassengerCount = totalPassengersCount,
                GeneralPassengerCount = airlineData.Passengers.Count,
                AirlinePassengerCount = airlineData.AirlinePassengers.Count,
                LoyalityPassengerCount = airlineData.LoyalityPassengers.Count,
                TotalNumberOfBags = (totalPassengersCount +
                                     airlineData.LoyalityPassengers.Count(i => i.UsingExtraBaggage)),
                TotalLoyalityPointsRedeemed = loyalityPointsUsed,
                TotalCostOfFlight = ((airlineData.Route.CostPerPassenger) * totalPassengersCount),
                TotalUnadjustedTicketRevenue = totalUnAdjustedRevenue,
                TotalAdjustedTicketRevenue = totalAdjustedRevenue          
            };

            IsFlightProceed(ref output, totalAdjustedRevenue, costPerPassenger, airlineData.Aircraft.NumberOfSeats,
                totalPassengersCount, airlineData.Route.MinimumTakeoffLoadPassenger);
            
            return output;
        }

        public string IsFlightProceed(ref Result result, double totalAdjustedRevenue, double costPerPassenger, int numberOfSeats, int totalPassengersCount, double minimumTakeoffLoadPassenger)
        {
            var message = "Fligh can be proceed!";

            var canFlightProceed = true;
            
            var totalFlightCost = costPerPassenger * numberOfSeats;

            //first rule:total adjusted revenue exceeds total cost of flight
            if (totalFlightCost > totalAdjustedRevenue)
            {
                message = "Flight cannot be proceed, total adjust revenue is less than flight cost.";
                canFlightProceed = false;
            }

            //second rule: number of passengers should be less than number of seats in flight
            if (totalPassengersCount > numberOfSeats)
            {
                message = "Flight cannot be proceed, total passengers are only " + totalPassengersCount + " which is less than number of seats.";
                canFlightProceed = false;
            }

            //thid rule: the percentage of booked seats exceeds the minimum set for a route.
            ///It is assumed that minimum set for a route means 'minimum­ takeoff­ load­ percentage' in Route table.so the weight of the flight should always greate than this

            var bookedSeatsPercentage = (totalPassengersCount * 100) / (numberOfSeats);

            if (minimumTakeoffLoadPassenger > bookedSeatsPercentage)
            {
                message = "Flight cannot be proceed, booked seat is only " + bookedSeatsPercentage + "% which is less than minimum flight take off load " + minimumTakeoffLoadPassenger + "%.";
                canFlightProceed = false;
            }

            result.Summary = message;
            result.CanFlightProceed = canFlightProceed;
            return message;
        }


        public int GetTotlaLoyalityPointsUsed(Airline airlineData)
        {
            var totalLoyalityPointsUsed = airlineData.LoyalityPassengers.Where(i => i.UsingLoyalityPoints).Sum(m => m.CurrentLoyalityPoints);
            return totalLoyalityPointsUsed;
        }

        public int GetTotalPassengersCount(Airline airlineData)
        {
            var totalPassengersCount = airlineData.Passengers.Count() + airlineData.AirlinePassengers.Count() +
                                       airlineData.LoyalityPassengers.Count;
            return totalPassengersCount;
        }

        //public void GenerateOutputFile(string computedoutput, string filepath)
        //{
        //    Util.WriteFile(computedoutput, filepath);
        //}


        #endregion




        #region Dispose

        // Flag: Has Dispose already been called?
        bool _disposed = false;
        // Instantiate a SafeHandle instance.
        readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            _disposed = true;
        }


        #endregion
    }
}
