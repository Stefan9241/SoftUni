using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            //read jury
            //text name 
            // score 
            //avg score
            //until finish
            int jury = int.Parse(Console.ReadLine());
            string title = Console.ReadLine();
            double totalScore = 0;
            double juryCount = 0;
            while (title != "Finish")
            {
                double currentTotalScore = 0;
                for (int i = 0; i < jury; i++)
                {
                    double score = double.Parse(Console.ReadLine());
                    currentTotalScore += score;
                    totalScore += score;
                    juryCount++;
                }
                Console.WriteLine($"{title} - {currentTotalScore / jury:f2}.");
                title = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {totalScore / juryCount:f2}.");
        }
    }
}
