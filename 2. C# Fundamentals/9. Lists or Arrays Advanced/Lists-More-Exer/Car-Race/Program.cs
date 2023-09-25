using System;
using System.Collections.Generic;
using System.Linq;

namespace Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> racersTime = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            double firstRacerTime = 0.0;
            for (int i = 0; i < racersTime.Count / 2; i++)
            {
                int currentTime = racersTime[i];
                if (currentTime == 0)
                {
                    firstRacerTime *= 0.8;
                }
                else
                {
                    firstRacerTime += currentTime;
                }
            }
            double secondRacerTime = 0.0;
            for (int i = racersTime.Count - 1; i > racersTime.Count / 2; i--)
            {
                int currentTime = racersTime[i];
                if (currentTime == 0)
                {
                    secondRacerTime *= 0.8;
                }
                else
                {
                    secondRacerTime += currentTime;
                }
            }
            string winner = "right";
            double winnerTime = secondRacerTime;
            if (firstRacerTime < secondRacerTime)
            {
                winner = "left";
                winnerTime = firstRacerTime;
            }
            Console.WriteLine($"The winner is {winner} with total time: {winnerTime}");
        }
    }
}
