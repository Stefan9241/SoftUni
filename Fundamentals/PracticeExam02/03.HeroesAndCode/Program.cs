using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesAndCode
{
    class Hero
    {
        public Hero(string name, int hp, int mana)
        {
            Name = name;
            Health = hp;
            Mana = mana;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numHeroes = int.Parse(Console.ReadLine());
            List<Hero> heroes = new List<Hero>();
            int maxHp = 100;
            int maxMp = 200;

            for (int i = 0; i < numHeroes; i++)
            {
                string[] heroStats = Console.ReadLine().Split();
                string heroName = heroStats[0];
                int heroHp = int.Parse(heroStats[1]);
                int heroMp = int.Parse(heroStats[2]);
                if (heroHp > maxHp)
                {
                    heroHp = maxHp;
                }
                if (heroMp > maxMp)
                {
                    heroMp = maxMp;
                }
                Hero hero = new Hero(heroName, heroHp, heroMp);

                heroes.Add(hero);
            }

            string[] commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "End")
            {
                string heroName = commands[1];
                

                Hero hero = heroes.FirstOrDefault(x => x.Name == heroName);
                if (commands[0] == "CastSpell")
                {
                    int mpNeeded = int.Parse(commands[2]);
                    string spellName = commands[3];
                    if (hero.Mana >= mpNeeded)
                    {
                        hero.Mana -= mpNeeded;

                        Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.Mana} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (commands[0] == "TakeDamage")
                {
                    int dmgTaken = int.Parse(commands[2]);
                    string attacker = commands[3];
                    hero.Health -= dmgTaken;
                    if (hero.Health <= 0)
                    {
                        Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
                        heroes.Remove(hero);
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} was hit for {dmgTaken} HP by {attacker} and now has {hero.Health} HP left!");
                    }
                }
                else if (commands[0] == "Recharge")
                {
                    int amount = int.Parse(commands[2]);
                    int currentMana = hero.Mana;
                    int amountRecovered;
                    if (hero.Mana + amount > maxMp)
                    {
                        hero.Mana = 200;
                        amountRecovered = maxMp - currentMana;
                    }
                    else
                    {
                        hero.Mana += amount;
                        amountRecovered = amount;
                    }
                    Console.WriteLine($"{hero.Name} recharged for {amountRecovered} MP!");
                }
                else if (commands[0] == "Heal")
                {
                    int amount = int.Parse(commands[2]);
                    int currentHp = hero.Health;
                    int amountRecovered;
                    if (hero.Health + amount > maxHp)
                    {
                        hero.Health = maxHp;
                        amountRecovered = maxHp - currentHp;
                    }
                    else
                    {
                        hero.Health += amount;
                        amountRecovered = amount;
                    }
                    Console.WriteLine($"{hero.Name} healed for {amountRecovered} HP!");
                }
                commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var hero in heroes.OrderByDescending(x => x.Health).ThenBy(x => x.Name))
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"HP: {hero.Health}");
                Console.WriteLine($"MP: {hero.Mana}");
            }
        }
    }

}
