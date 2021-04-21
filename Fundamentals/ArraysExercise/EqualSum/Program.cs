using System;
using System.Linq;
namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isFound = false;

            for (int curr = 0; curr < arrayInput.Length; curr++)
            {
                int sumLeft = 0;
                int sumRight = 0;

                for (int i = curr + 1; i < arrayInput.Length; i++)
                {
                    sumRight += arrayInput[i];
                }

                for (int j = curr - 1; j >= 0; j--)
                {
                    sumLeft += arrayInput[j];
                }
                if (sumLeft == sumRight)
                {
                    isFound = true;
                    Console.WriteLine(curr);
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }

        }
    }
}
