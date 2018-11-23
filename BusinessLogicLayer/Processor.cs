using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.Win32.SafeHandles;
using Utilities;

namespace BusinessLogicLayer
{
    //to process the requests and feed to main method
    public class Processor :IDisposable
    {
        private readonly FlightSummary _flightSummary;

        private Airline _airline;

        public Processor()
        {
            _flightSummary = new FlightSummary();
        }

        //Feed data to object
        public void FeedData(string inputFilePath)
        {
            if (!Util.FileExists(inputFilePath))
            {
                throw new FileNotFoundException("Cannot find input file");
            }
            var data = Util.ReadFile(inputFilePath);

            _airline = _flightSummary.FeedData(data);

        }

        //Generate report and write on file
        public void GenerateReport(string outputFilPath)
        {
            var report = _flightSummary.GetSummary(_airline);

            Util.WriteFile(report,outputFilPath);            
        }
        
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
