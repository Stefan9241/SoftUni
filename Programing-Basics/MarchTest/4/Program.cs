using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            int player1 = 0;
            int player2 = 0;
            string winner = "";
            string command = Console.ReadLine();
            while (command != "End of game")
            {
                int card1 = int.Parse(command);
                int card2 = int.Parse(Console.ReadLine());
                if (card1 == card2)
                {
                    Console.WriteLine("Number wars!");
                    card1 = int.Parse(Console.ReadLine());
                    card2 = int.Parse(Console.ReadLine());
                    if (card1 > card2)
                    {
                        winner = name1;
                        Console.WriteLine($"{winner} is winner with {player1} points");
                        return;
                    }
                    else if(card2 > card1)
                    {
                        winner = name2;
                        Console.WriteLine($"{winner} is winner with {player2} points");
                        return;
                    }
                    
                }
                if (card1 > card2)
                {
                    player1 += card1 - card2;
                }
                if (card2 > card1)
                {
                    player2 += card2 - card1;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{name1} has {player1} points");
            Console.WriteLine($"{name2} has {player2} points");
        }
    }
}
