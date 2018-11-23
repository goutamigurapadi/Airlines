using System.Collections.Generic;

namespace DataLayer
{
    
    public interface IPassenger
    {
        string FirstName { get; set; }
        int Age { get; set; }
        string PassengerType { get; set; }
        

    }
    public class Passenger:IPassenger
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string PassengerType { get; set; }
        
    }
}