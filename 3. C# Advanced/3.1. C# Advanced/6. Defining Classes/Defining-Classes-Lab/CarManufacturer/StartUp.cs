using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            string command = "";
            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Tire tire1 = new Tire(int.Parse(commandArgs[0]), double.Parse(commandArgs[1]));
                Tire tire2 = new Tire(int.Parse(commandArgs[2]), double.Parse(commandArgs[3]));
                Tire tire3 = new Tire(int.Parse(commandArgs[4]), double.Parse(commandArgs[5]));
                Tire tire4 = new Tire(int.Parse(commandArgs[6]), double.Parse(commandArgs[7]));
                Tire[] currentTires = { tire1, tire2, tire3, tire4 };
                tires.Add(currentTires);
            }

            List<Engine> engines = new List<Engine>();
            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine(int.Parse(commandArgs[0]), double.Parse(commandArgs[1]));
                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            while ((command = Console.ReadLine()) != "Show special")
            {
                //{make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(commandArgs[0], commandArgs[1], int.Parse(commandArgs[2]),
                    double.Parse(commandArgs[3]), double.Parse(commandArgs[4]),
                    engines[int.Parse(commandArgs[5])], tires[int.Parse(commandArgs[6])]);
                cars.Add(car);
            }

            List<Car> specialCars = new List<Car>();
            Predicate<Car> yearCheck = car => car.Year >= 2017;
            Predicate<Car> horsePowerCheck = car => car.Engine.HorsePower > 330;
            Predicate<Car> tirePressureCheck = car => car.Tires.Sum(x => x.Pressure) >  9 && car.Tires.Sum(x => x.Pressure) < 10;
            foreach (Car car in cars)
            {
                if (yearCheck(car) && horsePowerCheck(car) && tirePressureCheck(car))
                {
                    specialCars.Add(car);
                }
            }

            for (int i = 0; i < specialCars.Count; i++)
            {
                specialCars[i].FuelQuantity -= 20/100.0 * specialCars[i].FuelConsumption;
            }

            Console.WriteLine(string.Join(Environment.NewLine, specialCars));
        }
    }
}
