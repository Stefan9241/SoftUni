using System;

namespace Предизвикай_Сватбата
{
    class Program
    {
        static void Main(string[] args)
        {
            int boys = int.Parse(Console.ReadLine());
            int girls = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());
            int counter = 0;
            int sum = boys * girls;
            while (true)
            {

                for (int b = 1; b <= boys; b++)
                {
                    for (int g = 1; g <= girls; g++)
                    {
                        counter++;
                        sum--;
                        Console.Write($"({b} <-> {g}) ");
                        if (counter == tables || sum == 0)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}
