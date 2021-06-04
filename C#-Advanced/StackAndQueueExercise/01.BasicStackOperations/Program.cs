using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numToPush = nums[0];
            int numToPop = nums[1];
            int numToLookFor = nums[2];

            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numToPush; i++)
            {
                stack.Push(targets[i]);
            }

            for (int i = 0; i < numToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(numToLookFor))
            {
                Console.WriteLine("true");
            }
            else if (!stack.Contains(numToLookFor))
            {
                Console.WriteLine($"{stack.Min()}");
            }
        }
    }
}
