using System;
using System.Linq;

namespace MaxSeqOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bestCounter = 1;
            int bestIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {

                int currCounter = 1;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        currCounter++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currCounter > bestCounter)
                {
                    bestCounter = currCounter;
                    bestIndex = i;
                }
            }
            for (int i = 0; i < bestCounter; i++)
            {
                Console.Write(array[bestIndex] + " ");
            }
        }
    }
}
