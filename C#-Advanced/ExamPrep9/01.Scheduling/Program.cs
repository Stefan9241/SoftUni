using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var stackTasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var queueTreads= new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int valueToKill = int.Parse(Console.ReadLine());

            while (true)
            {
                if (stackTasks.Peek() == valueToKill)
                {
                    Console.WriteLine($"Thread with value {queueTreads.Peek()} killed task {stackTasks.Pop()}");
                    break;
                }

                if (queueTreads.Peek() >= stackTasks.Peek())
                {
                    queueTreads.Dequeue();
                    stackTasks.Pop();
                }
                else
                {
                    queueTreads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ",queueTreads));
        }
    }
}
