using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Gyms.Tests
{
    public class GymsTests
    {
        // Implement unit tests here
        private Athlete athlete;
        private Gym gym;
        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete("Stefan Spirov");
            gym = new Gym("Zaimov", 50);
        }

        [Test]
        public void Ctor_Athlete()
        {
            Assert.That(athlete.FullName == "Stefan Spirov");
            Assert.That(athlete.IsInjured == false);
        }
        [Test]
        public void Ctor_Gym()
        {
            Assert.That(gym.Capacity == 50);
            Assert.That(gym.Name == "Zaimov");
            Assert.That(gym.Count == 0);
        }

        [Test]
        public void Name_Throws_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null,100));
        }
        [Test]
        public void Capacity_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Gym("pochivka", -100));
        }

        [Test]
        public void Add_Throws_Exception()
        {
            var gymm = new Gym("asd", 1);
            gymm.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => gymm.AddAthlete(new Athlete("Gosho Pesho")));
        }
        [Test]
        public void Add_Correctly()
        {
            Assert.That(gym.Count == 0);
            gym.AddAthlete(athlete);
            Assert.That(gym.Count == 1);
        }

        [Test]
        public void RemoveAthlete_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>((() => gym.RemoveAthlete(null)));
        }


        [Test]
        public void RemoveAthlete_Correctly()
        {
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("asd asd"));
            gym.RemoveAthlete("asd asd");
            Assert.That(gym.Count == 1);
        }

        [Test]
        public void InjureAthlete_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(null));
        }

        [Test]
        public void InjureAthlete_Correctly()
        {
            gym.AddAthlete(athlete);
            var newOldAthlete = gym.InjureAthlete(athlete.FullName);

            Assert.That(newOldAthlete == athlete);
            Assert.That(athlete.IsInjured == true);
        }

        [Test]
        public void Report_Correctly()
        {
            gym.AddAthlete(athlete);

            var atl = new Athlete("Stefo Stefov");
            gym.AddAthlete(atl);

            var newList = new List<string>();
            newList.Add(athlete.FullName);
            newList.Add(atl.FullName);

            var listNames = $"Active athletes at {gym.Name}: {string.Join(", ",newList)}";
            var result = gym.Report();
            Assert.That(listNames == result);
        }
    }
}
