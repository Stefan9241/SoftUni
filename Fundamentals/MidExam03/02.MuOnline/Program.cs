using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            int health = 100;
            int bitcoin = 0;
            string monsterKiller = string.Empty;
            int bestRoom = 0;
            bool isDead = false;
            for (int i = 0; i < input.Length; i++)
            {
                bestRoom++;
                string command = input[i];
                string[] splitCommand = command.Split();
                if (splitCommand[0] == "potion")
                {
                    int currHeal = int.Parse(splitCommand[1]);
                    if (health + currHeal > 100)
                    {
                        currHeal = 100 - health;
                    }
                    Console.WriteLine($"You healed for {currHeal} hp.");
                    health += currHeal;
                    
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (splitCommand[0] == "chest")
                {
                    int bitcoinsFound = int.Parse(splitCommand[1]);
                    Console.WriteLine($"You found {bitcoinsFound} bitcoins.");
                    bitcoin += bitcoinsFound;
                }
                else
                {
                    int monsterAttack = int.Parse(splitCommand[1]);
                    health -= monsterAttack;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {splitCommand[0]}.");
                    }
                    else
                    {
                        monsterKiller = splitCommand[0];
                        isDead = true;
                        break;
                    }
                }
            }
            if (isDead)
            {
                Console.WriteLine($"You died! Killed by {monsterKiller}.");
                Console.WriteLine($"Best room: {bestRoom}");
            }
            else
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoin}");
                Console.WriteLine($"Health: {health}");
            }
            
        }
    }
}
