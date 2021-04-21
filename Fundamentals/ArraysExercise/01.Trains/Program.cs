using System;
using System.Linq;

namespace _01.Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            int countWagons = int.Parse(Console.ReadLine());
            int[] peopleInWagoon = new int[countWagons];
            int sum = 0;
            for (int i = 0; i < countWagons; i++)
            {
                peopleInWagoon[i] = int.Parse(Console.ReadLine());
                sum += peopleInWagoon[i];
            }
            Console.WriteLine(string.Join(" ", peopleInWagoon));
            Console.WriteLine(sum);
        }
    }
}
