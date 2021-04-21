using System;

namespace __Боядисване_на_къща
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double rearSide = x * y;
            double window = 1.5 * 1.5;
            double totalSides = rearSide * 2 - window * 2;
            double backWall = x * x;
            double entrance = 1.2 * 2;
            double totalBackAndFront =2 *  backWall - entrance;
            double totalArea = totalSides + totalBackAndFront;
            double greenPaint = totalArea / 3.4;

            double roof = 2 * (x * y);
            double twoTriangles = 2 * (x * h / 2);
            
            double totalRedArea = roof + twoTriangles;
            double redPaint = totalRedArea / 4.3;

            Console.WriteLine($"{greenPaint:F2}");
            Console.WriteLine($"{redPaint:F2}");
        }
    }
}
