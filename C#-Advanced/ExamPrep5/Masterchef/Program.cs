using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingridientValue = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] freshnesValue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var queueIngridients = new Queue<int>(ingridientValue);
            var stackFreshnes = new Stack<int>(freshnesValue);
            bool dippingSauce = false;
            bool greenSalad = false;
            bool chocoCake = false;
            bool lobster = false;


            var dictionary = new Dictionary<string, int>();
            int counterSuccesful = 0;
            while (queueIngridients.Count > 0 && stackFreshnes.Count > 0)
            {
                if (queueIngridients.Peek() <= 0)
                {
                    queueIngridients.Dequeue();
                    continue;
                }
                double totalFreshnes = queueIngridients.Peek() * stackFreshnes.Peek();
                if (totalFreshnes == 150)
                {
                    if (dictionary.ContainsKey("Dipping sauce"))
                    {
                        dictionary["Dipping sauce"]++;
                    }
                    else
                    {
                        dictionary.Add("Dipping sauce", 1);
                    }
                    dippingSauce = true;
                    queueIngridients.Dequeue();
                    stackFreshnes.Pop();
                }
                else if(totalFreshnes == 250)
                {
                    if (dictionary.ContainsKey("Green salad"))
                    {
                        dictionary["Green salad"]++;
                    }
                    else
                    {
                        dictionary.Add("Green salad", 1);
                    }
                    greenSalad = true;
                    queueIngridients.Dequeue();
                    stackFreshnes.Pop();
                }
                else if (totalFreshnes == 300)
                {
                    if (dictionary.ContainsKey("Chocolate cake"))
                    {
                        dictionary["Chocolate cake"]++;
                    }
                    else
                    {
                        dictionary.Add("Chocolate cake", 1);
                    }
                    chocoCake = true;
                    queueIngridients.Dequeue();
                    stackFreshnes.Pop();
                }
                else if (totalFreshnes == 400)
                {
                    if (dictionary.ContainsKey("Lobster"))
                    {
                        dictionary["Lobster"]++;
                    }
                    else
                    {
                        dictionary.Add("Lobster", 1);
                    }
                    lobster = true;
                    queueIngridients.Dequeue();
                    stackFreshnes.Pop();
                }
                else
                {
                    stackFreshnes.Pop();
                    queueIngridients.Enqueue(queueIngridients.Dequeue() + 5);
                }

                counterSuccesful++;
            }

            if (lobster && chocoCake && greenSalad && dippingSauce)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (queueIngridients.Count > 0)
            {
                Console.WriteLine($" Ingredients left: {queueIngridients.Sum()}");
            }

            foreach (var ingr in dictionary.OrderBy(x=> x.Key))
            {
                Console.WriteLine($" # {ingr.Key} --> {ingr.Value}");
            }
        }
    }
}
