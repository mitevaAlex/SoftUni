using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                //"{model} {fuelAmount} {fuelConsumptionFor1km}"
                string[] carArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(carArgs[0], double.Parse(carArgs[1]), double.Parse(carArgs[2]));
                cars.Add(carArgs[0], car);
            }

            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                //"Drive {carModel} {amountOfKm}"
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToArray();
                cars[commandArgs[0]].Drive(double.Parse(commandArgs[1]));
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars.Select(x => x.Value)));
        }
    }
}
