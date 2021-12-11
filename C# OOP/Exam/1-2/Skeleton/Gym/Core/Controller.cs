using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;
        private readonly List<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            IAthlete atl;
            if (athleteType == "Boxer")
            {
                atl = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else
            {
                atl = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            var gyym = gyms.FirstOrDefault(x => x.Name == gymName);
            if (gyym.GetType().Name == "BoxingGym" && atl.GetType().Name != "Boxer")
            {
                return "The gym is not appropriate.";
            }

            if (gyym.GetType().Name == "WeightliftingGym" && atl.GetType().Name != "Weightlifter")
            {
                return "The gym is not appropriate.";
            }

            gyym.Athletes.Add(atl);

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            IEquipment equip;
            if (equipmentType == "BoxingGloves")
            {
                equip = new BoxingGloves();
            }
            else
            {
                equip = new Kettlebell();
            }

            equipment.Add(equip);

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }

            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.First(x => x.Name == gymName);

            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var quipt = equipment.FindByType(equipmentType);
            
            if (quipt is null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            var gym = gyms.First(x => x.Name == gymName);
           
            gym.Equipment.Add(quipt);
            equipment.Remove(quipt);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.First(x => x.Name == gymName);
            var count = 0;
            foreach (var item in gym.Athletes)
            {
                item.Exercise();
                count++;
            }

            return $"Exercise athletes: {count}.";
        }
    }
}
