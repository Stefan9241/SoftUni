namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Fish fish;
        private Fish fish1;
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            fish = new Fish("Stefan");
            fish1 = new Fish("Gosho");
            aquarium = new Aquarium("Akva", 10);
        }

        [Test]
        public void Fish_Correctly()
        {
            Assert.That(fish.Name == "Stefan");
        }
        [Test]
        public void Aquarium_Correctly()
        {
            Assert.That(aquarium.Name == "Akva");
            Assert.That(aquarium.Capacity == 10);
        }

        [Test]
        public void AquaName_Throws_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 100));
        }
        [Test]
        public void AquaName_Throws_WhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 100));
        }

        [Test]
        public void AquaCapacity_Throws_NegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Akva", -100));
        }

        [Test]
        public void AquaCount_Correctly()
        {
            Assert.That(aquarium.Count == 0);
        }

        [Test]
        public void AquaAdd_Correctly()
        {
            aquarium.Add(fish);
            Assert.That(aquarium.Count == 1);
        }

        [Test]
        public void AquaAdd_Throws_CapacityFULL()
        {
            Aquarium avka = new Aquarium("nov akva", 1);
            avka.Add(fish);
            Assert.Throws<InvalidOperationException>(() => avka.Add(new Fish("Gosho")));
        }

        [Test]
        public void RemoveFish_Correctly()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish(fish.Name);
            Assert.That(aquarium.Count == 0);
        }
        [Test]
        public void RemoveFish_Throws_ExceptionNull()
        {
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
        }

        [Test]
        public void SellFish_Throws_ExceptionNull()
        {
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
        }
        [Test]
        public void SellFish_Correctly()
        {
            aquarium.Add(fish);
            Fish fish2 = aquarium.SellFish(fish.Name);
            Assert.That(fish.Available == false);
            Assert.That(fish2.Name == "Stefan");
        }

        [Test]
        public void Report_Correctly()
        {
            aquarium.Add(fish);
            aquarium.Add(fish1);
            string result = aquarium.Report();
            string expected = $"Fish available at {aquarium.Name}: {fish.Name}, {fish1.Name}";
            Assert.That(result == expected);
        }
    }
}
