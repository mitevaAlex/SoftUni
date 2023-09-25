using System;
using System.Linq;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else if (command == "green" && cars.Count > 0)
                {
                    int greenLightLeft = greenLightSeconds;
                    int freeWindowLeft = freeWindowSeconds;
                    while (greenLightLeft > 0 && cars.Count > 0)
                    {
                        if (cars.Peek().Length <= greenLightLeft)
                        {
                            greenLightLeft -= cars.Peek().Length;
                            cars.Dequeue();
                            carsPassed++;
                        }
                        else
                        {
                            freeWindowLeft -= Math.Abs(greenLightLeft - cars.Peek().Length);
                            greenLightLeft = 0;
                        }
                    }

                    if (cars.Count == 0 || freeWindowLeft == freeWindowSeconds)
                    {
                        continue;
                    }

                    if (freeWindowLeft < 0)
                    {
                        Console.WriteLine($"A crash happened!{Environment.NewLine}{cars.Peek()} was hit at {cars.Peek()[cars.Peek().Length - Math.Abs(freeWindowLeft)]}.");
                        return;
                    }
                    else
                    {
                        cars.Dequeue();
                        carsPassed++;
                    }
                }
            }

            Console.WriteLine($"Everyone is safe.{Environment.NewLine}{carsPassed} total cars passed the crossroads.");
        }
    }
}
