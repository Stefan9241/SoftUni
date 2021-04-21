using System;
using System.Numerics;
namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            int bestSnow = 0;
            int bestTime = 0;
            int bestQuality = 0;
            BigInteger bestValue = 0;
            
            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snow = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());
                int snowDivByTime = snow / time;
                BigInteger value = BigInteger.Pow(snowDivByTime, quality);
                if (value > bestValue)
                {
                    bestSnow = snow;
                    bestTime = time;
                    bestQuality = quality;
                    bestValue = value;
                }
            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");
        }
    }
}
