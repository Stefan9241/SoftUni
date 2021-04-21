using System;

namespace Оценки
{
    class Program
    {
        static void Main(string[] args)
        {
            double numStudents = int.Parse(Console.ReadLine());
            double counterTwo = 0;
            double counterThree = 0;
            double counterFour = 0;
            double counterFive = 0;
            double sumGrade = 0;
            for (int i = 1; i <= numStudents; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 2.00 && grade <= 2.99)
                {
                    sumGrade += grade;
                    counterTwo++;
                }
                else if (grade >= 3.00 && grade <= 3.99)
                {
                    sumGrade += grade;
                    counterThree++;
                }
                else if (grade >= 4.00 && grade <= 4.99)
                {
                    sumGrade += grade;
                    counterFour++;
                }
                else
                {
                    sumGrade += grade;
                    counterFive++;
                }
            }
            Console.WriteLine($"Top students: {(counterFive * 100) / numStudents:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(counterFour * 100) / numStudents:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(counterThree * 100) / numStudents:f2}%");
            Console.WriteLine($"Fail: {(counterTwo * 100) / numStudents:f2}%");
            Console.WriteLine($"Average: {sumGrade / numStudents:F2}");
        }
    }
}
