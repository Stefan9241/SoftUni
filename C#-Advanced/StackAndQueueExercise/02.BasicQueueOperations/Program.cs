using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.BasicQueueOperations
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
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numToPush; i++)
            {
                queue.Enqueue(targets[i]);
            }

            for (int i = 0; i < numToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(numToLookFor))
            {
                Console.WriteLine("true");
            }
            else if (!queue.Contains(numToLookFor))
            {
                Console.WriteLine($"{queue.Min()}");
            }
        }
    }
}
