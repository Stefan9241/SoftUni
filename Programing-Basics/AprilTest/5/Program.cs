using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEggs = int.Parse(Console.ReadLine());
            int red = 0;
            int orange = 0;
            int blue = 0;
            int green = 0;
            int maxNumber = int.MinValue;
            string colorMax = "";
            for (int i = 0; i < numEggs; i++)
            {
                string color = Console.ReadLine();
                if (color == "red")
                {
                    red++;
                    if (red > maxNumber)
                    {
                        maxNumber = red;
                        colorMax = "red";
                    }
                }
                else if (color == "orange")
                {
                    orange++;
                    if (orange > maxNumber)
                    {
                        maxNumber = orange;
                        colorMax = "orange";
                    }
                }
                else if (color == "blue")
                {
                    blue++;
                    if (blue > maxNumber)
                    {
                        maxNumber = blue;
                        colorMax = "blue";
                    }
                }
                else if (color == "green")
                {
                    green++;
                    if (green > maxNumber)
                    {
                        maxNumber = green;
                        colorMax = "green";
                    }
                }
            }
            Console.WriteLine($"Red eggs: {red}");
            Console.WriteLine($"Orange eggs: {orange}");
            Console.WriteLine($"Blue eggs: {blue}");
            Console.WriteLine($"Green eggs: {green}");
            Console.WriteLine($"Max eggs: {maxNumber} -> {colorMax}");
        }
    }
}
