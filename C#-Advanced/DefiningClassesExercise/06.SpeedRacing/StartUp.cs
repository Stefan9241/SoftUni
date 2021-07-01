using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = commands[0];
                double fuel = double.Parse(commands[1]);
                double consumption = double.Parse(commands[2]);
                Car currCar = new Car(model, fuel, consumption);
                cars.Add(currCar);
            }

            string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (cmdArgs[0] != "End")
            {
                string currCarModel = cmdArgs[1];
                double currCarDistance = double.Parse(cmdArgs[2]);
                Car currCar = cars.FirstOrDefault(c => c.Model == currCarModel);
                currCar.Drive(currCarDistance);
                cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
            }
        }
    }
}
