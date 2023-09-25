using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagonPassengersCount = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToList();

            int wagonMaxCapacity = int.Parse(Console.ReadLine());

            List<string> command = new List<string>();//"Add {passengers}" or {passengers} 

            while (!(command = Console.ReadLine()
                .Split(" ")
                .ToList()).Contains("end"))
            {
                if (command.Count == 2)
                {
                    int passengers = int.Parse(command[1]);
                    wagonPassengersCount.Add(passengers);
                }
                else
                {
                    int passengers = int.Parse(command[0]);
                    for (int i = 0; i < wagonPassengersCount.Count; i++)
                    {
                        if (wagonPassengersCount[i] + passengers <= wagonMaxCapacity)
                        {
                            wagonPassengersCount[i] += passengers;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", wagonPassengersCount));
        }
    }
}
