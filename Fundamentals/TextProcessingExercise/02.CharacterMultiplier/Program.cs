using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var firstWord = input[0];
            var secondWord = input[1];

            var longWord = firstWord;
            var shordWord = secondWord;
            if (firstWord.Length < secondWord.Length)
            {
                longWord = secondWord;
                shordWord = firstWord;
            }

            int total = CharacterMultiplier(longWord, shordWord);
            Console.WriteLine($"{total}");
        }

        public static int CharacterMultiplier(string lonG,string shorT)
        {
            int sum = 0;
            for (int i = 0; i < shorT.Length; i++)
            {
                int currSum = shorT[i] * lonG[i];
                sum += currSum;
            }

            for (int j = shorT.Length; j < lonG.Length; j++)
            {
                int nextSum = lonG[j];
                sum += nextSum;
            }
            return sum;
        }
    }
}
