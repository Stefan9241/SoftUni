using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int wins = 0;

            string command = Console.ReadLine();

            while (command != "End of battle")
            {
                int distance = int.Parse(command);
                if (distance > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    return;
                }
                wins++;
                energy -= distance;
                if (wins % 3 == 0)
                {
                    energy += wins;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
        }
    }
}
