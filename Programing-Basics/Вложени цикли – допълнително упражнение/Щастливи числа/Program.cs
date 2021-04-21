using System;

namespace Щастливи_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;
            for (int one = 1; one < n; one++)
            {
                for (int two = 1; two < n; two++)
                {
                    for (int three = 1; three < n; three++)
                    {
                        for (int four = 1; four < n; four++)
                        {
                            sum1 = one + two;
                            sum2 = three + four;
                            if (sum1 == sum2 && n % sum1 == 0)
                            {
                                Console.Write($"{one}{two}{three}{four} ");
                            }
                                sum1 = 0;
                                sum2 = 0;
                         }
                    }
                }
            }
        }
    }
}
