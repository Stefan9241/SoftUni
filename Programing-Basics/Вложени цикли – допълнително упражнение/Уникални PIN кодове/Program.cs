using System;

namespace Уникални_PIN_кодове
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            for (int one = 2; one <= num1; one += 2)
            {
                for (int two = 2; two <= num2; two++)
                {
                    for (int three = 2; three <= num3; three += 2)
                    {
                        if (two == 2 || two == 3 || two == 5 || two == 7)
                        {
                            Console.WriteLine($"{one} {two} {three}");
                        }
                    }
                }
            }
        }
    }
}
