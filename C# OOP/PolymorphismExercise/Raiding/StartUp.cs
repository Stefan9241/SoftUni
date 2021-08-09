using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            while (heroes.Count < n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                BaseHero currHero = CreateHero(heroName, heroType);
                if (currHero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }
                heroes.Add(currHero);
            }

            long bossPower = long.Parse(Console.ReadLine());
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            long allPower = heroes.Select(x => x.Power).Sum();
            if (bossPower <= allPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero hero = null;
            if (heroType == nameof(Druid))
            {
                hero = new Druid(heroName);
            }
            else if (heroType == nameof(Paladin))
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == nameof(Rogue))
            {
                hero = new Rogue(heroName);
            }
            else
            {
                hero = new Warrior(heroName);
            }

            return hero;
        }
    }
}
