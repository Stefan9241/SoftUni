using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int count = 0;
            for (int num1 = 0; num1 <= input; num1++)
            {
                for (int num2 = 0; num2 <= input; num2++)
                {
                    for (int num3 = 0; num3 <= input; num3++)
                    {
                        if (num1 + num2 + num3 ==input)
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
