using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Tournament")
            {
                string trainerName = commands[0];
                string pokemonName = commands[1];
                string pokemonElement = commands[2];
                int pokemonHp = int.Parse(commands[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHp);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }
                Trainer curTrainer = trainers.First(x => x.Name == trainerName);
                curTrainer.Pokemons.Add(pokemon);
                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.RemoveAt(i);
                                i--;
                            }

                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x=> x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
