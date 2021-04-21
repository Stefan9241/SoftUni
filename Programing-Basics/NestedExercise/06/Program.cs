using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1111; i <= 9999; i++)
            {
                bool special = true;
                for (int j = 0; j <= 3; j++)
                {
                    int digit = int.Parse(i.ToString()[j].ToString());
                    if (digit == 0)
                    {
                        special = false;
                        break;
                    }
                    if (number % digit != 0)
                    {
                        special = false;
                    }
                }
                if (special)
                {
                    Console.Write($"{i} ");
                }
            }

        }
    }
}
