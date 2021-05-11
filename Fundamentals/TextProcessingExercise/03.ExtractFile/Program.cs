using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split("\\");
            var tokens = input[input.Length - 1].Split(".");

            var name = tokens[0];
            var file = tokens[1];

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {file}");
        }
    }
}
