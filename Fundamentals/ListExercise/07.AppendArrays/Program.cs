using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputNumbers = Console.ReadLine()
                                               .Split('|')
                                               .ToList();
            inputNumbers.Reverse();


            List<string> result = new List<string>();
            foreach (string currNumber in inputNumbers)
            {
                string[] numbers = currNumber.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (string item in numbers)
                {
                    result.Add(item);
                }
            }
            Console.WriteLine(string.Join(' ', result));
        }
    }
}
