using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string ticket in tickets)
            {
                Match validTicket = Regex.Match(ticket, @"^(?<firstHalf>.{10})(?<secondHalf>.{10})$");
                if (validTicket.Success)
                {
                    Match winningSymbolsFirstHalf = Regex.Match(validTicket.Groups["firstHalf"].Value, @"([$@^#])\1{5,10}");
                    Match winningSymbolsSecondHalf = Regex.Match(validTicket.Groups["secondHalf"].Value, @"([$@^#])\1{5,10}");
                    if (winningSymbolsFirstHalf.Value.Length == 10 &&
                        winningSymbolsFirstHalf.Value == winningSymbolsSecondHalf.Value)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {winningSymbolsFirstHalf.Length}{winningSymbolsFirstHalf.Value.First()} Jackpot!");
                    }
                    else if (winningSymbolsFirstHalf.Success && winningSymbolsSecondHalf.Success &&
                        winningSymbolsFirstHalf.Value.First() == winningSymbolsSecondHalf.Value.First())
                    {
                        int winningCountOfSymbols = Math.Min(winningSymbolsFirstHalf.Value.Length, winningSymbolsSecondHalf.Value.Length);
                        Console.WriteLine($"ticket \"{ticket}\" - {winningCountOfSymbols}{winningSymbolsFirstHalf.Value.First()}");
                    }
                    else if (!winningSymbolsFirstHalf.Success || !winningSymbolsSecondHalf.Success)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
