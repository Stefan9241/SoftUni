using System;
using System.Collections.Generic;
using System.Linq;

namespace ComplicatedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split().Select(int.Parse).ToList();

            string command = Console.ReadLine().ToLower();
            bool isChanged = false;
            while (command != "end")
            {
                string[] array = command.Split();
                int currNumber = 0;

                switch (array[0])
                {

                    case "add":
                        currNumber = int.Parse(array[1]);
                        input.Add(currNumber);
                        isChanged = true;
                        break;
                    case "remove":
                        currNumber = int.Parse(array[1]);
                        input.Remove(currNumber);
                        isChanged = true;
                        break;
                    case "insert":
                        currNumber = int.Parse(array[1]);
                        int number2 = int.Parse(array[2]);
                        input.Insert(number2, currNumber);
                        isChanged = true;
                        break;
                    case "removeat":
                        currNumber = int.Parse(array[1]);
                        input.RemoveAt(currNumber);
                        isChanged = true;
                        break;
                    case "contains":
                        currNumber = int.Parse(array[1]);
                        input.Contains(currNumber);
                        if (input.Contains(currNumber))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "printeven":
                        Console.WriteLine(string.Join(' ', input
                            .Where(n => n % 2 == 0)
                            .ToList()));
                        break;
                    case "printodd":
                        Console.WriteLine(string.Join(' ', input
                            .Where(n => n % 2 != 0)
                            .ToList()));
                        break;
                    case "getsum":
                        Console.WriteLine(input.Sum());
                        break;
                    case "filter":
                        int currentNumb = int.Parse(array[2]);
                        if (array[1] == "<")
                        {
                            Console.WriteLine(string.Join(' ', input
                             .Where(n => n < currentNumb)
                             .ToList()));
                        }
                        else if (array[1] == ">")
                        {
                            Console.WriteLine(string.Join(' ', input
                             .Where(n => n > currentNumb)
                             .ToList()));
                        }
                        else if (array[1] == ">=")
                        {
                            Console.WriteLine(string.Join(' ', input
                             .Where(n => n >= currentNumb)
                             .ToList()));
                        }
                        else if (array[1] == "<=")
                        {
                            Console.WriteLine(string.Join(' ', input
                             .Where(n => n <= currentNumb)
                             .ToList()));
                        }
                        break;
                }

                command = Console.ReadLine().ToLower();
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(' ',input));
            }
        }
    }
}
