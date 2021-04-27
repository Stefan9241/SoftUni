using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPersonEff = int.Parse(Console.ReadLine());
            int secondPersonEff = int.Parse(Console.ReadLine());
            int thirdPersonEff = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());


            int totalPeopleForHour = firstPersonEff + secondPersonEff + thirdPersonEff;
            int hoursNeeded = 0;

            while (peopleCount > 0)
            {
                hoursNeeded++;
                peopleCount -= totalPeopleForHour;
                if (hoursNeeded % 4 ==0)
                {
                    hoursNeeded++;
                }
            }
            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
