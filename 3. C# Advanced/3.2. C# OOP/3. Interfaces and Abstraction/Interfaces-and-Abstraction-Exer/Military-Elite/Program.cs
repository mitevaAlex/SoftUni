using System;
using System.Collections.Generic;
using System.Linq;

namespace Military_Elite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();
            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                string[] soldierArgs = command
                    .Split(' ');
                string soldierType = soldierArgs[0];
                Soldier soldier = null;
                switch (soldierType)
                {
                    case "Private":
                        soldier = new Private(soldierArgs[1], soldierArgs[2], soldierArgs[3], decimal.Parse(soldierArgs[4]));
                        break;
                    case "LieutenantGeneral":
                        List<Private> privates = new List<Private>();
                        foreach (string id in soldierArgs.Skip(5))
                        {
                            Private @private = (Private)soldiers.Find(x => x.GetType().Name == "Private" && ((Private)x).Id == id);
                            privates.Add(@private);
                        }

                        soldier = new LieutenantGeneral(soldierArgs[1], soldierArgs[2], soldierArgs[3], decimal.Parse(soldierArgs[4]), privates.ToArray());
                        break;
                    case "Engineer":
                        List<Repair> repairs = new List<Repair>();
                        string[] repairArgs = soldierArgs
                            .Skip(6)
                            .ToArray();
                        for (int i = 0; i < repairArgs.Count() - 1; i += 2)
                        {
                            Repair repair = new Repair(repairArgs[i], int.Parse(repairArgs[i + 1]));
                            repairs.Add(repair);
                        }

                        try
                        {
                            soldier = new Engineer(soldierArgs[1], soldierArgs[2], soldierArgs[3], decimal.Parse(soldierArgs[4]), soldierArgs[5], repairs.ToArray());
                        }
                        catch
                        {
                            continue;
                        }
                        
                        break;
                    case "Commando":
                        List<Mission> missions = new List<Mission>();
                        string[] missionArgs = soldierArgs
                            .Skip(6)
                            .ToArray();
                        for (int i = 0; i < missionArgs.Count() - 1; i += 2)
                        {
                            try
                            {
                                Mission mission = new Mission(missionArgs[i], missionArgs[i + 1]);
                                missions.Add(mission);
                            }
                            catch
                            {
                                continue;
                            }
                        }

                        try
                        {
                            soldier = new Commando(soldierArgs[1], soldierArgs[2], soldierArgs[3], decimal.Parse(soldierArgs[4]), soldierArgs[5], missions.ToArray());
                        }
                        catch
                        {
                            continue;
                        }
                        
                        break;
                    case "Spy":
                        soldier = new Spy(soldierArgs[1], soldierArgs[2], soldierArgs[3], int.Parse(soldierArgs[4]));
                        break;
                }

                soldiers.Add(soldier);
            }

            soldiers.ForEach(x => Console.WriteLine(x));
        }
    }
}
