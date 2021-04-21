using System;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double yearGrade = 0;
            int classes = 0;
            double avrgGrade = 0;
            double skusan = 0;
            while (classes < 12)
            {
                yearGrade = double.Parse(Console.ReadLine());
                if (yearGrade >= 4)
                {

                    avrgGrade = (avrgGrade + yearGrade);

                }
                else if (yearGrade <= 4)
                {
                    skusan++;
                    if (skusan > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {classes} grade");
                        break;
                    }
                }
                ++classes;
                if (classes >= 12)
                {
                    Console.WriteLine($"{name} graduated. Average grade: {avrgGrade / 12:f2}");
                }
            }
        }
    }
}
