﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
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

                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Hometown = hometown

                };
                studentList.Add(student);

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
    }
}
