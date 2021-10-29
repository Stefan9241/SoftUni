using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations;
        private List<IFish> fishes;
        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
        }
        public IReadOnlyCollection<IDecoration> Models => decorations.AsReadOnly();

        public void Add(IDecoration model)
        {
            decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var decoration = decorations.FirstOrDefault(x => x.GetType().Name == type);
            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            return decorations.Remove(model);
        }
    }
}
