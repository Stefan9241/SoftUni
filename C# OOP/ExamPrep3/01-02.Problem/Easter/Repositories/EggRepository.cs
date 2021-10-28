using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly Dictionary<string, IEgg> models;
        public EggRepository()
        {
            models = new Dictionary<string, IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => (IReadOnlyCollection<IEgg>)models.Values;

        public void Add(IEgg model)
        {
            if (!models.ContainsKey(model.Name))
            {
                models.Add(model.Name, model);
            }
        }

        public IEgg FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Key == name).Value;
        }

        public bool Remove(IEgg model)
        {
            return models.Remove(model.Name);
        }
    }
}
