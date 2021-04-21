using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> player1= Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            List<int> player2 = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            int player1Cards = player1.Count;
            int player2Cards = player2.Count;


            while (true)
            {
                if (player1[0] == player2[0])
                {
                    player1.Remove(player1[0]);
                    player2.Remove(player2[0]);

                    player1Cards--;
                    player2Cards--;
                    if (player1Cards ==0 || player2Cards == 0)
                    {
                        break;
                    }
                }
                else if (player1[0] > player2[0])
                {
                    player1.Add(player1[0]);
                    player1.Add(player2[0]);
                    player2.Remove(player2[0]);
                    player1.Remove(player1[0]);

                    player1Cards++;
                    player2Cards--;
                    if (player2Cards == 0)
                    {
                        break;
                    }
                }
                else if (player2[0] > player1[0])
                {
                    player2.Add(player2[0]);
                    player2.Add(player1[0]);
                    player1.Remove(player1[0]);
                    player2.Remove(player2[0]);

                    player2Cards++;
                    player1Cards--;
                    if (player1Cards == 0)
                    {
                        break;
                    }
                }    
            }
            if (player1Cards > player2Cards)
            {
                Console.WriteLine($"First player wins! Sum: {player1.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {player2.Sum()}");
            }
        }
    }
}
