namespace DataLayer
{
    public class LoyalityPassenger:Passenger
    {
        public int CurrentLoyalityPoints { get; set; }
        public bool UsingLoyalityPoints { get; set; }
        public bool UsingExtraBaggage { get; set; }
    }
}