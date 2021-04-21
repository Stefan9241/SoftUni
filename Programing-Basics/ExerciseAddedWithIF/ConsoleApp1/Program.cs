using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int Volume = int.Parse(Console.ReadLine());
            int pipeOne = int.Parse(Console.ReadLine());
            int pipeTwo = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double p1 = pipeOne * hours;
            double p2 = pipeTwo * hours;
            double combine = p1 + p2;

            if (Volume >= combine)
            {
                Console.WriteLine($"The pool is {combine / Volume * 100}% full. Pipe 1: {p1 / combine * 100:F2}%. Pipe 2: {p2 / combine * 100:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {hours} hours the pool overflows with {combine-Volume:f2} liters.");
            }

        }
    }
}
