using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                //"{typeOfVehicle ("car" or "truck")} {model} {color} {horsepower}"
                string[] vehicleData = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string typeFirstletter = vehicleData[0][0].ToString().ToUpper();
                vehicleData[0] = vehicleData[0].Remove(0, 1);
                vehicleData[0] = vehicleData[0].Insert(0, typeFirstletter);
                Vehicle vehicle = new Vehicle(vehicleData[0], vehicleData[1],
                    vehicleData[2], int.Parse(vehicleData[3]));
                vehicles.Add(vehicle);
            }
            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                string modelVehicle = command;
                Vehicle currentVehicle = vehicles.Find(x => x.Model == modelVehicle);
                Console.WriteLine(currentVehicle);
            }
            List<Vehicle> cars = vehicles
                .Where(x => x.Type == "Car")
                .ToList();
            double carsAverageHorsepower = 0.0;
            foreach (Vehicle car in cars)
            {
                carsAverageHorsepower += car.Horsepower;
            }
            carsAverageHorsepower /= cars.Count;
            List<Vehicle> trucks = vehicles
                .Where(x => x.Type == "Truck")
                .ToList();
            double trucksAverageHorsepower = 0.0;
            foreach (Vehicle truck in trucks)
            {
                trucksAverageHorsepower += truck.Horsepower;
            }
            trucksAverageHorsepower /= trucks.Count;
            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carsAverageHorsepower:F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHorsepower:F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }
        }
    }
}
