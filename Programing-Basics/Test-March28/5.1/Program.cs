using System;

namespace _5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            bool flag = false;
            int countSuitcases = 0;
            while (command != "End")
            {
                double current = double.Parse(command);
                countSuitcases++;
                if (countSuitcases % 3 == 0)
                {
                    current += current * 0.10;
                }
                capacity -= current;

                if (capacity <= 0)
                {
                    countSuitcases--;
                    flag = true;
                    break;
                }
                command = Console.ReadLine();
            }
            if (!flag)
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
            }
            else
            {
                Console.WriteLine($"No more space!");
            }
            Console.WriteLine($"Statistic: {countSuitcases} suitcases loaded.");
        }
    }
}
