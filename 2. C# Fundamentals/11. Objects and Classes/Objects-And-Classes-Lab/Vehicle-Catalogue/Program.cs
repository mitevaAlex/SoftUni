using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                //"{type}/{brand}/{model}/{horse power / weight}"
                string[] vehicleData = input
                    .Split('/', StringSplitOptions.RemoveEmptyEntries);
                string type = vehicleData[0];
                if (type == "Car")
                {
                    Car car = new Car(vehicleData[1], vehicleData[2], int.Parse(vehicleData[3]));
                    catalog.Cars.Add(car);
                }
                else if (type == "Truck")
                {
                    Truck truck = new Truck(vehicleData[1], vehicleData[2], int.Parse(vehicleData[3]));
                    catalog.Trucks.Add(truck);
                }
            }
            catalog.Cars = catalog.Cars
                .OrderBy(x => x.Brand)
                .ToList();
            catalog.Trucks = catalog.Trucks
                .OrderBy(x => x.Brand)
                .ToList();
            Console.WriteLine("Cars:");
            catalog.Cars.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Trucks:");
            catalog.Trucks.ForEach(x => Console.WriteLine(x));
        }
    }
}
