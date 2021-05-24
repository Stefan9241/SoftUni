using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> towns = new Dictionary<string, Dictionary<string, int>>();
            string[] input = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "Sail")
            {
                string town = input[0];
                int people = int.Parse(input[1]);
                int gold = int.Parse(input[2]);
                if (towns.ContainsKey(town))
                {
                    towns[town]["people"] += people;
                    towns[town]["gold"] += gold;
                }
                else
                {
                    towns.Add(town, new Dictionary<string, int>());
                    towns[town].Add("people", people);
                    towns[town].Add("gold", gold);
                }

                input = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "End")
            {
                string town = command[1];
                int people;
                int gold;
                switch (command[0])
                {
                    case "Plunder":
                        people = int.Parse(command[2]);
                        gold = int.Parse(command[3]);
                        towns[town]["people"] -= people;
                        towns[town]["gold"] -= gold;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        if (towns[town]["people"] <= 0 || towns[town]["gold"] <= 0)
                        {
                            towns.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                        break;
                    case "Prosper":
                        gold = int.Parse(command[2]);
                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            towns[town]["gold"] += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town]["gold"]} gold.");
                        }
                        break;
                }

                command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }
            towns = towns.OrderByDescending(x => x.Value["gold"]).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            if (towns.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
                foreach (var item in towns)
                {
                    
                    Console.WriteLine($"{item.Key} -> Population: {item.Value["people"]} citizens, Gold: {item.Value["gold"]} kg");
                }
            }
        }
    }
}
