using System;

namespace Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int result = PrintSmallestNumber(num1, num2, num3);
            
            Console.WriteLine(result);
        }

        private static int PrintSmallestNumber(int num1, int num2, int num3)
        {
            int result = 0;
            if (num1 <= num2 && num1 <= num3)
            {
                result = num1;
            }
            else if (num2 <= num1 && num2 <= num3)
            {
                result = num2;
            }
            else if (num3 <= num2 && num1 >= num3)
            {
                result = num3;
            }
            return result;
        }
    }
}
