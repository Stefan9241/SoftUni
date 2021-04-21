using System;

namespace Футболен_турнир
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            double fans = double.Parse(Console.ReadLine());
            double a = 0;
            double b = 0;
            double v = 0;
            double g = 0;

            for (int i = 1; i <= fans; i++)
            {
                string text = Console.ReadLine();
                if (text == "A")
                {
                    a++;
                }
                else if(text == "B")
                {
                    b++;
                }
                else if (text == "G")
                {
                    g++;
                }
                else if(text == "V")
                {
                    v++;
                }
            }
            Console.WriteLine($"{(a * 100) / fans:f2}%");
            Console.WriteLine($"{(b * 100) / fans:f2}%");
            Console.WriteLine($"{(v * 100) / fans:f2}%");
            Console.WriteLine($"{(g * 100) / fans:f2}%");
            Console.WriteLine($"{(fans * 100) / capacity:f2}%");
        }
    }
}
