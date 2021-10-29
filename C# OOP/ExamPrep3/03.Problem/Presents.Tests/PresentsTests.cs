namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Present present1;
        private Bag bag;
        [SetUp]
        public void SetUp()
        {
            present = new Present("Stefan", 50.00);
            present1 = new Present("Gosho", 25.00);
            bag = new Bag();
        }

        [Test]
        public void CreatePresent_True()
        {
            Assert.That(present.Name == "Stefan" && present.Magic == 50.00);
        }

        [Test]
        public void Create_THrows_Null()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }
        [Test]
        public void Create_THrows_AlreadyExist()
        {
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }
        [Test]
        public void Create_Adds_Correctly()
        {
            string result = bag.Create(present);
            Assert.That(result == $"Successfully added present {present.Name}.");
            Assert.That(bag.GetPresents().Count == 1);
        }

        [Test]
        public void Remove_Correctly()
        {
            bag.Create(present);
            bool result = bag.Remove(present);
            Assert.IsTrue(result);
        }
        [Test]
        public void GetPresentWithLeastMagic_Correctly()
        {
            bag.Create(present);
            bag.Create(present1);
            var result = bag.GetPresentWithLeastMagic();
            Assert.That(result == present1);
        }

        [Test]
        public void GetPresent_Correctly()
        {
            bag.Create(present);
            bag.Create(present1);
            var result = bag.GetPresent(present.Name);
            Assert.That(result == present);
        }
        [Test]
        public void GetPresent_Null()
        {
            bag.Create(present);
            bag.Create(present1);
            var result = bag.GetPresent(null);
            Assert.That(result == null);
        }
    }
}
