using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int Nkm = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            double startPrice = 0;

            if (Nkm < 20)
            {
                if (text == "day")
                {
                    startPrice += Nkm * 0.79 + 0.70;
                }
                else if (text == "night")
                {
                    startPrice += Nkm * 0.90 + 0.70;
                }
            }
            else if (Nkm >= 20 && Nkm < 100)
            {
                
                startPrice += Nkm * 0.09;
            }
            else if (Nkm >= 100)
            {
                
                startPrice += Nkm * 0.06;
            }
            Console.WriteLine($"{startPrice:f2}");



        }
    }
}
