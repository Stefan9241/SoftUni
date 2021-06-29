using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialCars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            List<Engine> engines = new List<Engine>();

            List<Car> cars = new List<Car>();

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "No")
            {
                var newTire1 = new Tire(int.Parse(command[0]), double.Parse(command[1]));
                var newTire2 = new Tire(int.Parse(command[2]), double.Parse(command[3]));
                var newTire3 = new Tire(int.Parse(command[4]), double.Parse(command[5]));
                var newTire4 = new Tire(int.Parse(command[6]), double.Parse(command[7]));
                tires.Add(new Tire[] { newTire1, newTire2, newTire3, newTire4 });

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            

            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (tokens[0] != "Engines")
            {
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[0]);
                Engine currEngine = new Engine(horsePower,cubicCapacity);
                engines.Add(currEngine);

                tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] carsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (carsInfo[0] != "Show")
            {
                string make = carsInfo[0];
                string model = carsInfo[1];
                int year = int.Parse(carsInfo[2]);
                double fuelQ = double.Parse(carsInfo[3]);
                double fuelC = double.Parse(carsInfo[4]);
                int engineIndex = int.Parse(carsInfo[5]);
                int tireIndex = int.Parse(carsInfo[6]);
                var tire = tires[int.Parse(carsInfo[6])];

                Car currCar = new Car(make,model,year,fuelQ,fuelC,engines[engineIndex],tire);
                cars.Add(currCar);
                carsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            cars = cars
                 .Where(x => x.Year >= 2017 
                 && x.Engine.HorsePower > 330 
                 && x.Tires.Sum(y => y.Pressure) >= 9 
                 && x.Tires.Sum(y => y.Pressure) <= 10).ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }

        }
    }
}
