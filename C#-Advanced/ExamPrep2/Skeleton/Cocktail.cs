using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public HashSet<Ingredient> Ingredients { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int MaxAlcoholLevel { get; private set; }
        public int CurrentAlcoholLevel => this.Ingredients.Count;

        public Cocktail(string name, int capacity, int maxAlc)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlc;
            Ingredients = new HashSet<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.Count + 1 <= Capacity && Ingredients.Contains(ingredient) == false)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            bool exist = false;
            var currIngredient = Ingredients.FirstOrDefault(x => x.Name == name);
            if (currIngredient != null)
            {
                Ingredients.Remove(currIngredient);
                exist = true;
            }
            return exist;
        }

        public Ingredient FindIngredient(string name)
        {
            var currIngredient = Ingredients.FirstOrDefault(x => x.Name == name);
            return currIngredient;
        }

        public Ingredient GetMostAlcoholicIngredient() => Ingredients
            .OrderByDescending(x => x.Alcohol)
            .FirstOrDefault();


        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
