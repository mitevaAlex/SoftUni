using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandArgs[0];
                string car = commandArgs[1];
                switch (action)
                {
                    case "IN":
                        cars.Add(car);
                        break;
                    case "OUT":
                        cars.Remove(car);
                        break;
                }
            }

            if (cars.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
