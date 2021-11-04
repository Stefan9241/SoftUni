using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver driver;
        private UnitCar car;
        [SetUp]
        public void Setup()
        {
            car = new UnitCar("vw", 100, 50);
            raceEntry = new RaceEntry();
            driver = new UnitDriver("Gosho", car);
        }

        [Test]
        public void Ctor_WorksCorrectly()
        {
            Assert.That(raceEntry.Counter == 0);
            Assert.That(car.Model == "vw");
            Assert.That(car.HorsePower == 100);
            Assert.That(car.CubicCentimeters == 50);
            Assert.That(driver.Name == "Gosho");
            Assert.That(driver.Car.Model == "vw");
        }
        [Test]
        public void AddDriver_Throws_NullDriver()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(null));
        }
        [Test]
        public void AddDriver_Throws_AlreadyExistsName()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_Correctly()
        {
            string result = raceEntry.AddDriver(driver);
            string expected = $"Driver {driver.Name} added in race.";
            Assert.That(raceEntry.Counter == 1);
            Assert.That(result == expected);
        }

        [Test]
        public void CalculateAverageHorsePower_Throws_MinParticipants()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower()
        {
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(new UnitDriver("pesho", new UnitCar("golf", 100, 50)));
            var result = raceEntry.CalculateAverageHorsePower();
            Assert.That(result == 100);
        }
    }
}