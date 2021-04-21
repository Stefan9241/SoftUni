using System;

namespace Четни_двойки
{
    class Program
    {
        static void Main(string[] args)
        {
            //            На първия ред – началната стойност на първите първата двойка числа – цяло положително число в диапазона[10… 90]
            //На втория ред – началната стойност на втората двойка числа – цяло положително число в диапазона[10… 90]
            //На третия ред – разликата между началната и крайната стойност на първата двойка числа – цяло положително число в диапазона[1… 9]
            //На четвъртия ред – разликата между началната и крайната стойност на втората двойка числа – цяло положително число в диапазона[1… 9]
            int startNum1 = int.Parse(Console.ReadLine());
            int startNum2 = int.Parse(Console.ReadLine());
            int difference1 = int.Parse(Console.ReadLine());
            int difference2 = int.Parse(Console.ReadLine());
            bool one = false;
            bool two = false;

            for (int num1 = startNum1; num1 <= startNum1 + difference1; num1++)
            {
                for (int num2 = startNum2; num2 <= difference2+ startNum2; num2++)
                {
                    if (true)
                    {
                        for (int i = 2; i <= Math.Sqrt(num1); i++)
                        {
                            if (num1 % i == 0) 
                            {
                                one = true;
                                break;
                            }
                        }
                        for (int j = 2; j <=Math.Sqrt(num2); j++)
                        {
                            if (num2 % j == 0)
                            {
                                two = true;
                                break;
                            }
                        }
                        if (one != true && two != true)
                        {
                            Console.WriteLine($"{num1}{num2} ");
                            one = false;
                            two = false;
                        }
                    }
                    one = false;
                    two = false;
                }
            }



        }
    }
}
