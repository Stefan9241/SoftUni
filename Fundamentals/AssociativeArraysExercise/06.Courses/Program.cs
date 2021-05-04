using System;
using System.Collections.Generic;
using System.Linq;
namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string[] comArgs = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            while (comArgs[0] != "end")
            {
                string courseName = comArgs[0];
                string studentName = comArgs[1];
                if (!dict.ContainsKey(courseName))
                {
                    dict.Add(courseName, new List<string> { studentName });
                }
                else
                {
                    dict[courseName].Add(studentName);
                }
                comArgs = Console.ReadLine().
                    Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var course in dict.OrderByDescending(x=> x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var item in course.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
