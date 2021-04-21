using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = 10000;
            int steps = 0;
            bool isGoingHome = false;
            bool isReached = false;
            while (!isGoingHome && !isReached)
            {
                string text = Console.ReadLine();
                if (text == "Going home")
                {
                    isGoingHome = true;
                    text = Console.ReadLine();
                }
                steps += int.Parse(text);
                if (steps >= target)
                {
                    isReached = true;
                }
            }
            if (isReached)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - target} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{target - steps} more steps to reach goal.");
            }
            
        }
    }
}
