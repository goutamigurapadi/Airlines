namespace DataLayer
{
    public  class Route
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double CostPerPassenger { get; set; }
        public double TicketPrice { get; set; }
        public double MinimumTakeoffLoadPassenger { get; set; }
    }
}