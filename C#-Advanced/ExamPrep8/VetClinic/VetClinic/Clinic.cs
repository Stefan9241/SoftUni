using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private readonly List<Pet> data;

        public Clinic(int capacity)
        {
            this.data = new List<Pet>();
            Capacity = capacity;
        }
        public int Capacity { get;private set; }
        public int Count => data.Count;

        public void Add(Pet pet)
        {
            if (Count + 1 <= Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            var pet = data.FirstOrDefault(x => x.Name == name);
            if (pet != null)
            {
                data.Remove(pet);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            var pet = data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            return pet;
        }

        public Pet GetOldestPet()
        {
            var pet = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return pet;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString();
        }
    }
}
