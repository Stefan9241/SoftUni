using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> result = new Stack<string>(input.Reverse());

            while (result.Count > 1)
            {
                int a = int.Parse(result.Pop());
                string delimeter = result.Pop();
                int b = int.Parse(result.Pop());
                if (delimeter == "-")
                {
                    int numToPush = a - b;
                    result.Push(numToPush.ToString());
                }
                else
                {
                    int numToPush = a + b;
                    result.Push(numToPush.ToString());
                }
            }

            Console.WriteLine(result.Pop());
        }
    }
}
