using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;
        public Egg(string name,int energyReq)
        {
            Name = name;
            EnergyRequired = energyReq;
        }
        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value < 0)
                {
                    energyRequired = 0;
                }

                energyRequired = value;
            }
        }

        public void GetColored()
        {
            if (EnergyRequired - 10 > 0)
            {
                EnergyRequired -= 10;
            }
            else
            {
                EnergyRequired = 0;
            }
        }

        public bool IsDone() => EnergyRequired == 0;
    }
}
