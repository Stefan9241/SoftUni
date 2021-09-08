using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            this.database = new Database();
        }

        [Test]
        public void Ctor_ThrowsExceptionWhenDbCountIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }
        [Test]
        public void Ctor_AddsValidItems()
        {
            int[] elements = new int[] { 1, 2, 3 };
            this.database = new Database(elements);
            Assert.That(database.Count, Is.EqualTo(elements.Length));
        }

        [Test]
        public void Add_IncrementCount_WhenCountIsValid()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }
            Assert.That(this.database.Count, Is.EqualTo(n));
        }
        [Test]
        public void Add_ThrowsExceptionWhenCapacityIsExceeded()
        {
            int n = 16;
            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }
        [Test]
        public void Remove_DecreaseDbCapacity()
        {
            int n = 3;
            for (int i = 0; i < n; i++)
            {
                this.database.Add(123);
            }
            this.database.Remove();
            int expectedResultCount = 2;
            Assert.That(this.database.Count, Is.EqualTo(expectedResultCount));
        }
        [Test]
        public void Remove_ThrowsException_WhenCollectionIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }
        [Test]
        public void Remove_RemovesElementFromDB()
        {
            int n = 3;
            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }
            int lastElement = 2;
            this.database.Remove();
            var elements = this.database.Fetch();
            Assert.IsFalse(elements.Contains(lastElement));
        }

        [Test]
        public void Fetch_ReturnsCopyNotReference()
        {
            int n = 3;
            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            var elemtns = this.database.Fetch();
            Assert.That(this.database, Is.Not.EqualTo(elemtns));
        }
    }
}