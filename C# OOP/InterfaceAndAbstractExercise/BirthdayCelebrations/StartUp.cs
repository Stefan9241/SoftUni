using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var citizensAndPets = new List<IBirthday>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split();
                if (tokens[0] == "Citizen")
                {//Citizen <name> <age> <id> <birthdate>" 
                    citizensAndPets.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                }
                else if(tokens[0] == "Pet")
                {
                    citizensAndPets.Add(new Pet(tokens[2], tokens[1]));
                }
            }

            string filter = Console.ReadLine();
            var output = new List<string>();
            foreach (var personOrPet in citizensAndPets)
            {
                if (personOrPet.Birthday.EndsWith(filter))
                {
                    output.Add(personOrPet.Birthday);
                }
            }

            foreach (var date in output)
            {
                Console.WriteLine(date);
            }
        }
    }
}
