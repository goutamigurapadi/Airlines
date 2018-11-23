using DataLayer;
using Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities = Utilities.Util;

namespace AdapterLayer
{
    /// <summary>
    /// Adapter for the ABNF format of the objects
    /// These adapters can be implemented as generic using reflection.
    /// </summary>
    public class ABNFAirlineAdapter : IAdapter<Airline>
    {
        public Airline Add(string[] data)
        {
            var airline = new Airline();

            AddAirlineDetails(data, ref airline);
            Addpassengers(data, ref airline);

            return airline;
            
        }

        //Adding Airline Details
        private void AddAirlineDetails(string[] data, ref Airline airline)
        {
            //to select first line the text file which has 'Route' details 
            var airlineArrayFirstLine = Util.SplitLineBySpace(data.ElementAt(0));

            //to select second line the text file which has 'Aircraft' details 
            var aircraftArraySecondLine = Util.SplitLineBySpace(data.ElementAt(1));

            //adding Route and Aircraft detials of Airline
            airline = new Airline()
            {
                Route = new Route()
                {
                    Origin = airlineArrayFirstLine[0],
                    Destination = airlineArrayFirstLine[1],
                    CostPerPassenger = Util.ToDouble(airlineArrayFirstLine[2]),
                    TicketPrice = Util.ToDouble(airlineArrayFirstLine[3]),
                    MinimumTakeoffLoadPassenger = Util.ToDouble(airlineArrayFirstLine[4])
                },
                Aircraft = new Aircraft()
                {
                    AircraftTitle = aircraftArraySecondLine[0],
                    NumberOfSeats = Util.ToInt(aircraftArraySecondLine[1]),
                },
            };
        }

        //Adding passengers 
        private void Addpassengers(string[] inputData, ref Airline airline)
        {
            //Add n number of passages from input file
            for (var i = 2; i < inputData.Length; i++)
            {
                //split each line of words from input file to array
                var lineArray = Util.SplitLineBySpace(inputData[i]);
                var passengerType = lineArray[0];

                //To add corresponding passenger data
                switch (passengerType.ToLower())
                {
                    case PassengerTypes.General:
                        var passenger = new Passenger();
                        passenger.PassengerType = passengerType;
                        passenger.FirstName = lineArray[1];
                        passenger.Age = Util.ToInt(lineArray[2]);
                        airline.Passengers.Add(passenger);
                        break;

                    case PassengerTypes.Loyalty:
                        var loyaltyPassenger = new LoyalityPassenger();
                        loyaltyPassenger.PassengerType = passengerType;
                        loyaltyPassenger.FirstName = lineArray[1];
                        loyaltyPassenger.Age = Util.ToInt(lineArray[2]);
                        loyaltyPassenger.CurrentLoyalityPoints = Util.ToInt(lineArray[3]);
                        loyaltyPassenger.UsingLoyalityPoints = Util.ToBoolean((lineArray[4]));
                        loyaltyPassenger.UsingExtraBaggage = Util.ToBoolean((lineArray[5]));
                        airline.LoyalityPassengers.Add(loyaltyPassenger);
                        break;

                    case PassengerTypes.Airline:
                        var airlinePassanger = new AirlinePassenger();
                        airlinePassanger.PassengerType = passengerType;
                        airlinePassanger.FirstName = lineArray[1];
                        airlinePassanger.Age = Convert.ToInt32(lineArray[2]);
                        airline.AirlinePassengers.Add(airlinePassanger);
                        break;

                }
            }
        }


        /// <summary>
        /// No need to implement for now
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Get(Airline obj)
        {
            throw new NotImplementedException();
        }

      
    }
}