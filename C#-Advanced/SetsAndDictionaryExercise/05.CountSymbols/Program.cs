using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var dict = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];
                if (dict.ContainsKey(currChar))
                {
                    dict[currChar]++;
                }
                else
                {
                    dict.Add(currChar, 1);
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
