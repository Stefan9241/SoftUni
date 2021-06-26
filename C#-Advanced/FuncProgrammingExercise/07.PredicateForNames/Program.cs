using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] inputNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string, int, bool> func = (x, y) => x.Length <= y;

            inputNames = inputNames.Where(x => func(x, lenght)).ToArray();

            foreach (var name in inputNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
