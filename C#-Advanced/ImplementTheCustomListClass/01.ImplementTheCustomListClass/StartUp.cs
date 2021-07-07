using System;

namespace _01.ImplementTheCustomListClass
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack();
            stack.Push(10);
            stack.Push(20);
            Console.WriteLine(stack.Count);
            var result = stack.Pop();
            Console.WriteLine(result);
            var peekResult = stack.Peek();
            Console.WriteLine(peekResult);
        }
    }
}
