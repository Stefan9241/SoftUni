using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] rawCommand = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = rawCommand[0];
                string[] clothes = rawCommand[1].Split(",");

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (dict.ContainsKey(color) == false)
                    {
                        dict.Add(color, new Dictionary<string, int>());
                        dict[color].Add(clothes[j], 1);
                    }
                    else if (dict[color].ContainsKey(clothes[j]))
                    {
                        dict[color][clothes[j]]++;
                    }
                    else
                    {
                        dict[color].Add(clothes[j],1);
                    }
                }
            }

            string[] needed = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorNeeded = needed[0];
            string clotheNeeded = needed[1];

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var cloth in item.Value)
                {
                    if (item.Key == colorNeeded && cloth.Key == clotheNeeded)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
