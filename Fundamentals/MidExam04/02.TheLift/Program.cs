using System;
using System.Linq;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int availableSpots = wagons.Length * 4;
            availableSpots -= wagons.Sum();
            bool flag = false;
            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] == 4)
                {
                    continue;
                }
                else if (wagons[i] == 3)
                {
                    if (people < 1)
                    {
                        wagons[i] = people;
                        availableSpots -= people;
                        people = 0;
                        flag = true;
                        break;
                    }
                    wagons[i] = 4;
                    people -= 1;
                    availableSpots -= 1;
                    if (people < 0)
                    {
                        int numberToAdd = Math.Abs(people);
                        availableSpots += numberToAdd;
                    }
                    if (people <= 0 && availableSpots > 0)
                    {
                        Console.WriteLine("The lift has empty spots!");
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                    else if (people > 0 && availableSpots <= 0)
                    {
                        Console.WriteLine($"There isn't enough space! {people} people in a queue!");

                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                    else if (availableSpots <= 0 && people <= 0)
                    {
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                }
                else if (wagons[i] == 2)
                {
                    if (people < 2)
                    {
                        wagons[i] = people;
                        availableSpots -= people;
                        people = 0;
                        flag = true;
                        break;
                    }
                    wagons[i] = 4;
                    people -= 2;
                    availableSpots -= 2;
                    if (people < 0)
                    {
                        int numberToAdd = Math.Abs(people);
                        availableSpots += numberToAdd;
                    }
                    if (people <= 0 && availableSpots > 0)
                    {
                        Console.WriteLine("The lift has empty spots!");
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                    else if (people > 0 && availableSpots <= 0)
                    {
                        Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                    else if (availableSpots <= 0 && people <= 0)
                    {
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                }
                else if (wagons[i] == 1)
                {
                    if (people < 3)
                    {
                        wagons[i] = people;
                        availableSpots -= people;
                        people = 0;
                        flag = true;
                        break;
                    }
                    wagons[i] = 4;
                    people -= 3;
                    availableSpots -= 3;
                    if (people < 0)
                    {
                        int numberToAdd = Math.Abs(people);
                        availableSpots += numberToAdd;
                    }
                    if (people <= 0 && availableSpots > 0)
                    {
                        Console.WriteLine("The lift has empty spots!");
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                    else if (people > 0 && availableSpots <= 0)
                    {
                        Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                    else if (availableSpots <= 0 && people <= 0)
                    {
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                }
                else if (wagons[i] == 0)
                {
                    if (people < 4)
                    {
                        wagons[i] = people;
                        availableSpots -= people;
                        people = 0;
                        flag = true;
                        break;
                    }
                    wagons[i] = 4;
                    people -= 4;
                    availableSpots -= 4;
                    if (people < 0)
                    {
                        int numberToAdd = Math.Abs(people);
                        availableSpots += numberToAdd;
                    }
                    if (people <= 0 && availableSpots > 0)
                    {
                        Console.WriteLine("The lift has empty spots!");
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                    else if (people > 0 && availableSpots <= 0)
                    {
                        Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                    else if (availableSpots <= 0 && people <= 0)
                    {
                        Console.WriteLine(string.Join(' ', wagons));
                        break;
                    }
                }

            }
            if (flag)
            {
                if (people < 0)
                {
                    int numberToAdd = Math.Abs(people);
                    availableSpots += numberToAdd;
                }
                if (people <= 0 && availableSpots > 0)
                {
                    Console.WriteLine("The lift has empty spots!");
                    Console.WriteLine(string.Join(' ', wagons));
                    
                }
                else if (people > 0 && availableSpots <= 0)
                {
                    Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                    Console.WriteLine(string.Join(' ', wagons));

                }
                else if (availableSpots <= 0 && people <= 0)
                {
                    Console.WriteLine(string.Join(' ', wagons));
                    
                }
            }
        }
    }
}
