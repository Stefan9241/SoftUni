using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> elements = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] curElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < curElements.Length; j++)
                {
                    if (elements.Contains(curElements[j]) == false)
                    {
                        elements.Add(curElements[j]);
                    }
                }
                
            }

            foreach (var item in elements.OrderBy(x=>x))
            {
                Console.Write(item + " ");
            }
        }
    }
}
