namespace Kajens_Cykeluthyrning
{
    public class Vehicle   //Basklass
    {
        public string IdNumber { get; set; }
        private decimal _PricePerHour;
        public decimal PricePerHour
        {
            get { return _PricePerHour; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price cant be lower than 0");
                }
                else
                {
                    _PricePerHour = value;
                }
            }
        }
        
        public bool IsAvailable { get; set; } = true; // Alla Cyklar börjar som tillgängliga
        public Vehicle(string idnumber, decimal pricePerHour, bool isavailable)
        {
            IdNumber = idnumber;
            PricePerHour = pricePerHour;
            IsAvailable = isavailable;
        }

         public virtual decimal CalculatePrice(int hours)
        {
            return PricePerHour * hours;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Bike ID-number is: {IdNumber}");
            Console.WriteLine($"Price per hour is: {PricePerHour} SEK");
            if (IsAvailable)
            {
                Console.WriteLine("Status: Available");
            }
            else
            {
                Console.WriteLine("Status: Not Available");
            }
        }
    }

}
