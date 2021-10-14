using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            var queueNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var stackNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var queueLiquids = new Queue<int>(queueNumbers);
            var stackIngredientValues = new Stack<int>(stackNumbers);

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;
            bool isBread = false;
            bool isCake = false;
            bool isPastry = false;
            bool isFruitPie = false;

            while (queueLiquids.Count > 0 && stackIngredientValues.Count > 0)
            {
                var sum = stackIngredientValues.Peek() + queueLiquids.Peek();
                if (sum == 25)
                {
                    breadCount++;
                    stackIngredientValues.Pop();
                    queueLiquids.Dequeue();
                    isBread = true;
                }
                else if(sum == 50)
                {
                    cakeCount++;
                    stackIngredientValues.Pop();
                    queueLiquids.Dequeue();
                    isCake = true;
                }
                else if (sum == 75)
                {
                    pastryCount++;
                    stackIngredientValues.Pop();
                    queueLiquids.Dequeue();
                    isPastry = true;
                }
                else if (sum == 100)
                {
                    fruitPieCount++;
                    stackIngredientValues.Pop();
                    queueLiquids.Dequeue();
                    isFruitPie = true;
                }
                else
                {
                    queueLiquids.Dequeue();
                    stackIngredientValues.Push(stackIngredientValues.Pop() + 3);
                }
            }

            if (isBread && isCake && isPastry && isFruitPie)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (queueLiquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",queueLiquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (stackIngredientValues.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", stackIngredientValues)}");
                
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");
        }
    }
}
