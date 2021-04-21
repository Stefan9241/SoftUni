using System;
using System.Linq;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split().ToArray();
            string[] array2 = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < array2.Length; i++)
            {
                string currentText = array2[i];
                for (int j  = 0; j < array1.Length; j++)
                {
                    if (currentText == array1[j])
                    {
                        Console.Write(currentText + " ");
                        break;
                    }
                }
            }
        }
    }
}
