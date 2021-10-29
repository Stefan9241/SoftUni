using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private List<IAquarium> aquariums;
        public Controller()
        {
            decorationRepository = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            //IAquarium aquarium = default;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            IDecoration deco = null;
            if (decorationType == "Ornament")
            {
                deco = new Ornament();
            }
            else
            {
                deco = new Plant();
            }

            decorationRepository.Add(deco);
            return $"Successfully added {decorationType}.";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var deco = decorationRepository.FindByType(decorationType);
            if (deco is null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            IAquarium desiredAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            desiredAquarium.AddDecoration(deco);
            decorationRepository.Remove(deco);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }
        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            IFish fish = null;
            if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }

            var akva = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (akva.GetType().Name == nameof(FreshwaterAquarium) && fish.GetType().Name == nameof(FreshwaterFish))
            {
                akva.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else if(akva.GetType().Name == nameof(SaltwaterAquarium) && fish.GetType().Name == nameof(SaltwaterFish))
            {
                akva.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }

            return "Water not suitable.";
        }

        public string FeedFish(string aquariumName)
        {
            var akva = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            akva.Feed();

            return $"Fish fed: {akva.Fish.Count}";
        }
        public string CalculateValue(string aquariumName)
        {
            var akva = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal price = 0;
            foreach (var item in akva.Fish)
            {
                price += item.Price;
            }

            foreach (var item in akva.Decorations)
            {
                price += item.Price;
            }

            return $"The value of Aquarium {aquariumName} is {price:f2}.";
        }



        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var akva in aquariums)
            {
                sb.AppendLine(akva.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
