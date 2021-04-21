using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string[] command = Console.ReadLine().Split();
           
            while (command[0] != "End")
            {
                string type = command[0].ToLower();
                string model = command[1];
                string color = command[2].ToLower();
                int hp = int.Parse(command[3]);
                

                Vehicle currVehicle = new Vehicle(type, model, color, hp);
                vehicles.Add(currVehicle);

                command = Console.ReadLine().Split();
            }
            

            string askForModel = Console.ReadLine();
            while (askForModel != "Close the Catalogue")
            {
                Vehicle printModel = vehicles.First(x => x.Model == askForModel);
                Console.WriteLine(printModel);
                askForModel = Console.ReadLine();
            }
            List<Vehicle> cars = vehicles.Where(x => x.Type == "car").ToList();
            List<Vehicle> trucks = vehicles.Where(x => x.Type == "truck").ToList();

            double totalhpCars = cars.Sum(x => x.HorsePower);
            double totalhpTrucks = trucks.Sum(x => x.HorsePower);

            double avgHpCars = 0.00;
            double avgHpTrucks = 0.00;

            if (cars.Count > 0)
            {
                avgHpCars = totalhpCars / cars.Count;
            }
            if (trucks.Count > 0)
            {
                avgHpTrucks = totalhpTrucks / trucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {avgHpCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgHpTrucks:F2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");

            return sb.ToString().Trim();
        }
    }
}
