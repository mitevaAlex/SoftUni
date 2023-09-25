using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                ["shards"] = 0,
                ["motes"] = 0,
                ["fragments"] = 0

            };
            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();
            bool reachedLegendaryItem = false;
            string itemObtainedMaterial = string.Empty;
            while (!reachedLegendaryItem)
            {
                //"{quantity} {material} {quantity} {material} … {quantity} {material}"
                string[] currentMaterials = Console.ReadLine()
                    .ToLower()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < currentMaterials.Length; i += 2)
                {
                    string material = currentMaterials[i + 1];
                    int quantity = int.Parse(currentMaterials[i]);
                    if (material != "shards" && material != "motes" && material != "fragments")
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials.Add(material, 0);
                        }
                        junkMaterials[material] += quantity;
                    }
                    else
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials[material] >= 250)
                        {
                            reachedLegendaryItem = true;
                            itemObtainedMaterial = material;
                            keyMaterials[material] -= 250;
                            break;
                        }
                    }
                }
            }

            string itemObtained = string.Empty;
            if (itemObtainedMaterial == "shards")
            {
                itemObtained = "Shadowmourne";
            }
            else if (itemObtainedMaterial == "motes")
            {
                itemObtained = "Dragonwrath";
            }
            else if (itemObtainedMaterial == "fragments")
            {
                itemObtained = "Valanyr";
            }
            Console.WriteLine($"{itemObtained} obtained!");
            Console.WriteLine(string.Join(Environment.NewLine,
                keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key}: {x.Value}")));
            Console.WriteLine(string.Join(Environment.NewLine,
                junkMaterials.Select(x => $"{x.Key}: {x.Value}")));
        }
    }
}
