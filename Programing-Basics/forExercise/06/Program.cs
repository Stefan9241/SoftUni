using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbTabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            double penalty = 0;
            for (int i = 0; i < numbTabs; i++)
            {
                string website = Console.ReadLine();
                if (website == "Facebook")
                {
                    penalty += 150;
                    if(penalty >= salary)
                    {
                        Console.WriteLine("You have lost your salary.");
                        break;
                    }
                }
                else if (website == "Instagram")
                {
                    penalty += 100;
                    if (penalty >= salary)
                    {
                        Console.WriteLine("You have lost your salary.");
                        break;
                    }
                }
                else if (website == "Reddit")
                {
                    penalty += 50;
                    if (penalty >= salary)
                    {
                        Console.WriteLine("You have lost your salary.");
                        break;
                    }
                }
            }
            if (salary > penalty)
            {
                Console.WriteLine(salary - penalty);
            }
        }
    }
}
