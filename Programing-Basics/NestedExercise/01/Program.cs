using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int current = 1;
            bool isBigger = false;
            for (int i = 1; i <= num; i++)
            {
                for (int col = 1; col <= i; col++)
                {
                    if (current > num)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write(current + " ");
                    current++;
                }
                Console.WriteLine();
                if (isBigger)
                {
                    break;
                }
            }
        }
    }
}
