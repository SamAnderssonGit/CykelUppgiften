
using System.Security.Cryptography.X509Certificates;

namespace Kajens_Cykeluthyrning
{
    public class Rental
    {
        public Costumer costumer { get; set; }
        public Vehicle vehicle { get; set; }
        public int Hours { get; set; }
        public decimal TotalPrice { get; set; }

        public void RentOut(Costumer newCostumer, Vehicle rentedVehicle, int rentalHours)
        {
            if (rentedVehicle is E_Bike && newCostumer.Age < 18)  // Kopplar klassen elcykel till villkor på kundens ålder
            {
                Console.WriteLine("Unable to rent: Must be 18+ to rent an E-Bike");
            }
            else if (!rentedVehicle.IsAvailable)
            {
                Console.WriteLine("Unable to rent: E-bike is already rented");
            }
            else if (rentedVehicle is E_Bike ebike && ebike.BatteryLevel < 30)
            {
                Console.WriteLine("Unable to rent: E-bike has less than 30% battery and cant be rented");
            }
            else if (rentedVehicle is Bike bike && newCostumer.Age < 15)
            {
                Console.WriteLine("Unable to rent: Must be 15+ to rent a bike");
            }
            else if (rentedVehicle is E_Bike myebike && myebike.BatteryLevel < rentalHours * 10)
            {
                Console.WriteLine("Unable to rent: E-bike cant be rented for longer than battery capacity");
            }
            else
            {
                costumer = newCostumer;
                vehicle = rentedVehicle;
                Hours = rentalHours;


                if (rentedVehicle is E_Bike rentedEbike)
                {
                    rentedEbike.CalculateBattery(rentalHours);
                }

                rentedVehicle.IsAvailable = false;
                Console.WriteLine("Rental successful!");
                Console.WriteLine($"{costumer.Name} is now renting {vehicle.IdNumber} for {Hours} hours.");
            }
        }
        public decimal CalculatePrice(int hours)
        {
            decimal price = vehicle.CalculatePrice(hours);

            if (costumer.IsMember)  // medlem 10% rabatt
            {
                price = price * 0.9m;
                return price;
            }
            else
            {
                return price;
            }
        }

        public void ReturnVehicle()
        {
            TotalPrice = CalculatePrice(Hours);

            if (vehicle is E_Bike ebike && ebike.BatteryLevel < 30)
            {
                vehicle.IsAvailable = false;
                Console.WriteLine($"{vehicle.IdNumber} returned but needs charging before it can be rented again.");
            }
            else
            {
                vehicle.IsAvailable = true;
                Console.WriteLine("Vehicle returned successfully.");
            }
            PrintReciept();
        }
        public void PrintReciept()
        {
            Console.WriteLine("---------- RECEIPT ----------");
            Console.WriteLine($"Customer: {costumer.Name}");
            Console.WriteLine($"Vehicle ID: {vehicle.IdNumber}");
            Console.WriteLine($"Rental hours: {Hours}");
            Console.WriteLine($"Price before discount: {vehicle.CalculatePrice(Hours)} SEK");
            if (costumer.IsMember)
            {
                Console.WriteLine($"Member discount (10%): -{vehicle.CalculatePrice(Hours) * 0.1m:F2} SEK");
            }
            Console.WriteLine($"To Pay: {TotalPrice} SEK");
            Console.WriteLine("-----------------------------");
        }
    }
}

