using System;

namespace Месечни_разходи
{
    class Program
    {
        static void Main(string[] args)
        {
            double months = double.Parse(Console.ReadLine());
            double electricity = 0;
            double totalWater = 0;
            double totalInternet = 0;
            double totalOther = 0;
            double sum = 0;
            for (int i = 0; i < months; i++)
            {
                double num = double.Parse(Console.ReadLine());
                electricity += num;
                double water = 20;

                totalWater += water;
                double internet = 15;
                totalInternet += internet;

                sum = num + water + internet;
                double other = sum * 0.20;
                totalOther += sum + other;
                other = 0;
            }
            double avg = (electricity + totalOther + totalInternet + totalWater) / months;
            Console.WriteLine($"Electricity: {electricity:f2} lv");
            Console.WriteLine($"Water: {totalWater:F2} lv");
            Console.WriteLine($"Internet: {totalInternet:f2} lv");
            Console.WriteLine($"Other: {totalOther:F2} lv");
            Console.WriteLine($"Average: {avg:f2} lv");
        }
    }
}
