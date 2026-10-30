

namespace Kajens_Cykeluthyrning
{
    public class Bike : Vehicle
    {
        public Bike(string idnumber, decimal pricePerHour, bool isAvailable)
            : base(idnumber, pricePerHour, isAvailable)
        {
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Class: BIKE");
        }
    }
}