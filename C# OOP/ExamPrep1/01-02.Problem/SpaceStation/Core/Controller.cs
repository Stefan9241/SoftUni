using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly List<Astronaut> astros;
        private readonly List<Planet> planets;
        private int exploredPlanets = 0;
        private int astrosExplored = 0;
        public Controller()
        {
            astros = new List<Astronaut>();
            planets = new List<Planet>();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            Astronaut astro = null;
            if (type == "Biologist")
            {
                astro = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astro = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astro = new Meteorologist(astronautName);
            }

            if (astro == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astros.Add(astro);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);
            for (int i = 0; i < items.Length; i++)
            {
                planet.Items.Add(items[i]);
            }
            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);

        }

        public string ExplorePlanet(string planetName)
        {
            ICollection<IAstronaut> astrosToExplore = astros.Where(x=>x.Oxygen> 60).ToList<IAstronaut>();
            Planet planet = planets.First(x => x.Name == planetName);
            if (astrosToExplore.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            this.exploredPlanets++;
            Mission mission = new Mission();
            this.astrosExplored = astrosToExplore.Count;
            mission.Explore(planet, astrosToExplore);
            int countSurvived = astrosExplored - astrosToExplore.Count;
            return string.Format(OutputMessages.PlanetExplored, planetName, countSurvived);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.exploredPlanets} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach (var astro in astros)
            {
                sb.AppendLine($"Name: {astro.Name}");
                sb.AppendLine($"Oxygen: {astro.Oxygen}");
                sb.AppendLine(astro.Bag.Items.Count > 0 ? $"Bag items: {string.Join(", ", astro.Bag.Items)}" : "Bag items: none");
            }

            return sb.ToString();
        }

        public string RetireAstronaut(string astronautName)
        {
            Astronaut astro = astros.FirstOrDefault(x => x.Name == astronautName);
            if (astro == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astros.Remove(astro);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
