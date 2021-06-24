using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .ToArray();

            Func<double, double> addVat = a => a * 1.20;

            foreach (var item in nums)
            {
                Console.WriteLine($"{addVat(item):f2}");
            }
        }
    }
}
