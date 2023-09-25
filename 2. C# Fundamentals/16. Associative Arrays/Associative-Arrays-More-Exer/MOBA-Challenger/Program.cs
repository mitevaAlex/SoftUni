using System;
using System.Linq;
using System.Collections.Generic;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            //stores players' positions and skill(int)
            var players = new Dictionary<string, Dictionary<string, int>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Season end")
            {
                if (command.Contains("->"))
                {
                    //"{player} -> {position} -> {skill}"
                    string[] playerArgs = command
                        .Split(" -> ");
                    string playerName = playerArgs[0];
                    string position = playerArgs[1];
                    int skill = int.Parse(playerArgs[2]);
                    if (players.ContainsKey(playerName))
                    {
                        if (players[playerName].ContainsKey(position) && players[playerName][position] < skill)
                        {
                            players[playerName][position] = skill;
                        }
                        else if (!players[playerName].ContainsKey(position))
                        {
                            players[playerName].Add(position, skill);
                        }
                    }
                    else
                    {
                        players.Add(playerName, new Dictionary<string, int>()
                        {
                            [position] = skill
                        });
                    }
                }
                else if (command.Contains("vs"))
                {
                    //"{player} vs {player}"
                    string[] duelArgs = command
                        .Split(" vs ");
                    string firstPlayer = duelArgs[0];
                    string secondPlayer = duelArgs[1];
                    if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPlayer))
                    {
                        bool duelIsValid = false;
                        string commonPosition = string.Empty;
                        foreach (var kvp in players[firstPlayer])
                        {
                            if (players[secondPlayer].ContainsKey(kvp.Key))
                            {
                                duelIsValid = true;
                                commonPosition = kvp.Key;
                                break;
                            }
                        }

                        if (duelIsValid)
                        {
                            if (players[firstPlayer][commonPosition] > players[secondPlayer][commonPosition])
                            {
                                players.Remove(secondPlayer);
                            }
                            else if (players[firstPlayer][commonPosition] < players[secondPlayer][commonPosition])
                            {
                                players.Remove(firstPlayer);
                            }
                        }
                    }
                }
            }
            players = players
                .OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Dictionary<string, Dictionary<string, int>> sortedPlayers = new Dictionary<string, Dictionary<string, int>>();
            foreach (var kvp in players)
            {
                sortedPlayers[kvp.Key] = players[kvp.Key]
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);
            }
            Console.WriteLine(string.Join(Environment.NewLine, 
                sortedPlayers.Select(x => $"{x.Key}: {x.Value.Sum(y => y.Value)} skill{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, x.Value.Select(y => $"- {y.Key} <::> {y.Value}"))}")));
        }
    }
}

