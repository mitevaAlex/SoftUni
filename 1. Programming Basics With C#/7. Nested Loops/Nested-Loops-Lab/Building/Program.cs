using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floorsCount = int.Parse(Console.ReadLine());
            int roomsCount = int.Parse(Console.ReadLine());

            for (int currentFloor = floorsCount; currentFloor > 0; currentFloor--)
            {
                for (int currentRoom = 0; currentRoom < roomsCount; currentRoom++)
                {
                    if (currentFloor == floorsCount)
                    {
                        Console.Write($"L{currentFloor}{currentRoom} ");
                    }
                    else if (currentFloor % 2 == 0)
                    {
                        Console.Write($"O{currentFloor}{currentRoom} ");
                    }
                    else
                    {
                        Console.Write($"A{currentFloor}{currentRoom} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
