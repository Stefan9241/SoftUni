using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowers = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());
            int counterPokes = 0;
            int fiftyPercentOfPokepowers = pokePowers / 2;
            while (pokePowers >= distance)
            {
                pokePowers -= distance;
                counterPokes++;
                if (fiftyPercentOfPokepowers == pokePowers && exhaustionFactorY != 0)
                {
                    pokePowers /= exhaustionFactorY;
                }
            }
            Console.WriteLine(pokePowers);
            Console.WriteLine(counterPokes);
        }
    }
}
