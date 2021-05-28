using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string wordValidatePattern = @"\#{1}[A-z]{3,}\#{2}[A-z]{3,}\#{1}|\@{1}[A-z]{3,}\@{2}[A-z]{3,}\@{1}";
            Regex regex = new Regex(wordValidatePattern);
            MatchCollection matches = regex.Matches(text);
            List<string> validPairs = new List<string>();
            List<string> mirroredPairs = new List<string>();

            foreach (Match item in matches)
            {
                validPairs.Add(item.ToString());
            }

            for (int i = 0; i < validPairs.Count; i++)
            {
                string currentPair = validPairs[i];
                string firstWord = "";
                string secondWord = "";

                for (int j = 0; j < currentPair.Length / 2; j++)
                {
                    firstWord += currentPair[j];
                }

                for (int k = currentPair.Length - 1; k >= currentPair.Length / 2; k--)
                {
                    secondWord += currentPair[k];
                }

                if (firstWord == secondWord)
                {
                    mirroredPairs.Add(currentPair);
                }
                
            }

            if (mirroredPairs.Count == 0)
            {
                if (validPairs.Count != 0)
                {
                    Console.WriteLine($"{validPairs.Count} word pairs found!");
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("No word pairs found!");
                    Console.WriteLine("No mirror words!");
                }
                
            }
            else
            {
                Console.WriteLine($"{validPairs.Count} word pairs found!");
                Console.WriteLine("The mirror words are:");
            }

            List<string> finalResult = new List<string>();

            for (int i = 0; i < mirroredPairs.Count; i++)
            {
                string current = mirroredPairs[i];
                int endIndex = (current.Length / 2) - 2;
                string key = current.Substring(1, endIndex);
                string value = current.Substring(current.Length / 2 + 1,current.Length - (current.Length / 2) - 2);

                finalResult.Add($"{key} <=> {value}");
            }

            Console.WriteLine(string.Join(", ", finalResult));
        }
    }
}
