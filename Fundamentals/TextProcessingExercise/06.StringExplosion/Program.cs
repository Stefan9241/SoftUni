using System;

namespace _06.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int bomb = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char curChar = input[i];

                if (curChar == '>')
                {
                    int power = int.Parse(input[i + 1].ToString());
                    bomb += power;
                    continue;
                }
                if (bomb > 0)
                {

                    input = input.Remove(i, 1);
                    bomb--;
                    i--;
                }
            }

            Console.WriteLine(input);
        }
    }
}
