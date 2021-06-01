using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> nums = new Queue<int>(input);

            for (int i = 0; i < input.Length; i++)
            {
                int currNum = nums.Peek();
                if (currNum % 2 == 0)
                {
                    nums.Enqueue(nums.Dequeue());
                }
                else
                {
                    nums.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
