using System;
using System.Collections.Generic;
using System.Linq;

namespace Flower
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliNumbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] roseNumbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var stackLili = new Stack<int>(liliNumbers);
            var queueRose = new Queue<int>(roseNumbers);

            int wreathsCount = 0;
            int stored = 0;
            while (stackLili.Count > 0 && queueRose.Count > 0)
            {
                var sum = stackLili.Peek() + queueRose.Peek();
                if (sum == 15)
                {
                    wreathsCount++;
                    stackLili.Pop();
                    queueRose.Dequeue();
                }
                else if(sum > 15)
                {
                    stackLili.Push(stackLili.Pop() - 2);
                }
                else if(sum < 15)
                {
                    stored += stackLili.Pop() + queueRose.Dequeue();
                    
                }
            }

            if (stored >= 15)
            {
                int wreathToAdd = 0;
                while (stored >= 15)
                {
                    stored -= 15;
                    wreathToAdd++;
                }
                wreathsCount += wreathToAdd;
            }

            if (wreathsCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreathsCount} wreaths more!");
            }

        }
    }
}
