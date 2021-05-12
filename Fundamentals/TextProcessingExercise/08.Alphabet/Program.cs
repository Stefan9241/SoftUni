using System;

namespace _08.Alphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string alpha = "abcdefghijklmnopqrstuvwxyz".ToUpper();
            double totalSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string curNumber = input[i];
                char firstLetter = curNumber[0];
                char lastLetter = curNumber[curNumber.Length - 1];
                double number = double.Parse(curNumber.Substring(1, curNumber.Length - 2));
                double currSum = 0;
                
                if (alpha.Contains(firstLetter))
                {
                    int firstLetterPosition = alpha.IndexOf(firstLetter) + 1;
                    currSum = number / firstLetterPosition;
                    
                }
                else
                {
                    string lowerLetter = firstLetter.ToString().ToUpper();
                    int firstLetterPosition = alpha.IndexOf(lowerLetter) + 1;
                    currSum = number * firstLetterPosition;
                    
                }

                if (alpha.Contains(lastLetter))
                {
                    int lastLetterPosition = alpha.IndexOf(lastLetter) + 1;
                    currSum -= lastLetterPosition;
                }
                else
                {
                    string lowerLetter = lastLetter.ToString().ToUpper();
                    int lastLetterPositions = alpha.IndexOf(lowerLetter) + 1;
                    currSum += lastLetterPositions;
                }

                totalSum += currSum;
            }
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
