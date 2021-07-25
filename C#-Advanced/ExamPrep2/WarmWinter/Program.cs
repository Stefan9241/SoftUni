using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse)); // hats
            var queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse)); // scarfs
            var sets = new List<int>();

            while (stack.Count != 0 && queue.Count != 0)
            {
                if (stack.Peek() > queue.Peek())
                {
                    var set = stack.Pop() + queue.Dequeue();
                    sets.Add(set);
                }
                else if(stack.Peek() < queue.Peek())
                {
                    stack.Pop();
                }
                else
                {
                    queue.Dequeue();
                    var toPush = stack.Pop() + 1;
                    stack.Push(toPush);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
