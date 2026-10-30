using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace Kajens_Cykeluthyrning
{
    public class E_Bike : Vehicle
    {
        private int _BatteryLevel = 0;
        public int BatteryLevel
        {
            get
            {
                return _BatteryLevel;
            }
            set
            {
                if(value < 0 || value > 100) // Batterinivå får inte vara färre än 0 eller över 100
                {
                    Console.WriteLine("Invalid batterylevel. Value must be between 0 and 100.");
                }
                else
                {
                    _BatteryLevel = value;
                }
            }
        }


        public E_Bike(string idnumber, decimal pricePerHour, bool isavailable, int batteryLevel)
            : base(idnumber, pricePerHour, isavailable)
        {
            BatteryLevel = batteryLevel;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Class: E-BIKE");
            Console.WriteLine($"Batterylevel is: {BatteryLevel} %");
        }

        public void CalculateBattery(int hours)
        {
            if (BatteryLevel >= hours * 10)  // Batterinivå måste vara högre eller likamed än tiden man hyr
            {
                BatteryLevel = BatteryLevel - (hours * 10); //Batterinivå 1-100 - timmar * 10
            }
            else
            {
                Console.WriteLine("Cant rent longer than batterylevel capacity");
            }
              
        }

        public void Recharge()
        {
            BatteryLevel = 100;
            Console.WriteLine($" ({IdNumber}) Batterylevel is now fully charged to: {BatteryLevel} %");
        }
    }
}
