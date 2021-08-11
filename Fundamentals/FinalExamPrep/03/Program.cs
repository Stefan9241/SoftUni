using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    public class City
    {
        public City(string name, int people, int gold)
        {
            Name = name;
            People = people;
            Gold = gold;
        }

        public string Name { get; set; }
        public int People { get; set; }
        public int Gold { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new List<City>();

            string[] command = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Sail")
            {
                if (!cities.Any(x=> x.Name == command[0]))
                {
                    City currCity = new City(command[0],int.Parse(command[1]),int.Parse(command[2]));
                    cities.Add(currCity);
                }
                else
                {
                    City currCity = cities.First(x => x.Name == command[0]);
                    currCity.People += int.Parse(command[1]);
                    currCity.Gold += int.Parse(command[2]);
                }
                command = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            }

            var tokens = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            while (tokens[0] != "End")
            {
                City city = cities.First(x => x.Name == tokens[1]);
                if (tokens[0] == "Plunder")
                {
                    city.People -= int.Parse(tokens[2]);
                    city.Gold -= int.Parse(tokens[3]);
                    Console.WriteLine($"{city.Name} plundered! {tokens[3]} gold stolen, {tokens[2]} citizens killed.");
                    if (city.People <= 0 || city.Gold <= 0)
                    {
                        Console.WriteLine($"{city.Name} has been wiped off the map!");
                        cities.Remove(city);
                    }
                }
                else if(tokens[0] == "Prosper")
                {
                    string town = tokens[1];
                    int gold = int.Parse(tokens[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        tokens = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    else
                    {
                        city.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {city.Gold} gold.");
                    }
                }

                tokens = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities.OrderByDescending(x=> x.Gold).ThenBy(x=> x.Name))
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.People} citizens, Gold: {city.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
