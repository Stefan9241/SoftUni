using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private readonly List<Car> Participants;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Laps { get; private set; }
        public int Capacity { get; private set; }
        public int MaxHorsePower { get; private set; }
        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            //if (Participants.Count + 1 <= Capacity && car.HorsePower <= MaxHorsePower)
            //{
            //    if (!Participants.Any(x => x.LicensePlate == car.LicensePlate))
            //    {
            //        Participants.Add(car);
            //    }
            //}

            bool existingPlate = !Participants.Exists(x => x.LicensePlate == car.LicensePlate);
            bool horsePowerLimit = this.MaxHorsePower >= car.HorsePower;
            bool haveSpot = Count < this.Capacity;
            if (existingPlate && haveSpot && horsePowerLimit)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            //if (Participants.Any(x => x.LicensePlate == licensePlate))
            //{
            //    var car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            //    Participants.Remove(car);
            //    return true;
            //}

            //return false;

            return Participants.Remove(Participants.Find(x => x.LicensePlate == licensePlate));
        }

        public Car FindParticipant(string licensePlate)
        {
            //if (Participants.Any(x => x.LicensePlate == licensePlate))
            //{
            //    Car car = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            //    return car;
            //}

            //return null;

            return Participants.Find(x => x.LicensePlate == licensePlate);
        }
        public Car GetMostPowerfulCar()
        {
            Car car = Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
            return car;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            //foreach (var car in Participants)
            //{
            //    sb.Append(car.ToString());
            //}

            for (int i = 0; i < Participants.Count; i++)
            {
                sb.AppendFormat($"{Participants[i]}");
            }

            return sb.ToString(); 
        }
    }
}
