using System;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    public class Animal
    {
        public Animal(string name, int foodQuanty, string area)
        {
            Name = name;
            FoodQuanty = foodQuanty;
            Area = area;
        }
        public string Name { get; set; }
        public int FoodQuanty { get; set; }
        public string Area { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            var dictArea = new Dictionary<string, int>();
            var animalInfo = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            while (animalInfo[0] != "EndDay")
            {
                var splitted = animalInfo[1].Split("-");
                splitted[0] = splitted[0].Trim();
                if (animalInfo[0] == "Add")
                {
                    if (animals.Any(x=> x.Name == splitted[0]))
                    {
                        var currAnimal = animals.First(x => x.Name == splitted[0]);
                        currAnimal.FoodQuanty += int.Parse(splitted[1]);

                    }
                    else
                    {
                        Animal animal = new Animal(splitted[0], int.Parse(splitted[1]), splitted[2]);
                        animals.Add(animal);
                        if (!dictArea.ContainsKey(animal.Area))
                        {
                            dictArea.Add(animal.Area, 1);
                        }
                        else
                        {
                            dictArea[animal.Area]++;
                        }
                    }
                }
                else if(animalInfo[0] == "Feed")
                {
                    string animalName = splitted[0];
                    int foodToGive = int.Parse(splitted[1]);
                    if (animals.Any(x=> x.Name == animalName))
                    {
                        var animal = animals.First(x => x.Name == animalName);
                        animal.FoodQuanty -= foodToGive;
                        if (animal.FoodQuanty <= 0)
                        {
                            Console.WriteLine($"{animalName} was successfully fed");
                            animals.Remove(animal);
                            dictArea[animal.Area]--;
                            if (dictArea[animal.Area] <= 0)
                            {
                                dictArea.Remove(animal.Area);
                            }
                        }
                    }
                }

                animalInfo = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Animals:");
            foreach (var animal in animals.OrderByDescending(x=> x.FoodQuanty).ThenBy(x=> x.Name))
            {
                Console.WriteLine($" {animal.Name} -> {animal.FoodQuanty}g");
            }

            Console.WriteLine("Areas with hungry animals:");
            foreach (var area in dictArea.OrderByDescending(x=> x.Value).ThenBy(x=> x.Key))
            {
                Console.WriteLine($" {area.Key}: {area.Value}");
            }

        }
    }
}
