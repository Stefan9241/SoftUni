using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = commands[0];
                int engineSpeed = int.Parse(commands[1]);
                int enginePower = int.Parse(commands[2]);
                var engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(commands[3]);
                string cargoType = commands[4];
                var cargo = new Cargo(cargoType, cargoWeight);

                double tire1pressure = double.Parse(commands[5]);
                int tire1Age = int.Parse(commands[6]);
                double tire2pressure = double.Parse(commands[7]);
                int tire2Age = int.Parse(commands[8]);
                double tire3pressure = double.Parse(commands[9]);
                int tire3Age = int.Parse(commands[10]);
                double tire4pressure = double.Parse(commands[11]);
                int tire4Age = int.Parse(commands[12]);
                var tires = new Tire[]
                {
                    new Tire(tire1Age,tire1pressure),
                    new Tire(tire2Age,tire2pressure),
                    new Tire(tire3Age,tire3pressure),
                    new Tire(tire4Age,tire4pressure)
                };

                Car currCar = new Car(model, engine, cargo, tires);
                cars.Add(currCar);
            }

            string filter = Console.ReadLine();

            if (filter == "fragile")
            {
                cars = cars.Where(c => c.Cargo.Type == "fragile" && c.Tire.Any(t => t.Pressure < 1)).ToList();
            }
            else
            {
                cars = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250).ToList();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
