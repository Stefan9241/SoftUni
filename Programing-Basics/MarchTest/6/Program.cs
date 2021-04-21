using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int recordTWants = int.Parse(Console.ReadLine());
            int currentJump = int.Parse(Console.ReadLine());
            int tihomirsStats = recordTWants - 30;
            int jumpCounter = 1;
            while (true)
            {
                if (currentJump <= tihomirsStats)
                {
                    
                    for (int i = 0; i < 2; i++)
                    {
                        currentJump = int.Parse(Console.ReadLine());
                        jumpCounter++;
                        if (currentJump > tihomirsStats)
                        {
                            break;
                        }
                        if (i == 1)
                        {
                            Console.WriteLine($"Tihomir failed at {tihomirsStats}cm after {jumpCounter} jumps.");
                            Environment.Exit(0);
                        }
                    }
                }
                if (tihomirsStats >= recordTWants)
                {
                    Console.WriteLine($"Tihomir succeeded, he jumped over {tihomirsStats}cm after {jumpCounter} jumps.");
                    break;
                }
                tihomirsStats += 5;
                currentJump = int.Parse(Console.ReadLine());
                jumpCounter++;
            }
        }
    }
}
