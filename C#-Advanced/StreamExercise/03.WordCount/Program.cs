using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            using StreamReader reader = new StreamReader("words.txt");

            string line = reader.ReadLine();
            while (line != null)
            {
                string word = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()[0]
                    .ToLower();
                if (!dict.ContainsKey(word))
                {
                    dict[word] = 0;
                }
                

                line = reader.ReadLine();
            }

            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                using (StreamReader reade = new StreamReader("words.txt"))
                {
                    string newLine = reade.ReadLine();
                    while (newLine != null)
                    {
                        string[] words = newLine.Split()
                            .Select(x => x.TrimStart(new char[] { '-', ',', '.', '!', '?' }))
                            .Select(x => x.TrimEnd(new char[] { '-', ',', '.', '!', '?' }))
                            .Select(x => x.ToLower())
                            .ToArray();
                        foreach (var item in words)
                        {
                            if (dict.ContainsKey(item))
                            {
                                dict[item]++;
                            }
                        }
                        newLine = reade.ReadLine();
                    }

                    foreach (var item in dict.OrderByDescending(x=>x.Value))
                    {
                        writer.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
