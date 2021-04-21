using System;

namespace Песента_на_колелетата
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int password1 = 0;
            int password2 = 0;
            int password3 = 0;
            int password4 = 0;
            int counter = 0;
            bool found = false;
            for (int num1 = 1; num1 <=9; num1++)
            {
                for (int num2 = 1; num2 <= 9; num2++)
                {
                    for (int num3 = 1; num3 <= 9; num3++)
                    {
                        for (int num4 = 1; num4 <= 9; num4++)
                        {
                            if (num2 > num1 && num3 > num4)
                            {
                                double result = num1 * num2 + num3 * num4;
                                if (result == m)
                                {
                                    counter++;
                                    Console.Write($"{num1}{num2}{num3}{num4} ");
                                    if (counter == 4)
                                    {
                                        password1 = num1;
                                        password2 = num2;
                                        password3 = num3;
                                        password4 = num4;
                                    }
                                    found = true;
                                }
                            }

                        }
                    }
                }
            }
            if (found && counter>=4)
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {password1}{password2}{password3}{password4}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No!");
            }
        }
    }
}
