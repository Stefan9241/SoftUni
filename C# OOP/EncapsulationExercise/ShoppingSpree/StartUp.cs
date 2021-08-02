using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();

            string[] inputPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputPeople.Length; i++)
            {
                try
                {
                    string[] splittedInput = inputPeople[i].Split("=");
                    Person currPerson = new Person(splittedInput[0], int.Parse(splittedInput[1]));
                    people.Add(currPerson);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputProducts.Length; i++)
            {
                try
                {
                    string[] splittedInput = inputProducts[i].Split("=");
                    Product currProduct = new Product(splittedInput[0], int.Parse(splittedInput[1]));
                    products.Add(currProduct);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "END")
            {
                try
                {
                    string currentPersonShopping = commands[0];
                    string currentProduct = commands[1];
                    Person currPerson = people.FirstOrDefault(x => x.Name == currentPersonShopping);
                    Product currProduct = products.FirstOrDefault(x => x.Name == currentProduct);
                    currPerson.AddProduct(currPerson, currProduct);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
