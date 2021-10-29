using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fishes;
        protected Aquarium(string name,int capacity)
        {
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
            Name = name;
            Capacity = capacity;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public int Comfort => decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishes;

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (fishes.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (var item in fishes)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name} ({GetType().Name})");
            if (fishes.Count > 0)
            {
                List<string> listOfNames = new List<string>();
                foreach (var item in Fish)
                {
                    listOfNames.Add(item.Name);
                }

                sb.AppendLine($"Fish: {string.Join(", ",listOfNames)}");
            }
            else
            {
                sb.AppendLine("Fish: none");
            }
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }
    }
}
