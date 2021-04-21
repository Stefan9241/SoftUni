using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            double max = int.MinValue;
            while (text != "Stop")
            {
                double currentNumber = double.Parse(text);
                if (max <currentNumber)
                {
                    max = currentNumber;
                }
                text = Console.ReadLine();
            }
            Console.WriteLine(max);
        }
    }
}
