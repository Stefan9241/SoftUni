using System;
using System.Collections.Generic;

namespace _04.ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<String> result = new List<string>(number);
            for (int i = 0; i < number; i++)
            {
                string current = Console.ReadLine();
                result.Add(current);
            }
            result.Sort();

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{i + 1}.{result[i]}");
            }
        }
    }
}
