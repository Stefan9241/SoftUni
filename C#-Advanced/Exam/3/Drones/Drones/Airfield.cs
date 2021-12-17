using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private readonly List<Drone> drones;
        public Airfield(string name,int capacity,double landing)
        {
            var dictionary = new Dictionary<Stack<int>,string>();
            drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landing;
        }
        public IReadOnlyCollection<Drone> Drones => drones;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            bool nameCheck = string.IsNullOrEmpty(drone.Name);
            bool brandCheck = string.IsNullOrEmpty(drone.Brand);
            bool rangeCkeck = false;
            if (drone.Range >= 5 && drone.Range <= 15)
            {
                rangeCkeck = true;
            }

            if (rangeCkeck == false || nameCheck || brandCheck)
            {
                throw new System.Exception("Invalid drone.");
            }

            if (Count == Capacity)
            {
                return "Airfield is full.";
            }

            drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var drone = drones.FirstOrDefault(x => x.Name == name);
            if (drone is null)
            {
                return false;
            }

            drones.Remove(drone);
            return true;
        }

        public int RemoveDroneByBrand(string brand)
        {
            var list = drones.Where(x => x.Brand == brand).ToList();
            foreach (var item in list)
            {
                drones.Remove(item);
            }

            return list.Count;
        }

        public Drone FlyDrone(string name)
        {
            var drone = drones.FirstOrDefault(x => x.Name == name);

            if (drone is null)
            {
                return null;
            }
            drone.Available = false;
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var list = drones.Where(x => x.Range >= range).ToList();
            foreach (var item in list)
            {
                FlyDrone(item.Name);
            }

            return list;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");

            foreach (var drone in drones.Where(x=> x.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
