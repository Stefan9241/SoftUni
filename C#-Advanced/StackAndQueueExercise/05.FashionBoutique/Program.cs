using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input);
            int capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int rack = 1;

            while (stack.Count > 0)
            {
                sum += stack.Peek();
                if (sum <= capacity)
                {
                    stack.Pop();
                }
                else
                {
                    rack++;
                    sum = 0;
                }
            }

            Console.WriteLine(rack);
        }
    }
}
