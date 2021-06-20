using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {

            using var reader = new StreamReader("input.txt");

            using var writer = new StreamWriter("output.txt");

            var line = reader.ReadLine();

            int count = 0;

            while (line != null)
            {
                if (count % 2 != 0)
                {
                    writer.WriteLine((line));
                }

                count++;
                line = reader.ReadLine();
            }
        }
    }
}
