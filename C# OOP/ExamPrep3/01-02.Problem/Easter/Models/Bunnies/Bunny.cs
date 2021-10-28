using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private List<IDye> dyes;
        protected Bunny(string name, int energy)
        {
            dyes = new List<IDye>();
            Name = name;
            Energy = energy;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Bunny name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }
                else
                {
                    energy = value;
                }
            }
        }

        public ICollection<IDye> Dyes => this.dyes;
        public abstract void Work();
        public void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }
    }
}
