using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> drivers;
        public DriverRepository()
        {
            drivers = new List<IDriver>();
        }
        public void Add(IDriver model)
        {
            drivers.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll() => drivers;

        public IDriver GetByName(string name)
        {
            var driver = drivers.FirstOrDefault(x => x.Name == name);
            return driver;
        }

        public bool Remove(IDriver model)
        {
            return drivers.Remove(model);
        }
    }
}
