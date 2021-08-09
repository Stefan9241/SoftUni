using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle(Console.ReadLine().Split());
            Vehicle truck = CreateVehicle(Console.ReadLine().Split());
            Vehicle bus = CreateVehicle(Console.ReadLine().Split());

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string commandType = tokens[0];
                string vehicleType = tokens[1];
                double amount = double.Parse(tokens[2]);
                try
                {
                    if (commandType == "Drive")
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Drive(amount);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Drive(amount);
                        }
                        else
                        {
                            bus.Drive(amount);
                        }
                    }
                    else if (commandType == "Refuel")
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Refuel(amount);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Refuel(amount);
                        }
                        else
                        {
                            bus.Refuel(amount);
                        }
                    }
                    else
                    {
                        ((Bus)bus).DriveEmpty(amount);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static Vehicle CreateVehicle(string[] parts)
        {
            string typeVehicle = parts[0];
            double fuelQuanty = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);
            double tankCapacity = double.Parse(parts[3]);
            if (typeVehicle == nameof(Car))
            {
                return new Car(fuelQuanty, fuelConsumption, tankCapacity);
            }
            else if(typeVehicle == nameof(Truck))
            {
                return new Truck(fuelQuanty, fuelConsumption, tankCapacity);
            }
            else
            {
                return new Bus(fuelQuanty, fuelConsumption, tankCapacity);
            }
        }
    }
}
