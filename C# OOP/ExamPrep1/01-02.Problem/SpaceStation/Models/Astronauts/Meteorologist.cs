using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        public Meteorologist(string name) : base(name, 90)
        {
        }
        public override void Breath()
        {
            Oxygen -= 10;
            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
    }
}
