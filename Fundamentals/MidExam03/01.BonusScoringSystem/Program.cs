using System;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            double numStudents = double.Parse(Console.ReadLine());
            double numLectures = double.Parse(Console.ReadLine());
            double initialPoints = double.Parse(Console.ReadLine());

            double maxPoints = 0;
            double maxLectures = 0;

            for (int i = 0; i < numStudents; i++)
            {
                double currStudentAttendence = double.Parse(Console.ReadLine());
                double currBonus = (currStudentAttendence / numLectures) * (5 + initialPoints);
                if (currBonus > maxPoints)
                {
                    maxPoints = currBonus;
                    maxLectures = currStudentAttendence;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxPoints)}.");
            Console.WriteLine($"The student has attended {maxLectures} lectures.");
        }
    }
}
