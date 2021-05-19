using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Planet
    {
        public Planet(string name,int population,string type,int soldiers)
        {
            Name = name;
            Population = population;
            Type = type;
            Soldiers = soldiers;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public string Type { get; set; }
        public int Soldiers { get; set; }

       
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Planet> attackedPlanets = new List<Planet>(); 
            List<Planet> destroyedPlanets = new List<Planet>(); 
            int attacks = int.Parse(Console.ReadLine());
            Regex countSTAR = new Regex(@"([starSTAR])");
            Regex decription = new Regex(@"\w+\D+");
            string pattern = @"@([A-za-z]+)\d*[^@\-!:>]*:(\d+)[^@\-!:>]*!([AD])![^@\-!:>]*->(\d+)";
            Regex decriptNewText = new Regex(pattern);

            for (int i = 0; i < attacks; i++)
            {
                string msg = Console.ReadLine();
                MatchCollection matchStar = countSTAR.Matches(msg);
                int howManyTimesStar = matchStar.Count;
                string text = "";

                foreach (var symbol in msg)
                {
                    text += (char)(symbol - howManyTimesStar);
                }

                Match match = decriptNewText.Match(text);
                if (match.Success)
                {
                    string planetName = match.Groups[1].Value;
                    int population = int.Parse(match.Groups[2].Value);
                    string attackType = match.Groups[3].Value;
                    int soldierCount = int.Parse(match.Groups[4].Value);

                    Planet currPlanet = new Planet(planetName, population, attackType, soldierCount);
                    if (attackType == "A")
                    {
                        attackedPlanets.Add(currPlanet);
                    }
                    else
                    {
                        destroyedPlanets.Add(currPlanet);
                    }
                }
                

            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(x=>x.Name))
            {
                sb.AppendLine($"-> {planet.Name}");
            }

            sb.AppendLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var planet in destroyedPlanets.OrderBy(x=>x.Name))
            {
                sb.AppendLine($"-> {planet.Name}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
