using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bands = new Dictionary<string, List<string>>();
            Dictionary<string, int> playTimes = new Dictionary<string, int>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "start of concert")
            {
                //"Add; {bandName}; {member 1}, {member 2}, {member 3}" or "Play; {bandName}; {time}" 
                string[] bandArgs = command
                    .Split(new string[] { "; ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                string operation = bandArgs[0];
                string bandName = bandArgs[1];
                if (operation == "Add")
                {
                    if (!bands.ContainsKey(bandName))
                    {
                        bands.Add(bandName, new List<string>());
                        AddMemebers(bandArgs, bands[bandName]);
                    }
                    else
                    {
                        AddMemebers(bandArgs, bands[bandName]);
                    }
                }
                else if (operation == "Play")
                {
                    int time = int.Parse(bandArgs[2]);
                    if (playTimes.ContainsKey(bandName))
                    {
                        playTimes[bandName] += time;
                    }
                    else
                    {
                        playTimes.Add(bandName, time);
                    }
                }
            }
            playTimes = playTimes
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Total time: {playTimes.Values.Sum()}{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, playTimes.Select(x => $"{x.Key} -> {x.Value}"))}");
            string wantedBand = Console.ReadLine();
            Console.WriteLine($"{wantedBand}{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, bands[wantedBand].Select(x => $"=> {x}"))}");
        }

        static void AddMemebers(string[] bandArgs, List<string> members)
        {
            for (int i = 2; i < bandArgs.Length; i++)
            {
                string memberName = bandArgs[i];
                if (!members.Contains(memberName))
                {
                    members.Add(memberName);
                }
            }
        }
    }
}
