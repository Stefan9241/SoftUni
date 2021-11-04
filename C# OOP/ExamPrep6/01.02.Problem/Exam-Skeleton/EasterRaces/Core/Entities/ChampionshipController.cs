using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository carRepository;
        private DriverRepository driverRepository;
        private RaceRepository raceRepository;
        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driverRepository = new DriverRepository();
            raceRepository = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            var driver = driverRepository.GetByName(driverName);
            if (driver != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            IDriver gosho = new Driver(driverName);
            driverRepository.Add(gosho);

            return $"Driver {driverName} is created.";

        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            ICar oldCar = carRepository.GetByName(model);
            if (oldCar != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            carRepository.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = carRepository.GetByName(carModel);
            IDriver driver = driverRepository.GetByName(driverName);

            if (driver is null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car is null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepository.GetByName(raceName);
            IDriver driver = driverRepository.GetByName(driverName);

            if (race is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driver is null)
            {
                throw new InvalidOperationException($"Race {driverName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driverName} added in {raceName} race.";
        }




        public string CreateRace(string name, int laps)
        {
            IRace race = raceRepository.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException("Race {name} is already create.");
            }

            IRace raceNew = new Race(name, laps);
            raceRepository.Add(raceNew);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            //var drivers = driverRepository.GetAll().Where(x=> x.CanParticipate).OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();
            var winners = race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToArray();
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var sb = new StringBuilder();

            sb.AppendLine($"Driver {winners[0].Name} wins {raceName} race.");
            winners[1].WinRace();
            sb.AppendLine($"Driver {winners[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {winners[2].Name} is third in {raceName} race.");

            raceRepository.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
