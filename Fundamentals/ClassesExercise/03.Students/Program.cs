using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>(n);
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                Student currentStudent = new Student();
                currentStudent.FirstName = tokens[0];
                currentStudent.SecondName = tokens[1];
                currentStudent.Grade = double.Parse(tokens[2]);
                students.Add(currentStudent);
            }
            students = students.OrderByDescending(x => x.Grade).ToList();
            Console.WriteLine(string.Join(Environment.NewLine,students));
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:f2}";
        }
    }
}
