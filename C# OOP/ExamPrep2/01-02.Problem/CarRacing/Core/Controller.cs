using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Models.Racers;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException("Invalid car type!");
            }

            ICar car = null;
            if (type == "SuperCar")
            {
                car = new SuperCar(make,model,VIN,horsePower);
            }
            else
            {
                car = new TunedCar(make, model, VIN, horsePower);

            }

            cars.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException("Invalid racer type!");
            }

            var car = cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            IRacer racer = null;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else
            {
                racer = new StreetRacer(username, car);
            }
            racers.Add(racer);

            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racers.FindBy(racerOneUsername);
            var racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne is null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            else if(racerTwo is null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var driver in racers.Models.OrderByDescending(x=> x.DrivingExperience).ThenBy(x=> x.Username))
            {
                sb.AppendLine($"{driver.GetType().Name}: {driver.Username}");
                sb.AppendLine($"--Driving behavior: {driver.RacingBehavior}");
                sb.AppendLine($"--Driving experience: { driver.DrivingExperience}");
                sb.AppendLine($"--Car: {driver.Car.Make} {driver.Car.Model} ({driver.Car.VIN})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
