using System;

namespace __Учебна_зала
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthInMeters = double.Parse(Console.ReadLine());
            double hightInMeters = double.Parse(Console.ReadLine());
            double widthInCM = widthInMeters * 100;
            double hightInCM = hightInMeters * 100;

            double minusCorridor = hightInCM - 100;
            double hightWorkSpace = Math.Floor(minusCorridor / 70);
            double widthWorkSpace = Math.Floor(widthInCM / 120);

            double totalWorkSpace = hightWorkSpace * widthWorkSpace - 3;

            Console.WriteLine(totalWorkSpace);
        }
    }
}
