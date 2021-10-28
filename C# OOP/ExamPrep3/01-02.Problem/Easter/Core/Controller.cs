using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private EggRepository eggRepository;
        private BunnyRepository bunnyRepository;
        private int countColoredEggs;
        public Controller()
        {
            eggRepository = new EggRepository();
            bunnyRepository = new BunnyRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != "HappyBunny" && bunnyType != "SleepyBunny")
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            IBunny bunny = null;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                bunny = new SleepyBunny(bunnyName);

            }

            bunnyRepository.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunny = bunnyRepository.FindByName(bunnyName);
            if (bunny is null)
            {
                throw new InvalidOperationException("The b  unny you want to add a dye to doesn't exist!");
            }

            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggRepository.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            var egg = eggRepository.FindByName(eggName);
            var workShop = new Workshop();
            List<IBunny> bunnies = bunnyRepository.Models.Where(x => x.Energy >= 50).ToList();
            if (bunnies.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            foreach (var item in bunnies.OrderByDescending(x=> x.Energy))
            {
                workShop.Color(egg, item);
                if (item.Energy == 0)
                {
                    bunnyRepository.Remove(item);
                }
                if (egg.IsDone())
                {
                    break;
                }
            }

            if (egg.IsDone())
            {
                countColoredEggs++;
                return $"Egg {eggName} is done.";
            }

            return $"Egg {eggName} is not done.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{countColoredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in bunnyRepository.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
