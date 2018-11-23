using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdapterLayer;
using BusinessLogicLayer;


namespace AdapteeLayer
{
    //this implements inserting file data to poco object
    public class DataAdapting
    {
        private readonly ABNFAirlineAdapter airlineAdapter;

        public DataAdapting(ABNFAirlineAdapter airlineAdapter)
        {
            this.airlineAdapter = airlineAdapter;
        }

        //Insert input file data into an object
        public Airline InsertAirlineData(string inputFile)
        {
            var data = Utilities.ReadFile(inputFile);
            var returnList = airlineAdapter.Add(data);
            return returnList;
        }

       
    }
}
