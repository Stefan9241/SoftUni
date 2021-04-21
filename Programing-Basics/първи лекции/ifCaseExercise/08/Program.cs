using System;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            double hourExam = double.Parse(Console.ReadLine());
            double minExam = double.Parse(Console.ReadLine());
            double hourArrive = double.Parse(Console.ReadLine());
            double minArrive = double.Parse(Console.ReadLine());

            double totalMinutesArrive = hourArrive * 60 + minArrive;
            double totalMinutesExam = hourExam * 60 + minExam;
            if (totalMinutesArrive > totalMinutesExam)
            {
                Console.WriteLine("Late");
                double lateMin = hourExam - hourArrive;

                if (lateMin <60)
                {
                    Console.WriteLine($"{lateMin} after the start");
                }
                else
                {
                    double lateHours = lateMin / 60;
                    double lateMins = lateMin % 60;
                    Console.WriteLine($"{lateHours}:{lateMins:D2} after the start");
                }
            }
            else if (totalMinutesArrive - totalMinutesExam <=30)
            {
                Console.WriteLine("On time");
                double minBeforeStart = totalMinutesExam - totalMinutesArrive;
                Console.WriteLine($"{minBeforeStart:f2} before the start");
            }
            else if (totalMinutesArrive - totalMinutesExam > 30)
            {
                Console.WriteLine("Early");
                
                double minEarly = totalMinutesExam - totalMinutesArrive;
                if(minEarly < 60)
                {
                    Console.WriteLine($"{minEarly} before the start");
                }
                else
                {
                    double hoursEarly = totalMinutesArrive / 60;
                    double minEarlyy = totalMinutesArrive % 60;
                    Console.WriteLine($"{hoursEarly}:{minEarlyy:D2} hours before the start");
                }
            }

        }
    }
}
