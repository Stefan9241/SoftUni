using System;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int howManyKegs = int.Parse(Console.ReadLine());
            double biggestKeg = 1;
            string nameOfTheBiggest = "";
            for (int i = 0; i < howManyKegs; i++)
            {
                string name = Console.ReadLine();
                double radios = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double result = Math.PI * (radios * radios) * height;
                if (result > biggestKeg)
                {
                    biggestKeg = result;
                    nameOfTheBiggest = name;
                }
            }
            Console.WriteLine(nameOfTheBiggest);

        }
    }
}
