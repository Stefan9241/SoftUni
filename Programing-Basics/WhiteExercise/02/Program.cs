using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumberBadResults = int.Parse(Console.ReadLine());
            int failedResults = 0;
            int solvedTasks = 0;
            double gradesSum = 0;
            string lastTask = "";
            bool isFailed = true;
            
            while (inputNumberBadResults > failedResults)
            {
                string problemName = Console.ReadLine();
                if (problemName == "Enough")
                {
                    isFailed = false;
                    break;
                }
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    failedResults++;
                }
                gradesSum += grade;
                solvedTasks++;
                lastTask = problemName;
                
            }
            if (isFailed)
            {
                Console.WriteLine($"You need a break, {failedResults} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {gradesSum / solvedTasks:f2}");
                Console.WriteLine($"Number of problems: {solvedTasks}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
        }
    }
}
