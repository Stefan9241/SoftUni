using System;

namespace Комбинации_от_букви
{
    class Program
    {
        static void Main(string[] args)
        {
            char little = char.Parse(Console.ReadLine());
            char bigger = char.Parse(Console.ReadLine());
            char condition = char.Parse(Console.ReadLine());
            int counter = 0;

            for (char i =little; i <= bigger; i++)
            {
                for (char j = little ; j <= bigger; j++)
                {
                    for (char k = little; k <=  bigger; k++)
                    {
                        if (i == condition || j == condition || k == condition)
                        {
                            continue;
                        }
                        else 
                        {
                            counter++;
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }
            Console.WriteLine(counter);
            
        }
    }
}
