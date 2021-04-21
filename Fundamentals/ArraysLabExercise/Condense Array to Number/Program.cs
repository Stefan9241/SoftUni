using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] inputArrayInteger = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < inputArrayInteger.Length - 1; i++)
            {
                for (int j = 0; j < inputArrayInteger.Length - 1; j++)
                {
                    inputArrayInteger[j] = inputArrayInteger[j] + inputArrayInteger[j + 1];
                }
            }
            Console.WriteLine(inputArrayInteger[0]);
        }
    }
}