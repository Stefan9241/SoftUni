
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [Test]
        [TestCase(null, 50, 100)]
        [TestCase(" ", 50, 100)]
        [TestCase("", 50, 100)]
        [TestCase("Warrior", 0, 100)]
        [TestCase("Warrior", -10, 100)]
        [TestCase("Warrior", 110, -100)]
        public void Ctor_ThrowsException_WhenInputIsInvalid(string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, dmg, hp));
        }

        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]
        public void Attack_ThrowsException_WhenHpIsLessThenMinimum(int attackerHp, int warriorHp)
        {
            Warrior attacker = new Warrior("Attacker", 50, attackerHp);
            Warrior warrior = new Warrior("Warrior", 10, warriorHp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }
        [Test]
        public void Attack_ThrowsException_WhenWarriorKillsAttacker()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", attacker.HP + 1, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }
        [Test]
        public void Attack_DecreasesAttackerHp()
        {
            int initialAttackerHp = 100;
            Warrior attacker = new Warrior("Attacker", 50, initialAttackerHp);
            Warrior warrior = new Warrior("Warrior", 30, 100);

            attacker.Attack(warrior);
            Assert.That(attacker.HP, Is.EqualTo(initialAttackerHp - warrior.Damage));
        }
        [Test]
        public void Attack_SetEnemyHpToZero_WhenAttackerDmgIsGreaterThenEnemyHp()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, 40);

            attacker.Attack(warrior);
            Assert.That(warrior.HP, Is.EqualTo(0));
        }
        [Test]
        public void Attack_DecreaseEnemyHpByAttackerDmg()
        {
            int warriorInitialHp = 100;
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, warriorInitialHp);
            attacker.Attack(warrior);
            Assert.That(warrior.HP, Is.EqualTo(warriorInitialHp - attacker.Damage));
        }

    }
}