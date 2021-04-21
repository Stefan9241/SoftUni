using System;

namespace _4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numGroups = int.Parse(Console.ReadLine());
            int totalPeople = 0;
            int musala = 0;
            int monblan = 0;
            int kilimandjaro = 0;
            int k2 = 0;
            int everest = 0;
            for (int i = 0; i < numGroups; i++)
            {
                int people = int.Parse(Console.ReadLine());
                totalPeople += people;
                if (people <= 5)
                {
                    musala += people;
                }
                else if (people >= 6 && people <= 12)
                {
                    monblan += people;
                }
                else if (people >= 13 && people <= 25)
                {
                    kilimandjaro += people;
                }
                else if (people >= 26 && people <= 40)
                {
                    k2 += people;
                }
                else
                {
                    everest += people;
                }
            }
            Console.WriteLine($"{1.0 * musala / totalPeople * 100:F2}%");
            Console.WriteLine($"{1.0 * monblan / totalPeople * 100:F2}%");
            Console.WriteLine($"{1.0 * kilimandjaro / totalPeople * 100:F2}%");
            Console.WriteLine($"{1.0 * k2 / totalPeople * 100:F2}%");
            Console.WriteLine($"{1.0 * everest / totalPeople * 100:F2}%");
        }
    }
}
