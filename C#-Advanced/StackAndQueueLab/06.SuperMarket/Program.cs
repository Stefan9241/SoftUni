using System;
using System.Collections.Generic;

namespace _06.SuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Queue<string> listOfPpl = new Queue<string>();

            while (command != "End")
            {
                if (command == "Paid")
                {
                    int count = listOfPpl.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(listOfPpl.Dequeue());
                    }
                }
                else
                {
                    listOfPpl.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{listOfPpl.Count} people remaining.");
        }
    }
}
