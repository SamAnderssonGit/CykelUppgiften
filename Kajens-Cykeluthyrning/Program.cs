using Kajens_Cykeluthyrning;
using System.ComponentModel.Design;
E_Bike Ebike1 = new E_Bike("EBIKE1", 70, true, 100);
E_Bike Ebike2 = new E_Bike("EBIKE2", 70, true, 50);
E_Bike Ebike3 = new E_Bike("EBIKE3", 70, true, 20);

Bike bike1 = new Bike("BIKE1", 40, true);
Bike bike2 = new Bike("BIKE2", 40, false);

List<Vehicle> MyVehicles = new();
MyVehicles.Add(Ebike1);
MyVehicles.Add(Ebike2);
MyVehicles.Add(Ebike3);
MyVehicles.Add(bike1);
MyVehicles.Add(bike2);

List<Costumer> MyCostumers = new List<Costumer>();
List<Rental> MyRentals = new List<Rental>();



MyMenu();



void RegisterCostumer()
{
    Console.WriteLine("Enter customer name:");
    string name = Console.ReadLine();

    Console.WriteLine("Enter customer age:");
    int age = int.Parse(Console.ReadLine());

    Console.WriteLine("Is the customer a member? (Yes/No)");
    string isMember = Console.ReadLine();

    bool ismember = false;  //behövde skapa upp en bool för ismember eftersom isMember är en string

    if (isMember == "Yes" || isMember == "yes" || isMember == "YES")
    {
        ismember = true;
    }
    else if (isMember == "No" || isMember == "no" || isMember == "NO")
    {
        ismember = false;
    }
    else
    {
        Console.WriteLine("Invalid answer. Please enter Yes or No.");
    }


    Costumer NewCostumer = new Costumer(name, age, ismember);
    MyCostumers.Add(NewCostumer); //Det användaren matar in läggs in i listan MyCostumers ovan
    Console.WriteLine($"{name} is now registred");
}

void MyMenu()
{
    while (true)
    {
        Console.WriteLine("========= Kajens Bike Rental =========");
        Console.WriteLine("1. Show Vehicles");
        Console.WriteLine("2. Register Costumer");
        Console.WriteLine("3. Rent out");
        Console.WriteLine("4. Return Vehicle");
        Console.WriteLine("5. Recharge E-Bike");
        Console.WriteLine("6. Exit Program");

        int Choice = int.Parse(Console.ReadLine());

        if (Choice == 1)
        {
            foreach (Vehicle item in MyVehicles)
            {
                item.PrintInfo();
            }
        }
        else if (Choice == 2)
        {
            while (true)
            {
                RegisterCostumer();

                Console.WriteLine("1. Register another customer");
                Console.WriteLine("2. Return to main menu");

                int answer = int.Parse(Console.ReadLine());

                if (answer == 2)
                {
                    break;
                }
            }
        }
        else if (Choice == 3)
        {
            Console.WriteLine("Available vehicles:");
            foreach (Vehicle item in MyVehicles)
            {
                item.PrintInfo();
            }
            foreach (Costumer mycustomer in MyCostumers)
            {
                Console.WriteLine($"Registred Customers available: {mycustomer.Name} ({mycustomer.Age})");
            }

            Console.WriteLine("Enter name of customer who's renting:");
            string Entername = Console.ReadLine();

            Console.WriteLine("Enter vehicle ID:");
            string vehicleId = Console.ReadLine();

            foreach (Costumer mycustomer in MyCostumers)
            {
                if (Entername == mycustomer.Name) //jämför om namnet anv skriver är samma som finns i listan
                {
                    foreach (Vehicle item in MyVehicles) //loopar ut listan med vehicles
                    {
                        if (vehicleId == item.IdNumber) //jämför namnet anv skriver är samma som finns i vehicle listan
                        {
                            Console.WriteLine("Enter rental hours:");
                            int hours = int.Parse(Console.ReadLine());

                            Rental rental = new Rental();
                            rental.RentOut(mycustomer, item, hours); // Customer objekt,Vehicle objekt, timmar
                            MyRentals.Add(rental); //lägger in i listan
                            break;
                        }
                    }
                    break;
                }
            }
        }
        else if (Choice == 4)
        {
            foreach (Costumer mycustomer in MyCostumers)
            {
                Console.WriteLine($"Registred Customers available: {mycustomer.Name} ({mycustomer.Age})");
            }
            Console.WriteLine("Enter customer name:");
            string ReturnName = Console.ReadLine();

            foreach (Rental item in MyRentals)
            {
                if (item.costumer.Name == ReturnName)
                {
                    item.ReturnVehicle();
                    break;
                }
            }
        }
        else if (Choice == 5)
        {
            foreach (Vehicle item in MyVehicles)
            {
                item.PrintInfo();
            }
            Console.WriteLine("Enter ID of which E-Bike to recharge to 100%");
            string RechargeChoice = (Console.ReadLine());
            if (RechargeChoice == Ebike1.IdNumber)
            {
                Ebike1.Recharge();
            }
            else if (RechargeChoice == Ebike2.IdNumber)
            {
                Ebike2.Recharge();
            }
            else if (RechargeChoice == Ebike3.IdNumber)
            {
                Ebike3.Recharge();
            }
            else
            {
                Console.WriteLine("Recharge FAILED. You can only recharge E-Bikes.");
            }
        }
        else if (Choice == 6)
        {
            Console.WriteLine("Exiting Program...");
            break;
        }
    }
}