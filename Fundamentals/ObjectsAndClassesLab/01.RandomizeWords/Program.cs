using System;

namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Random rnd = new Random();
            for (int i = 0; i < input.Length; i++)
            {
                int index = rnd.Next(0,input.Length);
                string currWord = input[i];
                input[i] = input[index];
                input[index] = currWord;
            }
            Console.WriteLine(string.Join(Environment.NewLine,input));
        }
    }
}
