using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToLower().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (dict.ContainsKey(words[i]))
                {
                    dict[words[i]]++;
                }
                else
                {
                    dict.Add(words[i], 1);
                }
            }
            foreach (var item in dict)
            {
                if (item.Value % 2 == 1)
                {
                    Console.Write(item.Key.ToLower() + " ");
                }
            }

        }
    }
}
