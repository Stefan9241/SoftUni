using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;
        public Dye(int power)
        {
            Power = power;
        }
        public int Power
        {
            get => this.power;
            private set
            {
                if (value > 0)
                {
                    power = value;
                }
                else
                {
                    power = 0;
                }
            }
        }

        public bool IsFinished() => Power == 0;

        public void Use()
        {
            if (Power - 10 > 0)
            {
                Power -= 10;
            }
            else
            {
                Power = 0;
            }
        }
    }
}
