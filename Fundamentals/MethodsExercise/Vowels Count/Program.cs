using System;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            //A, E, I, O, U, and sometimes Y.
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char curr = input[i];
                if (curr == 'a')
                {
                    counter++;
                }
                else if (curr == 'e')
                {
                    counter++;
                }
                else if (curr == 'i')
                {
                    counter++;
                }
                else if (curr == 'o')
                {
                    counter++;
                }
                else if (curr == 'u')
                {
                    counter++;
                }
                else if (curr == 'y')
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
