using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] inputNums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int, bool> validator = (arrayNums, num) =>
              {
                  bool trueOrFalse = true;
                  for (int i = 0; i < arrayNums.Length; i++)
                  {
                      if (num % arrayNums[i] != 0)
                      {
                          trueOrFalse = false;
                          break;
                      }
                  }

                  return trueOrFalse;
              };

            var DivisibleNumbers = Enumerable.Range(1, num).Where(x => validator(inputNums, x)).ToArray();

            Console.WriteLine(string.Join(" ",DivisibleNumbers));

        }
    }
}
