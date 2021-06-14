using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            int numContinents = int.Parse(Console.ReadLine());
            for (int i = 0; i < numContinents; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = commands[0];
                string country = commands[1];
                string city = commands[2];

                if (continents.ContainsKey(continent))
                {
                    if (continents[continent].ContainsKey(country) == false)
                    {
                        continents[continent].Add(country, new List<string>());
                        
                    }
                    continents[continent][country].Add(city);
                }
                else
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                    continents[continent].Add(country, new List<string>());
                    continents[continent][country].Add(city);
                }
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}
