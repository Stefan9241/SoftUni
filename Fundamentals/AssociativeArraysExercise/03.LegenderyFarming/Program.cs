using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.LegenderyFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legenderyMat = new Dictionary<string, int>();
            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();
            bool flag = false;
            legenderyMat["shards"] = 0;
            legenderyMat["motes"] = 0;
            legenderyMat["fragments"] = 0;
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);

                    string material = input[i + 1].ToLower();
                    if (material == "shards" || material == "motes" || material == "fragments")
                    {
                        legenderyMat[material] += quantity;

                        if (legenderyMat["shards"] >= 250)
                        {
                            Console.WriteLine($"Shadowmourne obtained!");
                            legenderyMat["shards"] -= 250;
                            flag = true;
                            break;
                        }
                        else if (legenderyMat["motes"] >= 250)
                        {
                            Console.WriteLine($"Dragonwrath obtained!");
                            legenderyMat["motes"] -= 250;
                            flag = true;
                            break;
                        }
                        else if (legenderyMat["fragments"] >= 250)
                        {
                            legenderyMat["fragments"] -= 250;
                            Console.WriteLine($"Valanyr obtained!");
                            flag = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(material))
                        {
                            junk[material] += quantity;
                        }
                        else
                        {
                            junk.Add(material, quantity);
                        }
                    }

                    if (flag)
                    {
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }

            }

            Dictionary<string, int> keyResult = legenderyMat
                .OrderByDescending(a => a.Value)
                .ThenBy(a => a.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            foreach (var item in keyResult)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var junkItem in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{junkItem.Key}: {junkItem.Value}");
            }
        }
    }
}

