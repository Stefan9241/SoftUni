using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("input.txt");

            using var writer = new StreamWriter("output.txt");
            int num = 1;
            string line = reader.ReadLine();
            while (line != null)
            {
                writer.WriteLine($"{num} {line}");
                num++;
                line = reader.ReadLine();
            }
        }
    }
}
