using System;
using System.Linq;

namespace _01.ValidUsername
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string currWord = input[i];
                if (IsValid(currWord))
                {
                    Console.WriteLine(currWord);
                }
            }
        }

        public static bool IsValid(string word)
        {
            
            if (word.Length >= 3 && word.Length <= 16)
            {
                if (word.All(char.IsLetterOrDigit) || word.Contains("-") || word.Contains("_"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
