using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberPeople = int.Parse(Console.ReadLine());
            var people = new List<IBuyer>();
            for (int i = 0; i < numberPeople; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    //"<name> <age> <id> <birthdate>"
                    people.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
                }
                else
                {
                    //"<name> <age><group>" 
                    people.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
                }
            }

            var commands = Console.ReadLine();
            while (commands != "End")
            {
                foreach (var person in people)
                {
                    IBuyer currPerson = people.FirstOrDefault(x => x.Name == commands);
                    if (currPerson != null)
                    {
                        currPerson.BuyFood();
                        break;
                    }
                }
                commands = Console.ReadLine();
            }

            Console.WriteLine(people.Sum(x=> x.Food));
        }
    }
}
