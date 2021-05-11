using System;

namespace _04.CeasaCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            foreach (char ch in input)
            {
                char currCHar = (char)(ch + 3);
                Console.Write(currCHar);
            }
        }
    }
}
