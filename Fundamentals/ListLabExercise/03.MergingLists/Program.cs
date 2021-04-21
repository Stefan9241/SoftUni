using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> input = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();
            List<String> input1 = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            
            
            PrintResult(input, input1);
        }

        private static void PrintResult(List<string> input, List<string> input1)
        {
            List<String> result = new List<String>();
            if (input.Count > input1.Count)
            {
                for (int i = 0; i < input1.Count; i++)
                {
                    result.Add(input[i]);
                    result.Add(input1[i]);
                }
                for (int i = input1.Count; i < input.Count; i++)
                {
                    result.Add(input[i]);
                }
            }
            else
            {
                for (int i = 0; i < input.Count; i++)
                {
                    result.Add(input[i]);
                    result.Add(input1[i]);
                }
                for (int i = input.Count; i < input1.Count; i++)
                {
                    result.Add(input1[i]);
                }
            }
            Console.WriteLine(string.Join(' ',result));
        }
    }
}
