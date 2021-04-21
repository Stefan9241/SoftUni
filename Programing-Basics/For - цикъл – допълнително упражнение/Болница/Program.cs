using System;

namespace Болница
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());

            int doctors = 7;
            int reviewed = 0;
            int notReviewed = 0;
            for (int i = 1; i <= period; i++)
            {
                int patients = int.Parse(Console.ReadLine());
                if ((i % 3 == 0) && (notReviewed > reviewed))
                {
                    if (reviewed < notReviewed)
                    {
                        doctors++;
                    }

                    if (patients >= doctors)
                    {
                        reviewed += +doctors;
                        notReviewed += patients - doctors;
                    }
                    else
                    {
                        reviewed += patients;
                    }
                }
                else
                {
                    if (patients >= doctors)
                    {
                        reviewed += doctors;
                        notReviewed += patients - doctors;
                    }
                    else
                    {
                       reviewed += patients;
                    }
                }
            }
            Console.WriteLine($"Treated patients: {reviewed}.");
            Console.WriteLine($"Untreated patients: {notReviewed}.");
        }
    }
}
