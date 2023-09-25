using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<Pump> pumps = new Queue<Pump>(pumpsCount);
            for (int i = 0; i < pumpsCount; i++)
            {
                int[] pumpArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int petrolAmount = pumpArgs[0];
                int nextPumpDistance = pumpArgs[1];
                pumps.Enqueue(new Pump(petrolAmount, nextPumpDistance, i));
            }

            int petrolAvailable = 0;
            for (int i = 0; i < pumps.Count; i++)
            {
                int counter = 0;
                while (pumps.Peek().PetrolAmount + petrolAvailable - pumps.Peek().NextPumpDistance >= 0)
                {
                    petrolAvailable += pumps.Peek().PetrolAmount - pumps.Peek().NextPumpDistance;
                    pumps.Enqueue(pumps.Dequeue());
                    counter++;
                    if (counter == pumps.Count)
                    {
                        break;
                    }
                }

                if (counter == pumps.Count)
                {
                    break;
                }

                petrolAvailable = 0;
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(pumps.Peek().PumpIndex);
        }
    }
}
