using System;
using System.Linq;
using System.Collections.Generic;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int intelligenceValue = int.Parse(Console.ReadLine());
            int moneyToDeduct = 0;
            while (bullets.Count > 0)
            {
                int bulletsShot = 0;
                for (int i = 0; i < gunBarrelSize && bullets.Count > 0 && locks.Count > 0; i++)
                {
                    moneyToDeduct += bulletPrice;
                    bulletsShot++;
                    if (bullets.Pop() <= locks.Peek())
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }
                }

                if (bullets.Count > 0 && bulletsShot == gunBarrelSize)
                {
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0)
                {
                    int moneyEarned = intelligenceValue - moneyToDeduct;
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                    return;
                }
            }

            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
