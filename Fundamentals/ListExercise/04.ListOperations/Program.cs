using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {

                if (command[0] == "Add")
                {
                    input.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    if (isValidIndex(int.Parse(command[2]), input.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        int number = int.Parse(command[1]);
                        int index = int.Parse(command[2]);
                        input.Insert(index,number);
                    }

                }
                else if (command[0] == "Remove")
                {
                    if (isValidIndex(int.Parse(command[1]), input.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        input.RemoveAt(int.Parse(command[1]));
                    }

                }
                else if (command[0] == "Shift")
                {
                    int count = int.Parse(command[2]);
                    if (command[1] == "left")
                    {

                        for (int i = 0; i < count; i++)
                        {
                            int firstElement = input[0];
                            for (int j = 0; j < input.Count - 1; j++)
                            {
                                input[j] = input[j + 1];
                            }
                            input[input.Count - 1] = firstElement;
                        }
                    }
                    else //right
                    {

                        for (int i = 0; i < count; i++)
                        {
                            int lastElement = input[input.Count - 1];
                            for (int j = input.Count - 1; j > 0; j--)
                            {
                                input[j] = input[j - 1];
                            }
                            input[0] = lastElement;
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(' ', input));
        }
        public static bool isValidIndex(int index, int count)
        {
            return index > count || index < 0;
        }
    }
}
