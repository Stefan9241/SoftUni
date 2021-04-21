using System;

namespace Игра_на_интервали
{
    class Program
    {
        static void Main(string[] args)
        {
            double period = double.Parse(Console.ReadLine());
            int from0To9 = 0;
            int from10to19 = 0;
            int from20To29 = 0;
            int from30To39 = 0;
            int from40To50 = 0;
            int invalidNum = 0;
            double result = 0;
            for (int i = 1; i <= period; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (num < 0 || num > 50)
                {
                    invalidNum++;
                    result -= result / 2;
                    if (result < 0)
                    {
                        result = 0;
                    }
                }
                else if (num >= 0 && num <= 9)
                {
                    from0To9++;
                    result += num * 0.20;
                }
                else if (num >= 10 && num <= 19)
                {
                    from10to19++;
                    result += num * 0.30;
                }
                else if (num >= 20 && num <= 29)
                {
                    from20To29++;
                    result += num * 0.40;
                }
                else if (num >= 30 && num <= 39)
                {
                    from30To39++;
                    result += 50;
                }
                else if (num >= 40 && num <= 50)
                {
                    from40To50++;
                    result += 100;
                }
            }
            Console.WriteLine($"{result:f2}");
            Console.WriteLine($"From 0 to 9: {(from0To9 * 100) / period:F2}%");
            Console.WriteLine($"From 10 to 19: {(from10to19 * 100) / period:F2}%");
            Console.WriteLine($"From 20 to 29: {(from20To29 * 100) / period:f2}%");
            Console.WriteLine($"From 30 to 39: {(from30To39 * 100) / period:f2}%");
            Console.WriteLine($"From 40 to 50: {(from40To50 * 100) / period:F2}%");
            Console.WriteLine($"Invalid numbers: {(invalidNum * 100) / period:F2}%");
        }
    }
}
