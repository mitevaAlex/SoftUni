using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < carsCount; i++)
            {
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
                string[] carsArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine(int.Parse(carsArgs[1]), int.Parse(carsArgs[2]));
                Cargo cargo = new Cargo(int.Parse(carsArgs[3]), carsArgs[4]);
                Tire[] tires = Tire.CreateTireArray(carsArgs.Skip(5).ToArray());
                Car car = new Car(carsArgs[0], engine, cargo, tires);
                cars.Add(car);
            }

            //"fragile" / "flamable"
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                cars = cars
                    .Where(car => car.Cargo.Type == "fragile" && car.Tires.Min(tire => tire.Pressure) < 1)
                    .ToList();
            }
            else if (command == "flamable")
            {
                cars = cars
                    .Where(car => car.Cargo.Type == "flamable" && car.Engine.Power > 250)
                    .ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
