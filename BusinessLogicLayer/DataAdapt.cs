using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdapterLayer;
using DataLayer;
using Utilities;

namespace BusinessLogicLayer
{
    public class DataAdapt
    {
        private readonly ABNFAirlineAdapter airlineAdapter;
        public DataAdapt(ABNFAirlineAdapter airlineAdapter)
        {
            this.airlineAdapter = airlineAdapter;
        }

        //Insert input file data into an object
        public Airline InsertAirlineData(string inputFile)
        {
            var data = Util.ReadFile(inputFile);
            var returnList = airlineAdapter.Add(data);
            return returnList;
        }

    }
}
