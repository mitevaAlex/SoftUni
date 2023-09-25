using System;
using System.Collections.Generic;
using System.Linq;

namespace Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();
            int dragonsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < dragonsCount; i++)
            {
                //{type} {name} {damage} {health} {armor}
                string[] dragonData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = dragonData[0];
                Dragon dragon = new Dragon(dragonData[1],
                    int.TryParse(dragonData[2], out int damage) ? damage : 45,
                    int.TryParse(dragonData[3], out int health) ? health : 250,
                    int.TryParse(dragonData[4], out int armor) ? armor : 10);
                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new List<Dragon>());
                }
                int oldDragonIndex = dragons[type].FindIndex(x => x.Name == dragon.Name);
                if (oldDragonIndex == -1)
                {
                    dragons[type].Add(dragon);
                }
                else
                {
                    dragons[type][oldDragonIndex] = dragon;
                }
            }
            Dictionary<string, List<Dragon>> sortedDragons = new Dictionary<string, List<Dragon>>();
            foreach (var kvp in dragons)
            {
                sortedDragons[kvp.Key] = dragons[kvp.Key]
                    .OrderBy(x => x.Name)
                    .ToList();
            }
            Console.WriteLine(string.Join(Environment.NewLine,
                sortedDragons.Select(x => $"{x.Key}::({x.Value.Average(y => y.Damage):F2}/{x.Value.Average(y => y.Health):F2}/{x.Value.Average(y => y.Armor):F2}){Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, x.Value.Select(y => $"-{y.Name} -> damage: {y.Damage}, health: {y.Health}, armor: {y.Armor}"))}")));
        }
    }
}
