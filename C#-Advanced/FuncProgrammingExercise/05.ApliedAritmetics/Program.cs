using System;
using System.Linq;

namespace _05.ApliedAritmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int> add = x => ++x;
            Func<int, int> subtract = x => --x;
            Func<int, int> multiply = x => x * 2;
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    input = input.Select(x => add(x)).ToArray();
                }
                else if(command == "subtract")
                {
                    input = input.Select(x => subtract(x)).ToArray();
                }
                else if(command == "multiply")
                {
                    input = input.Select(x => multiply(x)).ToArray();
                }
                else if(command == "print")
                {
                    print(input);
                }

                command = Console.ReadLine();
            }
        }
    }
}
