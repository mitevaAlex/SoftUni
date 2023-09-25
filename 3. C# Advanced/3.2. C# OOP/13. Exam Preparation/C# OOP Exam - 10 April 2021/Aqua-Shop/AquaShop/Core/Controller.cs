using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != nameof(FreshwaterAquarium) && aquariumType != nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium = null;
            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Plant) && decorationType != nameof(Ornament))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = null;
            if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(SaltwaterFish) && fishType != nameof(FreshwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IFish fish = null;
            IAquarium aquarium = aquariums
                .FirstOrDefault(x => x.Name == aquariumName);
            if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
                if (aquarium is FreshwaterAquarium)
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                if (aquarium is SaltwaterAquarium)
                {
                    return OutputMessages.UnsuitableWater;
                }
            }

            aquarium.AddFish(fish);

            return string.Format(
                OutputMessages.EntityAddedToAquarium,
                fishType,
                aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums
                .FirstOrDefault(x => x.Name == aquariumName);
            decimal fishValue = aquarium
                .Fish
                .Sum(x => x.Price);
            decimal decorationsValue = aquarium
                .Decorations
                .Sum(x => x.Price);
            decimal aquariumValue = fishValue + decorationsValue;

            return string.Format(
                OutputMessages.AquariumValue,
                aquariumName,
                aquariumValue);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums
                .FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquariums
                .FirstOrDefault(x => x.Name == aquariumName)
                .AddDecoration(decoration);

            decorations.Remove(decoration);

            return string.Format(
                OutputMessages.EntityAddedToAquarium,
                decorationType,
                aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IAquarium aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
