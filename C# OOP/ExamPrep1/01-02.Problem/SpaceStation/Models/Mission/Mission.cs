using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<IAstronaut> astros = astronauts.ToList();
            List<string> planetItems = planet.Items.ToList();

            for (int i = 0; i < astros.Count; i++)
            {
                if (planetItems.Count == 0)
                {
                    break;
                }
                for (int j = 0; j < planetItems.Count; j++)
                {
                    astros[i].Bag.Items.Add(planetItems[j]);
                    astros[i].Breath();
                    var itemToRemove = planetItems[j];
                    planetItems.Remove(itemToRemove);

                    if (!astros[i].CanBreath)
                    {
                        astros.Remove(astros[i]);
                        break;
                    }
                    j--;
                }
            }
        }
    }
}
