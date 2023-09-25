using System;
using System.Collections.Generic;
using System.Linq;

namespace Feed_The_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> animalsToFeed = new Dictionary<string, int>();
            Dictionary<string, int> hungryAnimalsInAreas = new Dictionary<string, int>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Last Info")
            {
                //"Add:{animalName}:{dailyFoodLimit}:{area}" or "Feed:{animalName}:{food}:{area}"
                string[] commandArgs = command
                    .Split(':');
                string operation = commandArgs[0];
                string name = commandArgs[1];
                int food = int.Parse(commandArgs[2]);
                string area = commandArgs[3];
                if (operation == "Add")
                {
                    if (animalsToFeed.ContainsKey(name))
                    {
                        animalsToFeed[name] += food;
                    }
                    else
                    {
                        animalsToFeed.Add(name, food);
                        if (!hungryAnimalsInAreas.ContainsKey(area))
                        {
                            hungryAnimalsInAreas.Add(area, 1);
                        }
                        else
                        {
                            hungryAnimalsInAreas[area]++;
                        }
                    }
                }
                else if (operation == "Feed" && animalsToFeed.ContainsKey(name))
                {
                    animalsToFeed[name] -= food;
                    if (animalsToFeed[name] <= 0)
                    {
                        Console.WriteLine($"{name} was successfully fed");
                        hungryAnimalsInAreas[area]--;
                        animalsToFeed.Remove(name);
                    }
                }
            }
            animalsToFeed = animalsToFeed
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Animals:" +
                $"{string.Join("", animalsToFeed.Select(x => $"{Environment.NewLine}{x.Key} -> {x.Value}g"))}");
            hungryAnimalsInAreas = hungryAnimalsInAreas
                .Where(x => x.Value > 0)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Areas with hungry animals:" +
                $"{string.Join("", hungryAnimalsInAreas.Select(x => $"{Environment.NewLine}{x.Key} : {x.Value}"))}");
        }
    }
}
