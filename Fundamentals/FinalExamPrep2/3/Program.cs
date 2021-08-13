using System;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    public class Car
    {
        public Car(string name,int mills, int fuel)
        {
            Name = name;
            Mills = mills;
            Fuel = fuel;
        }
        public string Name { get; set; }
        public int Mills { get; set; }
        public int Fuel { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            int numberCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberCars; i++)
            {
                string[] tokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string carName = tokens[0];
                int mills = int.Parse(tokens[1]);
                int fuel = int.Parse(tokens[2]);
                var currCar = new Car(carName,mills, fuel);
                cars.Add(currCar);
            }

            var commands = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Stop")
            {
                var currCarName = commands[1];
                Car car = cars.First(x => x.Name == currCarName);
                if (commands[0] == "Drive")
                {
                    int distance = int.Parse(commands[2]);
                    int fuel = int.Parse(commands[3]);
                    if (car.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        car.Mills += distance;
                        car.Fuel -= fuel;
                        Console.WriteLine($"{car.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (car.Mills >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car.Name}!");
                            cars.Remove(car);
                        }
                    }
                }
                else if(commands[0] == "Refuel")
                {
                    int fuel = int.Parse(commands[2]);
                    if (car.Fuel + fuel <= 75)
                    {
                        car.Fuel += fuel;
                        Console.WriteLine($"{car.Name} refueled with {fuel} liters");
                    }
                    else
                    {
                        Console.WriteLine($"{car.Name} refueled with {75 - car.Fuel} liters");
                        car.Fuel = 75;
                    }
                }
                else if(commands[0] == "Revert")
                {
                    int km = int.Parse(commands[2]);
                    car.Mills -= km;
                    Console.WriteLine($"{car.Name} mileage decreased by {km} kilometers");
                    if (car.Mills < 10000)
                    {
                        car.Mills = 10000;
                    }
                }

                commands = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in cars.OrderByDescending(x=> x.Mills).ThenBy(x=> x.Name))
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mills} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
}
