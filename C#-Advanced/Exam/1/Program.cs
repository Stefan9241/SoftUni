using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            var dict = new Dictionary<string, int>();
            dict.Add("Gladius", 0);
            dict.Add("Shamshir", 0);
            dict.Add("Katana", 0);
            dict.Add("Sabre", 0);
            dict.Add("Broadsword", 0);

            while (steel.Count > 0 && carbon.Count > 0)
            {
                if (steel.Peek() + carbon.Peek() == 70)
                {
                    dict["Gladius"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (steel.Peek() + carbon.Peek() == 80)
                {
                    dict["Shamshir"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (steel.Peek() + carbon.Peek() == 90)
                {
                    dict["Katana"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (steel.Peek() + carbon.Peek() == 110)
                {
                    dict["Sabre"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (steel.Peek() + carbon.Peek() == 150)
                {
                    dict["Broadsword"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    carbon.Push(carbon.Pop() + 5);
                }
            }

            int countSwords = dict.Values.Sum();

            if (countSwords > 0)
            {
                Console.WriteLine($"You have forged {countSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }

            if (countSwords > 0)
            {
                foreach (var swords in dict.Where(x => x.Value > 0).OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{swords.Key}: {swords.Value}");
                }
            }

        }
    }
}
