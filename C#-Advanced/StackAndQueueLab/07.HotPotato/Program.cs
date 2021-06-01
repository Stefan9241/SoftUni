using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> nameS = new Queue<string>(names);

            while (nameS.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    nameS.Enqueue(nameS.Dequeue());
                }
                Console.WriteLine($"Removed {nameS.Dequeue()}");
            }

            Console.WriteLine($"Last is {nameS.Dequeue()}");
        }
    }
}
