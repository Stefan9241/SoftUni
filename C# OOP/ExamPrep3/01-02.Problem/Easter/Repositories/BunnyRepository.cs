using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly Dictionary<string,IBunny> models;
        public BunnyRepository()
        {
            models = new Dictionary<string, IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => (IReadOnlyCollection<IBunny>)models.Values;

        public void Add(IBunny model)
        {
            if (!models.ContainsKey(model.Name))
            {
                models.Add(model.Name, model);
            }
        }

        public IBunny FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Key == name).Value;
        }

        public bool Remove(IBunny model)
        {
            return models.Remove(model.Name);
        }
    }
}
