using System;
using System.Linq;
namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isBigger = true;
            for (int i = 0; i < integers.Length; i++)
            {
                int current = integers[i];
                for (int j = i + 1; j < integers.Length; j++)
                {
                    if (integers[j] >= current)
                    {
                        isBigger = false;
                        break;
                    }
                }
                if (isBigger)
                {
                    Console.Write(current + " ");
                }
                isBigger = true;
            }
        }
    }
}
