using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] arrayCommand = command.Split();
                int element = int.Parse(arrayCommand[1]);
                if (arrayCommand[0] == "Delete")
                {
                    input.RemoveAll((x => x == element));
                }
                else if(arrayCommand[0] == "Insert")
                {
                    int position = int.Parse(arrayCommand[2]);
                    input.Insert(position, element);

                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ',input));
        }
    }
}
