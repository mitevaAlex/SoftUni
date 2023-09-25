using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string command = "";
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandArgs[1];
                string vlogger = commandArgs[0];
                switch (action)
                {
                    case "joined":
                        if (!vloggers.ContainsKey(vlogger))
                        {
                            vloggers.Add(vlogger, new Dictionary<string, SortedSet<string>>());
                            vloggers[vlogger].Add("followers", new SortedSet<string>());
                            vloggers[vlogger].Add("following", new SortedSet<string>());
                        }
                        break;
                    case "followed":
                        string followedVlogger = commandArgs[2];
                        if (vloggers.ContainsKey(vlogger) && vloggers.ContainsKey(followedVlogger))
                        {
                            if (vlogger != followedVlogger)
                            {
                                vloggers[vlogger]["following"].Add(followedVlogger);
                                vloggers[followedVlogger]["followers"].Add(vlogger);
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            vloggers = vloggers
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(x => x.Key, x => x.Value);
            int counter = 1;
            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }
    }
}
