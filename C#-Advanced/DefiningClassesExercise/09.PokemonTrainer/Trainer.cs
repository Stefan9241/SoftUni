using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; } = 0;
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }
    }
}
