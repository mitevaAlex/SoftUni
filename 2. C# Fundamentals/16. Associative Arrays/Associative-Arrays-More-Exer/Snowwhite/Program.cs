using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Dwarf>> dwarves = new Dictionary<string, List<Dwarf>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                //"{dwarfName} <:> {dwarfHatColor} <:> {dwarfPhysics}"
                string[] dwarfData = command
                    .Split(" <:> ");
                string name = dwarfData[0];
                Dwarf dwarf = new Dwarf(dwarfData[1], int.Parse(dwarfData[2]));
                if (dwarves.ContainsKey(name))
                {
                    int oldDwarfIndex = dwarves[name].FindIndex(x => x.HatColor == dwarf.HatColor);
                    if (oldDwarfIndex == -1)
                    {
                        dwarves[name].Add(dwarf);
                    }
                    else
                    {
                        bool haveToRemove = dwarves[name][oldDwarfIndex].Physics > dwarf.Physics
                            ? false
                            : true;
                        if (haveToRemove)
                        {
                            dwarves[name].RemoveAt(oldDwarfIndex);
                            dwarves[name].Add(dwarf);
                        }
                    }
                }
                else
                {
                    dwarves.Add(name, new List<Dwarf> { dwarf });
                }
            }
            List<Dwarf> finalDwarves = new List<Dwarf>();
            foreach (var kvp in dwarves)
            {
                kvp.Value.ForEach(x => finalDwarves.Add(new Dwarf(kvp.Key, x.HatColor, x.Physics)));
            }
            finalDwarves = finalDwarves
                .OrderByDescending(x => x.Physics)
                .ThenByDescending(x => finalDwarves.Where(y => y.HatColor == x.HatColor).Count())
                .ToList();
            Console.WriteLine(string.Join(Environment.NewLine,
                finalDwarves.Select(x => $"({x.HatColor}) {x.Name} <-> {x.Physics}")));
        }
    }
}
