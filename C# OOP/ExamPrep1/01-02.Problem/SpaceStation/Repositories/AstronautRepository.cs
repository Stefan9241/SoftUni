using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<Astronaut>
    {
        private readonly Dictionary<string, Astronaut> models;
        public AstronautRepository()
        {
            models = new Dictionary<string, Astronaut>();
        }
        public IReadOnlyCollection<Astronaut> Models => models.Values.ToList();

        public void Add(Astronaut model)
        {
            models.Add(model.Name, model);
        }

        public Astronaut FindByName(string name)
        {
            Astronaut astro = null;
            if (models.ContainsKey(name))
            {
                astro = models[name];
            }

            return astro;
        }

        public bool Remove(Astronaut model)
        {
            var astro = models[model.Name];
            if (astro != null)
            {
                models.Remove(model.Name);
                return true;
            }

            return false;
        }
    }
}
