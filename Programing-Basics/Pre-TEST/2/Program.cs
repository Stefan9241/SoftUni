using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numProcessors = int.Parse(Console.ReadLine());
            int numWorkers = int.Parse(Console.ReadLine());
            int numWorkDays = int.Parse(Console.ReadLine());

            double hoursWork = numWorkers * numWorkDays * 8;
            double procBuild = Math.Floor(hoursWork / 3);

            if (procBuild >= numProcessors)
            {
                double profit = (procBuild - numProcessors) * 110.10;
                Console.WriteLine($"Profit: -> {profit:F2} BGN");
            }
            else
            {
                double losses = (numProcessors - procBuild) * 110.10;
                Console.WriteLine($"Losses: -> {losses:F2} BGN");
            }

        }
    }
}
