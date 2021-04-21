using System;

namespace Сватбени_места
{
    class Program
    {
        static void Main(string[] args)
        {

            char lastSector = char.Parse(Console.ReadLine());
            int rowFirst = int.Parse(Console.ReadLine());
            int spotsOdd = int.Parse(Console.ReadLine());
            int counter = 0;
            int counterRowsEven = 0;
            int counterRowsOdd = 0;
            for (char sector = 'A'; sector <= lastSector; sector++)
            {
                for (int numRows = 1; numRows <= rowFirst; numRows++)
                {
                    if (numRows % 2 == 0)
                    {
                        for (char i = 'a'; i <= 'z'; i++)
                        {
                            counterRowsEven++;
                            counter++;
                            Console.WriteLine($"{sector}{numRows}{i}");
                            if (counterRowsEven == spotsOdd + 2)
                            {
                                break;
                            }
                        }
                        counterRowsEven = 0;
                    }
                    else
                    {
                        for (char j = 'a'; j <= 'z'; j++)
                        {
                            counter++;
                            counterRowsOdd++;
                            Console.WriteLine($"{sector}{numRows}{j}");
                            if (counterRowsOdd >= spotsOdd)
                            {
                                break;
                            }
                        }
                        counterRowsOdd = 0;
                    }
                }
                rowFirst++;
            }
            Console.WriteLine(counter);


        }
    }
}
