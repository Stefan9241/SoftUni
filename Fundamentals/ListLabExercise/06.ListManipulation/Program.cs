using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {

                string[] arr = command.Split();
                int number = int.Parse(arr[1]);

                switch (arr[0])
                {
                    case "add":
                        input.Add(number);
                        isChanged = true;
                        break;
                    case "remove":
                        input.Remove(number);
                        isChanged = true;
                        break;
                    case "insert":
                        int number2 = int.Parse(arr[2]);
                        input.Insert(number2, number);
                        isChanged = true;
                        break;
                    case "removeat":
                        input.RemoveAt(number);
                        isChanged = true;
                        break;
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine(string.Join(' ', input));
        }
    }
}
