using System;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    public class Hero
    {
        public Hero(string name, int mana, int health)
        {
            Name = name;
            Mana = mana;
            Health = health;
        }

        public string Name { get; set; }
        public int Mana { get; set; }
        public int Health { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var heroes = new List<Hero>();
            for (int i = 0; i < n; i++)
            {
                var heroInfo = Console.ReadLine().Split();
                Hero hero = new Hero(heroInfo[0], int.Parse(heroInfo[2]), int.Parse(heroInfo[1]));
                heroes.Add(hero);
            }

            var tokens = Console.ReadLine().Split(" - ");
            while (tokens[0] != "End")
            {
                Hero currHero = heroes.First(x => x.Name == tokens[1]);
                if (tokens[0] == "CastSpell")
                {
                    int manaNeeded = int.Parse(tokens[2]);
                    string spellName = tokens[3];
                    if (currHero.Mana >= manaNeeded)
                    {
                        currHero.Mana -= manaNeeded;
                        Console.WriteLine($"{currHero.Name} has successfully cast {spellName} and now has {currHero.Mana} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{currHero.Name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if(tokens[0] == "TakeDamage")
                {
                    int dmg = int.Parse(tokens[2]);
                    currHero.Health -= dmg;
                    if (currHero.Health <= 0)
                    {
                        Console.WriteLine($"{currHero.Name} has been killed by {tokens[3]}!");
                        heroes.Remove(currHero);
                    }
                    else
                    {
                        Console.WriteLine($"{currHero.Name} was hit for {dmg} HP by {tokens[3]} and now has {currHero.Health} HP left!");
                    }
                }
                else if(tokens[0] == "Recharge")
                {
                    int amount = int.Parse(tokens[2]);
                    if (currHero.Mana + amount > 200)
                    {
                        Console.WriteLine($"{currHero.Name} recharged for {200 - currHero.Mana} MP!");
                        currHero.Mana = 200;
                    }
                    else
                    {
                        currHero.Mana += amount;
                        Console.WriteLine($"{currHero.Name} recharged for {amount} MP!");
                    }
                }
                else
                {
                    int amount = int.Parse(tokens[2]);
                    if (currHero.Health + amount > 100)
                    {
                        Console.WriteLine($"{currHero.Name} healed for {100 - currHero.Health} HP!");
                        currHero.Health = 100;
                    }
                    else
                    {
                        currHero.Health += amount;
                        Console.WriteLine($"{currHero.Name} healed for {amount} HP!");
                    }
                }
                tokens = Console.ReadLine().Split(" - ");
            }

            foreach (var hero in heroes.OrderByDescending(x=> x.Health).ThenBy(x=> x.Name))
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"  HP: {hero.Health}");
                Console.WriteLine($"  MP: {hero.Mana}");
            }
        }
    }
}
