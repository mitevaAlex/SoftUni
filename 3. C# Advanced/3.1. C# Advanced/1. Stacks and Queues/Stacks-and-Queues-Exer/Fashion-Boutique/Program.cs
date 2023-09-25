using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesValues = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());
            int clothesSum = 0;
            int racksUsed = clothesValues.Count > 0 ? 1 : 0;
            while (clothesValues.Count > 0)
            {
                if (clothesSum + clothesValues.Peek() < rackCapacity)
                {
                    clothesSum += clothesValues.Pop();
                }
                else if (clothesSum + clothesValues.Peek() == rackCapacity)
                {
                    clothesValues.Pop();
                    if (clothesValues.Count == 0)
                    {
                        break;
                    }

                    racksUsed++;
                    clothesSum = 0;
                }
                else
                {
                    racksUsed++;
                    clothesSum = clothesValues.Pop();
                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}
