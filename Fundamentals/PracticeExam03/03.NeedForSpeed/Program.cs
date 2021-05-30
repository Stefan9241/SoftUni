using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeed
{
    class Car
    {
        public Car(string name,int mil,int fuel)
        {
            CarName = name;
            Mileage = mil;
            Fuel = fuel;
        }
        public string CarName { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string currentCar = commands[0];
                int mill = int.Parse(commands[1]);
                int fuel = int.Parse(commands[2]);

                Car car = new Car(currentCar, mill, fuel);
                cars.Add(car);
            }

            string[] cmdArgs = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            while (cmdArgs[0] != "Stop")
            {
                string carName = cmdArgs[1];
                Car currentCar = cars.FirstOrDefault(x => x.CarName == carName);

                if (cmdArgs[0] == "Drive")
                {
                    int fuelNeeded = int.Parse(cmdArgs[3]);
                    int distance = int.Parse(cmdArgs[2]);
                    if (currentCar.Fuel <= fuelNeeded)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        currentCar.Mileage += distance;
                        currentCar.Fuel -= fuelNeeded;

                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                        if (currentCar.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {carName}!");
                            cars.Remove(currentCar);
                        }
                    }
                }
                else if (cmdArgs[0] == "Refuel")
                {
                    int fuel = int.Parse(cmdArgs[2]);
                    int currentFuel = currentCar.Fuel;
                    
                    if (currentCar.Fuel + fuel <= 75)
                    {
                        currentCar.Fuel += fuel;
                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                    }
                    else
                    {
                        currentCar.Fuel = 75;
                        Console.WriteLine($"{carName} refueled with {75 - currentFuel} liters");
                    }
                }
                else if (cmdArgs[0] == "Revert")
                {
                    int kilometers = int.Parse(cmdArgs[2]);
                    if (currentCar.Mileage - kilometers <= 10000)
                    {
                        currentCar.Mileage = 10000;
                    }
                    else
                    {
                        currentCar.Mileage -= kilometers;
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }
                }


                cmdArgs = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in cars.OrderByDescending(x=> x.Mileage).ThenBy(x=>x.CarName))
            {
                Console.WriteLine($"{car.CarName} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
}
