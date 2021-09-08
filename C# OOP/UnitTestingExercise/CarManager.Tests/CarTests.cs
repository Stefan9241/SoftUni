using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        [TestCase("","Model",5,100)]
        [TestCase(null,"Model",5,100)]
        [TestCase("Make","",5,100)]
        [TestCase("Make",null,5,100)]
        [TestCase("Make","Model",0,100)]
        [TestCase("Make","Model",-5,100)]
        [TestCase("Make","Model",5,0)]
        [TestCase("Make","Model",5,-10)]
        public void Ctor_ThrowsExceptionWhenDataIsInvalid(string make,string model,double fuelCons,double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelCons, fuelCapacity));
        }
        [Test]
        public void Ctor_SetsValidCar()
        {
            string make = "Make";
            string model = "Model";
            double fuelCons = 10;
            double fuelCapacity = 100;
            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelCons));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Refuel_ThrowsException_WhenFuelIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuel));
        }
        [Test]
        public void Refuel_IncreaseFuel_WhenFuelIsValid()
        {
            double refuelAmount = car.FuelCapacity / 2;
            car.Refuel(refuelAmount);
            Assert.That(car.FuelAmount, Is.EqualTo(refuelAmount));
        }
        [Test]
        public void Refuel_SetFuelAmountToCapacity()
        {
            double refuelAmount = car.FuelCapacity * 1.20;
            car.Refuel(refuelAmount);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowsException_WhenFuelIsZeroOrNegative()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(100));
        }

        [Test]
        public void Drive_DecreaseFuel_WhenDistanceIsValid()
        {
            double initialFuel = car.FuelCapacity;
            car.Refuel(initialFuel);
            car.Drive(100);
            Assert.That(car.FuelAmount, Is.EqualTo(initialFuel - car.FuelConsumption));
        }
        [Test]
        public void Drive_DecreaseFuelToZero_WhenDistanceIsEqualToFuelAmount()
        {
            car.Refuel(car.FuelCapacity);
            double distance = car.FuelCapacity * car.FuelConsumption;
            car.Drive(distance);
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }
        [Test]
        public void FuelAmount_ThrowsException_WhenNegativeValueIsPassed()
        {
            car.Refuel(car.FuelCapacity);
            double beforeDrive = car.FuelAmount;
            car.Drive(100);
            double afterDrive = car.FuelAmount;
            Assert.That(afterDrive, Is.LessThan(beforeDrive));
        }
    }
}