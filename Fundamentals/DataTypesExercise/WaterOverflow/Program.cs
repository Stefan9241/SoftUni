using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacityTank = 255;
            int times = int.Parse(Console.ReadLine());
            int litersInMyTank = 0;
            for (int i = 0; i < times; i++)
            {
                int pourLiters = int.Parse(Console.ReadLine());
                capacityTank -= pourLiters;
                if (capacityTank < 0)
                {
                    Console.WriteLine("Insufficient capacity!");
                    capacityTank += pourLiters;
                }
                else
                {
                    litersInMyTank += pourLiters;
                }
            }
            Console.WriteLine(litersInMyTank);
        }
    }
}
