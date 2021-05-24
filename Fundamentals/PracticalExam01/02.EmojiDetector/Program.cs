using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string coolEmojisPattern = @"(:{2}|\*{2})([A-Z][a-z]{2,})\1";
            string numbersPattern = @"\d";
            string text = Console.ReadLine();

            long coolTreshhold = 1;

            foreach (Match item in Regex.Matches(text, numbersPattern))
            {
                int num = int.Parse(item.Value);

                coolTreshhold *= num;
            }
            Console.WriteLine($"Cool threshold: {coolTreshhold}");
            var validEmojis = Regex.Matches(text, coolEmojisPattern);
            int emojisFound = validEmojis.Count;
            List<string> coolEmojis = new List<string>();
            foreach (Match item in validEmojis)
            {
                string emoji = item.Value.Substring(2, item.Length - 4);
                int sum = 0;
                foreach (var character in emoji)
                {
                    sum += (int)character;
                }
                if (sum > coolTreshhold)
                {
                    coolEmojis.Add(item.Value);
                }
            }

            Console.WriteLine($"{emojisFound} emojis found in the text. The cool ones are:");
            foreach (var item in coolEmojis)
            {
                Console.WriteLine(item);
            }
        }
    }
}
