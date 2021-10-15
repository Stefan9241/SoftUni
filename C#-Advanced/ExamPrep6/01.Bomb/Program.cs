using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersBombEffects = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var numbersBombCasing = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var queueBombEffects = new Queue<int>(numbersBombEffects);
            var stackBombCasing = new Stack<int>(numbersBombCasing);
            int daturaBombsCount = 0;
            int cherryBombsCount = 0;
            int smokeDecoyBombsCount = 0;
            while (queueBombEffects.Count > 0 && stackBombCasing.Count > 0)
            {
                var currSum = queueBombEffects.Peek() + stackBombCasing.Peek();
                if (currSum == 40)
                {
                    daturaBombsCount++;
                    queueBombEffects.Dequeue();
                    stackBombCasing.Pop();
                }
                else if(currSum == 60)
                {
                    cherryBombsCount++;
                    queueBombEffects.Dequeue();
                    stackBombCasing.Pop();
                }
                else if (currSum == 120)
                {
                    smokeDecoyBombsCount++;
                    queueBombEffects.Dequeue();
                    stackBombCasing.Pop();
                }
                else
                {
                    stackBombCasing.Push(stackBombCasing.Pop() - 5);
                }

                if (daturaBombsCount >= 3 && cherryBombsCount >= 3 && smokeDecoyBombsCount >= 3)
                {
                    break;
                }
            }

            if (daturaBombsCount >= 3 && cherryBombsCount >= 3 && smokeDecoyBombsCount >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (queueBombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",queueBombEffects)}");
            }

            if (stackBombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", stackBombCasing)}");
            }


            Console.WriteLine($"Cherry Bombs: {cherryBombsCount}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombsCount}");
        }
    }
}
