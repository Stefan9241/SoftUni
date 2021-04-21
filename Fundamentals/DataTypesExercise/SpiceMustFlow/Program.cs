using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int yield = 0;
            int daysCounter = 0;
            while (startingYield >= 100)
            {
                daysCounter++;
                yield += startingYield;
                startingYield -= 10;
                if (startingYield < 100)
                {
                    yield -= 52;
                    break;
                }
                else
                {
                    yield -= 26;
                }
                
            }
            Console.WriteLine(daysCounter);
            Console.WriteLine(yield);
        }
    }
}
