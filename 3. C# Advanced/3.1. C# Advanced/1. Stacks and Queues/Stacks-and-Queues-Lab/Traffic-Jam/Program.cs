using System;
using System.Collections.Generic;
using System.Linq;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPassing = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string command = "";
            int carsPassedCount = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    for (int i = 0; i < carsPassing; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            carsPassedCount++;
                        }
                    }
                }
            }

            Console.WriteLine($"{carsPassedCount} cars passed the crossroads.");
        }
    }
}
