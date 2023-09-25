using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            int enginesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesCount; i++)
            {
                //"{model} {power} {displacement} {efficiency}" / "{model} {power} {displacement}" / "{model} {power} {efficiency}" / "{model} {power}"
                string[] engineArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = Engine.CreateEngine(engineArgs);
                engines.Add(engineArgs[0], engine);
            }

            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < carsCount; i++)
            {
                // "{model} {engine} {weight} {color}" / "{model} {engine} {weight}"/ "{model} {engine} {color}" / "{model} {engine}"
                string[] carArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = Car.CreateCar(carArgs, engines);
                cars.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
