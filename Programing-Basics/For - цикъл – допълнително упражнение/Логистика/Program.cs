using System;

namespace Логистика
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double microBus = 0;
            double bus = 0;
            double train = 0;
            double sum = 0;
            int counterMicro = 0;
            int counterBus = 0;
            int counterTrain = 0;
            
            for (int i = 1; i <= num; i++)
            {
                double waight = double.Parse(Console.ReadLine());
                if (waight <= 3)
                {
                    counterMicro++;
                    microBus += waight;
                    sum += waight * 200;
                }
                else if (waight >= 4 && waight <= 11)
                {
                    counterBus++;
                    bus += waight;
                    sum += waight * 175;
                }
                else
                {
                    counterTrain++;
                    train += waight;
                    sum += waight * 120;
                }
            }
            double totalWaight = microBus + bus + train;
            double avgTon = sum / totalWaight;
            double avgMicro = microBus / totalWaight * 100; 
            double avgBus = bus / totalWaight * 100; 
            double avgTrain = train / totalWaight * 100;

            Console.WriteLine($"{avgTon:f2}");
            Console.WriteLine($"{avgMicro:f2}%");
            Console.WriteLine($"{avgBus:f2}%");
            Console.WriteLine($"{avgTrain:f2}%");
        }
    }
}
