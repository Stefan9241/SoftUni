using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> validator = c => char.IsUpper(c[0]);

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            input = input.Where(x => validator(x)).ToArray();

            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }
    }
}
