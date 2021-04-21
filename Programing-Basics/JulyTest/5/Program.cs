using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string bestName = "";
            int bestGols = 0;
            bool hattrick = false;
            while (name != "END")
            {
                int goals = int.Parse(Console.ReadLine());
                if (goals > bestGols)
                {
                    bestGols = goals;
                    bestName = name;
                    if (goals >=3)
                    {
                        hattrick = true;
                    }
                    if (goals >= 10)
                    {
                        break;
                    }
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"{bestName} is the best player!");
            if (hattrick)
            {
                Console.WriteLine($"He has scored {bestGols} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {bestGols} goals.");
            }
        }
    }
}
