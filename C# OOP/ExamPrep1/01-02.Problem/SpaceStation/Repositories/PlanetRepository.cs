using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<Planet>
    {
        private readonly Dictionary<string,Planet> models;
        public PlanetRepository()
        {
            models = new Dictionary<string, Planet>();
        }
        public IReadOnlyCollection<Planet> Models => models.Values.ToList();

        public void Add(Planet model)
        {
            models.Add(model.Name,model);
        }

        public Planet FindByName(string name)
        {
            return models[name];
        }

        public bool Remove(Planet model)
        {
            Planet planet = null;
            if (planet != null)
            {
                models.Remove(planet.Name);
                return true;
            }

            return false;
        }
    }
}
