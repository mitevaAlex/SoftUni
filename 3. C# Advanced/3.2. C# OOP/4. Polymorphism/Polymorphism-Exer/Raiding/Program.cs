using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int raidGroupCount = int.Parse(Console.ReadLine());
            List<BaseHero> raidGroup = new List<BaseHero>();
            while (raidGroup.Count < raidGroupCount)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                BaseHero hero = null;
                switch (type)
                {
                    case "Druid":
                        hero = new Druid(name);
                        break;
                    case "Paladin":
                        hero = new Paladin(name);
                        break;
                    case "Rogue":
                        hero = new Rogue(name);
                        break;
                    case "Warrior":
                        hero = new Warrior(name);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }

                if (!(hero is null))
                {
                    raidGroup.Add(hero);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            raidGroup.ForEach(x => Console.WriteLine(x.CastAbility()));

            int powerSum = raidGroup.Sum(x => x.Power);
            Console.WriteLine(powerSum >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
