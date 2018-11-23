using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdapterLayer;
using BusinessLogicLayer;
using DataLayer;

namespace AdapteeLayer
{
    public class ResultAdapting
    {
        private readonly ABNFResultAdapter resultAdapter;

        public ResultAdapting(ABNFResultAdapter resultAdapter)
        {
            this.resultAdapter = resultAdapter;
        }

        //feed the computing results into an object
        public string GetComputingResults(Airline airlineData)
        {
            var calculationSummary = resultAdapter.CalculateFlightSummary(airlineData);
            var output = resultAdapter.Get(calculationSummary);
            return output;
        }

        public void GenerateOutputFile(string computedoutput, string filepath)
        {
            Utilities.WriteFile(computedoutput, filepath);
        }
    }
}
