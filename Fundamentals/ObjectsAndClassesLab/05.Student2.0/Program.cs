using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Student2._0
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Hometown { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Student> studentList = new List<Student>();

            string[] command = Console.ReadLine().Split();
            while (true)
            {
                string firstName = command[0];
                string lastName = command[1];
                string age = command[2];
                string hometown = command[3];

                if (IsStudentExist(studentList, firstName, lastName))
                {
                    Student student = studentList.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
                    if (student == null)
                    {
                        studentList.Add(new Student()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Age = age,
                            Hometown = hometown
                        });
                    }
                    else
                    {
                        student.FirstName = firstName;
                        student.LastName = lastName;
                        student.Age = age;
                        student.Hometown = hometown;
                    }
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Hometown = hometown

                    };
                    studentList.Add(student);
                }

                command = Console.ReadLine().Split();
                if (command[0] == "end")
                {
                    break;
                }
            }
            string filterCity = Console.ReadLine();
            List<Student> newList = studentList
                .Where(n => n.Hometown == filterCity)
                .ToList();

            foreach (Student student in newList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        private static bool IsStudentExist(List<Student> studentList, string firstName, string lastName)
        {
            foreach (Student current in studentList)
            {
                if (current.FirstName == firstName && current.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
