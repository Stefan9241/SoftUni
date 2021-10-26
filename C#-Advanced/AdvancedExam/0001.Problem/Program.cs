using System;
using System.Collections.Generic;
using System.Linq;

namespace _0001.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vowels = new Queue<string>(Console.ReadLine().Split());
            Stack<string> consonants = new Stack<string>(Console.ReadLine().Split());

            Dictionary<string, string> words = new Dictionary<string, string>()
            {
                { "pear", "pear" },
                { "flour", "flour" },
                { "pork", "pork" },
                { "olive", "olive"}
            };

            while (vowels.Count > 0 && consonants.Count > 0)
            {
                string vowelsLetter = vowels.Dequeue();
                string conLetter = consonants.Pop();

                RemoveLetter(words, vowelsLetter, conLetter, "pear");
                RemoveLetter(words, vowelsLetter, conLetter, "flour");
                RemoveLetter(words, vowelsLetter, conLetter, "pork");
                RemoveLetter(words, vowelsLetter, conLetter, "olive");

                vowels.Enqueue(vowelsLetter);

            }

            Console.WriteLine($"Words found: {words.Where(x => x.Value == string.Empty).Count()} ");
            foreach (var word in words)
            {
                if (word.Value.Length == 0)
                {
                    Console.WriteLine(word.Key);
                }
            }
        }

        private static void RemoveLetter(Dictionary<string, string> words, string vowelsLetter, string conLetter, string v)
        {
            if (words[v].Contains(vowelsLetter))
            {
                words[v] = words[v].Replace(vowelsLetter, string.Empty);
            }

            if (words[v].Contains(conLetter))
            {
                words[v] = words[v].Replace(conLetter, string.Empty);
            }
        }
    }
}
