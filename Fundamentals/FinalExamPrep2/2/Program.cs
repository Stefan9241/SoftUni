using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@#])[a-zA-Z]{3,}\1\1[a-zA-Z]{3,}\1";
            var validParis = new List<string>();

            string text = Console.ReadLine();
            var matches = Regex.Matches(text, pattern);
            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            for (int i = 0; i < matches.Count; i++)
            {

                string matchWord = matches[i].Value.ToString();
                string firstPart = matchWord.Substring(0, matchWord.Length / 2);
                string secondPart = matchWord.Substring(matchWord.Length / 2);
                var sb = new StringBuilder();
                for (int j = secondPart.Length - 1; j >= 0; j--)
                {
                    sb.Append(secondPart[j]);
                }
                string secondPartToAddInList = secondPart;
                secondPart = sb.ToString();
                if (firstPart == secondPart)
                {
                    firstPart = firstPart.Remove(0, 1);
                    firstPart = firstPart.Remove(firstPart.Length - 1);
                    secondPartToAddInList = secondPartToAddInList.Remove(0, 1);
                    secondPartToAddInList = secondPartToAddInList.Remove(secondPartToAddInList.Length - 1);
                    string stringToAdd = $"{firstPart} <=> {secondPartToAddInList}";
                    validParis.Add(stringToAdd);
                }
            }
            if (validParis.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", validParis));
            }
        }
    }
}
