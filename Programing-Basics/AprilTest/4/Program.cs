using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerOneEggs = int.Parse(Console.ReadLine());
            int playerTwoEggs = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            while (command != "End of battle")
            {
                if (command == "one")
                {
                    playerTwoEggs--;
                }
                else
                {
                    playerOneEggs--;
                }
                if (playerOneEggs < 1)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {playerTwoEggs} eggs left.");
                    return;
                }
                else if (playerTwoEggs < 1)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {playerOneEggs} eggs left.");
                    return;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Player one has {playerOneEggs} eggs left.");
            Console.WriteLine($"Player two has {playerTwoEggs} eggs left.");
        }
    }
}
