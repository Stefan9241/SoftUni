using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }
        public int Count => this.data.Count;
        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public void Add(Racer racer)
        {
            if (Count + 1 <= Capacity)
            {
                this.data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(x => x.Name == name);
            if (racer == null)
            {
                return false;
            }

            data.Remove(racer);
            return true;
        }

        public Racer GetOldestRacer()
        {
            Racer oldest = data.OrderByDescending(x => x.Age).First();
            return oldest;
        }

        public Racer GetRacer(string name)
        {
            Racer racer = data.First(x => x.Name == name);
            return racer;
        }

        public Racer GetFastestRacer()
        {
            Racer oldest = data.OrderByDescending(x => x.Car.Speed).First();
            return oldest;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in data)
            {
                sb.AppendLine($"Racer: {racer.Name}, {racer.Age} ({racer.Country})");
            }
            return sb.ToString().Trim();
        }
    }
}
