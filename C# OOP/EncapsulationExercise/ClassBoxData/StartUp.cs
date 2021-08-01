using System;

namespace ClassBoxData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(lenght, width, height);
                double surface = box.SurfaceArea();
                Console.WriteLine($"Surface Area - {surface:f2}");
                double lateral = box.LateralSurfaceArea();
                Console.WriteLine($"Lateral Surface Area - {lateral:f2}");
                double volume = box.Volume();
                Console.WriteLine($"Volume - {volume:f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
