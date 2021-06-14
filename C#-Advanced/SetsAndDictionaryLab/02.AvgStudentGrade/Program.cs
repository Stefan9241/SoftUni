using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AvgStudentGrade
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numStudents; i++)
            {
                string[] curStundet = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string studentName = curStundet[0];
                decimal grade = decimal.Parse(curStundet[1]);

                if (dict.ContainsKey(studentName))
                {
                    dict[studentName].Add(grade);
                }
                else
                {
                    dict.Add(studentName, new List<decimal>());
                    dict[studentName].Add(grade);
                }
            }

            foreach (var student in dict)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ",student.Value.Select(x=>x.ToString("f2")))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
