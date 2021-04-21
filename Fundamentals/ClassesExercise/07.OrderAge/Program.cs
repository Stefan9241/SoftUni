using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                string name = command[0];
                string iD = command[1];
                int age = int.Parse(command[2]);

                Student currSdudent = new Student(name,iD,age);
                students.Add(currSdudent);

                command = Console.ReadLine().Split();
            }
            students = students.OrderBy(x => x.Age).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, students));
        }
    }

    class Student
    {
        public Student(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
