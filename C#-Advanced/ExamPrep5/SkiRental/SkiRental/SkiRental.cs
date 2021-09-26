using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private readonly List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => data.Count;

        public void Add(Ski ski)
        {
            if (Count + 1 <= Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var skiToRemove = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (skiToRemove == null)
            {
                return false;
            }
            data.Remove(skiToRemove);
            return true;
        }

        public Ski GetNewestSki()
        {
            var newestSki = data.OrderByDescending(x => x.Year).FirstOrDefault();
            return newestSki;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            var ski = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return ski;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString();
        }
    }
}
