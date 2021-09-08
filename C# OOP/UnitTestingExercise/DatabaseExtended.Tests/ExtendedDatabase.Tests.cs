using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendDb;
        [SetUp]
        public void Setup()
        {
            extendDb = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Ctor_AddsInitialPplToDB()
        {
            var persons = new Person[5];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "Gosho" + i);
            }

            this.extendDb = new ExtendedDatabase.ExtendedDatabase(persons);
            Assert.That(extendDb.Count, Is.EqualTo(persons.Length));

            foreach (var person in persons)
            {
                Person newPerson = extendDb.FindById(person.Id);
                Assert.That(newPerson, Is.EqualTo(person));
            }
        }
        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsExceeded()
        {
            var persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "Gosho" + i);
            }
            Assert.Throws<ArgumentException>(() => this.extendDb = new ExtendedDatabase.ExtendedDatabase(persons));
        }

        [Test]
        public void Add_ThrowsException_WhenCountIsExceeded()
        {
            var n = 16;
            for (int i = 0; i < n; i++)
            {
                this.extendDb.Add(new Person(i, "Gosho" + i));
            }
            Assert.Throws<InvalidOperationException>(() => extendDb.Add(new Person(11, "Pesho")));
        }
        [Test]
        public void Add_ThrowsException_WhenNameAlreadyExist()
        {
            this.extendDb.Add(new Person(11, "Gosho"));
            Assert.Throws<InvalidOperationException>(() => this.extendDb.Add(new Person(2, "Gosho")));
        }
        [Test]
        public void Add_ThrowsException_WhenIdAlreadyExist()
        {
            this.extendDb.Add(new Person(11, "Gosho"));
            Assert.Throws<InvalidOperationException>(() => this.extendDb.Add(new Person(11, "Pesho")));
        }

        //[Test]
        //public void Add_AddsPersonCorrectly()
        //{
        //    Person newPerson = new Person(321, "NewGuy");
        //    var persons = new Person[5];
        //    for (int i = 0; i < persons.Length; i++)
        //    {
        //        persons[i] = new Person(i, "Gosho" + i);
        //    }
        //    this.extendDb = new ExtendedDatabase.ExtendedDatabase(persons);
        //    this.extendDb.Add(newPerson);
        //    var expectedPerson = extendDb.FindById(321);
        //    Assert.That(expectedPerson, Is.EqualTo(newPerson));
        //}
        [Test]
        public void Add_IncrementsCountCorrecly()
        {
            this.extendDb.Add(new Person(1, "Pesho"));
            this.extendDb.Add(new Person(2, "Gosho"));
            Assert.That(extendDb.Count, Is.EqualTo(2));
        }

        [Test]
        public void Remove_ThrowsExceptionWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendDb.Remove());
        }

        [Test]
        public void Remove_RemovesCorrectly()
        {
            this.extendDb.Add(new Person(11, "Stefan"));
            this.extendDb.Add(new Person(1, "Gosho"));
            this.extendDb.Add(new Person(121, "Rumen"));
            this.extendDb.Remove();
            Assert.That(extendDb.Count, Is.EqualTo(2));
            Assert.Throws<InvalidOperationException>(() => extendDb.FindById(121));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUserName_ThrowsException_WhenUserNameIsInvalid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => this.extendDb.FindByUsername(username));
        }
        [Test]
        public void FindByUserName_ThrowsException_WhenUserNameIsNotExisting()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendDb.FindByUsername("juki"));
        }
        [Test]
        public void FindByUserName_ReturnsCorrectly()
        {
            var person = new Person(12, "Gosho");
            this.extendDb.Add(person);
            var newPerson = extendDb.FindByUsername("Gosho");
            Assert.That(person, Is.EqualTo(newPerson));
        }

        [Test]
        public void FindById_ThrowsException_WhenIdIsInvalid()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendDb.FindById(12));
        }
        [Test]
        public void FindById_ThrowsException_WhenIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendDb.FindById(-12));
        }
        [Test]
        public void FindByID_ReturnsCorrectly()
        {
            var peson = new Person(12, "Gosho");
            this.extendDb.Add(peson);
            var newPerson = this.extendDb.FindById(12);
            Assert.That(peson, Is.EqualTo(newPerson));
        }
    }
}