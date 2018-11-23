using DataLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilitiess;


namespace AdapterLayer
{
    //obj adapter to calculate and feed output
    public class ABNFResultAdapter : IAdapter<Result>
    {
        

        /// <summary>
        /// No need to implement for now
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Result Add(string[] data)
        {
            throw new NotImplementedException();
        }

        public string Get(Result obj)
        {
            var str = new StringBuilder();

            str.Append(obj.TotalPassengerCount.AsString() + Constants.SPACE);
            str.Append(obj.GeneralPassengerCount.AsString() + Constants.SPACE);
            str.Append(obj.AirlinePassengerCount.AsString() + Constants.SPACE);
            str.Append(obj.LoyalityPassengerCount.AsString() + Constants.SPACE);
            str.Append(obj.TotalNumberOfBags.AsString() + Constants.SPACE);
            str.Append(obj.TotalLoyalityPointsRedeemed.AsString() + Constants.SPACE);
            str.Append(obj.TotalCostOfFlight.AsString() + Constants.SPACE);
            str.Append(obj.TotalUnadjustedTicketRevenue.AsString() + Constants.SPACE);
            str.Append(obj.TotalAdjustedTicketRevenue.AsString() + Constants.SPACE);
            str.Append(obj.CanFlightProceed.AsString().ToUpper() + Constants.NEWLINE);
            str.Append(obj.Summary);

            return str.ToString();
        }
    }
}
