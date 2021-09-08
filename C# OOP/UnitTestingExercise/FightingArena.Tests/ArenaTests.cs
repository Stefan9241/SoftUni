
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Ctor_InitializeWarriors()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }
        [Test]
        public void Ctor_CountIsZero_WhenArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Enroll_ThrowsException_WhenWarriorAlreadyExist()
        {
            var name = "Pesho";
            this.arena.Enroll(new Warrior(name, 50, 100));
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior(name, 100, 200)));
        }
        [Test]
        public void Enroll_IncreasesArenaCount()
        {
            var name = "Pesho";
            this.arena.Enroll(new Warrior(name, 50, 100));
            Assert.That(arena.Count, Is.EqualTo(1));
        }
        [Test]
        public void Enroll_AddsWarriorToWarriors()
        {
            var name = "Pesho";
            this.arena.Enroll(new Warrior(name, 50, 100));
            Assert.That(this.arena.Warriors.Any(x => x.Name == name),Is.True);
        }
        [Test]
        public void Fight_ThrowsException_WhenDefenderDoesNotExist()
        {
            this.arena.Enroll(new Warrior("Gosho", 100, 200));
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Gosho", "WrongName"));
        }
        [Test]
        public void Fight_ThrowsException_WhenAttackerDoesNotExist()
        {
            this.arena.Enroll(new Warrior("Gosho", 100, 200));
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("WrongName", "Gosho"));
        }
        [Test]
        public void Fight_ThrowsException_WhenBothDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("WrongName", "WrongName"));
        }

        [Test]
        public void Fight_BothWarriorsLoseHpInFight()
        {
            var initialHp = 100;
            var attacker = new Warrior("Attacker", 50, initialHp);
            var defender = new Warrior("Defender", 50, initialHp);
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);
            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(initialHp - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(initialHp - attacker.Damage));
        }
    }
}
