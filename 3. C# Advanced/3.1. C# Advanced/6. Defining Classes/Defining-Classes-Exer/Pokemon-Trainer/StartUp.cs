using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainersDic = new Dictionary<string, Trainer>();
            string command = "";
            while ((command = Console.ReadLine()) != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Pokemon pokemon = new Pokemon(commandArgs[1], commandArgs[2], int.Parse(commandArgs[3]));
                if (trainersDic.ContainsKey(commandArgs[0]))
                {
                    trainersDic[commandArgs[0]].Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(commandArgs[0], pokemon);
                    trainersDic.Add(trainer.Name, trainer);
                }
            }

            List<Trainer> trainers = trainersDic
                .Select(x => x.Value)
                .ToList();
            Func<string, Trainer, bool> hasElement = (element, trainer) => trainer.Pokemons.Where(pokemon => pokemon.Element == element).Count() >= 1;
            while ((command = Console.ReadLine()) != "End")
            {
                //"Fire" / "Water" / "Electricity"
                for (int i = 0; i < trainers.Count; i++)
                {
                    if (hasElement(command, trainers[i]))
                    {
                        trainers[i].AddBadge();
                    }
                    else
                    {
                        trainers[i].ReducePokemonsHealth();
                    }

                    trainers[i].RemoveDeadPokemons();
                }
            }

            trainers = trainers
                .OrderByDescending(trainer => trainer.Badges)
                .ToList();
            Console.WriteLine(string.Join(Environment.NewLine, trainers));
        }
    }
}
