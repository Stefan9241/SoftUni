using System;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (input.Length < 3)
            {
                Console.WriteLine(string.Join(' ',input));
            }
            else
            {
                int[] result = input.OrderByDescending(x => x).ToArray();
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }

        }
    }
}
