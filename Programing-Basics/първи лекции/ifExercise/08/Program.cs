using System;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double average = double.Parse(Console.ReadLine());
            double minWage = double.Parse(Console.ReadLine());
            double minScholarship = Math.Floor(minWage * 0.35);
            double maxScholarship = Math.Floor(average * 25);
            if(income <=minWage && average >= 5.5 && maxScholarship >= minScholarship)
            {
                Console.WriteLine($"You get a scholarship for excellent results {maxScholarship} BGN");
            }
            else if (income <= minWage && average >= 5.5 && maxScholarship < minScholarship)
            {
                Console.WriteLine($"You get a Social scholarship {minScholarship} BGN");
            }
            else if (income <= minWage && average > 4.5)
            {
                Console.WriteLine($"You get a Social scholarship {minScholarship} BGN");
            }
            else if (income > minWage && average >= 5.5)
            {
                Console.WriteLine($"You get a scholarship for excellent results {maxScholarship} BGN");
            }
            else Console.WriteLine("You cannot get a scholarship!");



        }
    }
}
