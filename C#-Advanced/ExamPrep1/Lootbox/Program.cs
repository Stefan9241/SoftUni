using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var claimedItems = new List<int>();
            var queue = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var stack = new Stack<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (true)
            {
                if ((queue.Peek() + stack.Peek()) % 2 == 0)
                {
                    var sumItemToAdd = queue.Dequeue() + stack.Pop();
                    claimedItems.Add(sumItemToAdd);
                }
                else
                {
                    var itemToMove = stack.Pop();
                    queue.Enqueue(itemToMove);
                }

                if (queue.Count == 0 || stack.Count == 0)
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
