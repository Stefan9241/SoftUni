using System;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

            Action<string> result = result => Console.WriteLine(result);

            foreach (var item in input)
            {
                result(item);
            }
        }
    }
}
