using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            double min = int.MaxValue;
            while (text != "Stop")
            {
                double currentNumber = double.Parse(text);
                if (currentNumber < min)
                {
                    min = currentNumber;
                }
                text = Console.ReadLine();
            }
            Console.WriteLine(min);
        }
    }
}
