using System;

namespace _5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numVisitors = int.Parse(Console.ReadLine());
            int back = 0;
            int legs = 0;
            int chest = 0;
            int abs = 0;
            int proteinBar = 0;
            int shake = 0;
            for (int i = 0; i < numVisitors; i++)
            {
                string activity = Console.ReadLine();
                switch (activity)
                {
                    case "Back":
                        back++;
                        break;
                    case "Chest":
                        chest++;
                        break;
                    case "Legs":
                        legs++;
                        break;
                    case "Abs":
                        abs++;
                        break;
                    case "Protein shake":
                        shake++;
                        break;
                    case "Protein bar":
                        proteinBar++;
                        break;
                }
            }
            Console.WriteLine($"{back} - back");
            Console.WriteLine($"{chest} - chest");
            Console.WriteLine($"{legs} - legs");
            Console.WriteLine($"{abs} - abs");
            Console.WriteLine($"{shake} - protein shake");
            Console.WriteLine($"{proteinBar} - protein bar");
            double numPplTraining = back + chest + legs + abs;
            double numPplEat = shake + proteinBar;
            Console.WriteLine($"{(numPplTraining * 100) / numVisitors:f2}% - work out");
            Console.WriteLine($"{(numPplEat * 100) / numVisitors:f2}% - protein");
        }
    }
}
