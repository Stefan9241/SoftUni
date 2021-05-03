using System;
using System.Collections.Generic;

namespace _02.AMinorTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> loot = new Dictionary<string, int>();
            string name = Console.ReadLine();
            while (name != "stop")
            {
                if (loot.ContainsKey(name))
                {
                    int num = int.Parse(Console.ReadLine());
                    loot[name] += num;
                }
                else
                {
                    int num = int.Parse(Console.ReadLine());
                    loot.Add(name, num);
                }

                name = Console.ReadLine();
            }

            foreach (var item in loot)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
