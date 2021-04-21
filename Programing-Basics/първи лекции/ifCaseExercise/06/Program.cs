using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            string oper =Console.ReadLine();
            double sum = 0;
            if (oper == "+")
            {
                sum = num1 + num2;
                if(sum % 2 == 0)
                {
                    Console.WriteLine($"{num1} + {num2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} + {num2} = {sum} - odd");
                }
            }
            else if (oper == "-")
            {
                sum = num1 - num2;
                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{num1} - {num2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} - {num2} = {sum} - odd");
                }
            }
            else if (oper == "*")
            {
                sum = num1 * num2;
                if(sum % 2 == 0)
                {
                    Console.WriteLine($"{num1} * {num2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} * {num2} = {sum} - odd");
                }
            }
            else if (oper == "/" &&  num2 !=0)
            {
                sum = num1 / num2;
                Console.WriteLine($"{num1} / {num2} = {sum:f2}");
            }
            else if (oper == "%" && num2 != 0)
            {
                sum = num1 % num2;
                Console.WriteLine($"{num1} % {num2} = {sum}");
            }
            if (num2 == 0)
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
            }
        }
    }
}
