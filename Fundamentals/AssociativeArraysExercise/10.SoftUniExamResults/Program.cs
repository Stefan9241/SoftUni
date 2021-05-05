using System;
using System.Collections.Generic;
using System.Linq;
namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();

            string[] cmdArgs = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);

            while (cmdArgs[0] != "exam finished")
            {
                if (cmdArgs.Length > 2)
                {
                    string user = cmdArgs[0];
                    string lenguage = cmdArgs[1];
                    int points = int.Parse(cmdArgs[2]);
                    if (!students.ContainsKey(user))
                    {
                        students.Add(user, points);
                    }
                    else
                    {
                        if (students[user] < points)
                        {
                            students[user] = points;
                        }
                    }

                    if (!submissions.ContainsKey(lenguage))
                    {
                        submissions.Add(lenguage, 0);
                    }
                    submissions[lenguage]++;

                }
                else
                {
                    students.Remove(cmdArgs[0]);
                }

                cmdArgs = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Results:");

            foreach (var currStudent in students.OrderByDescending(x=> x.Value).ThenBy(x=> x.Key))
            {
                Console.WriteLine($"{currStudent.Key} | {currStudent.Value}");
            }

            Console.WriteLine($"Submissions:");

            foreach (var sub in submissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{sub.Key} - {sub.Value}");
            }
        }
    }
}
