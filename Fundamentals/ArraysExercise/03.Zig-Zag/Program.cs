using System;
using System.Linq;
namespace _03.Zig_Zag
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] even = new string[n];
            string[] odd = new string[n];
            
            for (int i = 0; i < n; i++)
            {
                string[] currentArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                if (i % 2 == 0)
                {
                    even[i] = currentArr[0];
                    odd[i] = currentArr[1];
                }
                else
                {
                    even[i] = currentArr[1];
                    odd[i] = currentArr[0];
                }
            }
            Console.Write(string.Join(" ", even));
            Console.WriteLine();
            Console.Write(string.Join(" ", odd));


        }
    }
}
