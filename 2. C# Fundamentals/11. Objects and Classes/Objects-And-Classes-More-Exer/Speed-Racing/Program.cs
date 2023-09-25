using System;
using System.Collections.Generic;
using System.Linq;

namespace Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < carsCount; i++)
            {
                //“<Model> <FuelAmount> <FuelConsumptionFor1km>”
                string[] carData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));
                cars.Add(car);
            }
            string command = string.Empty;
            while((command = Console.ReadLine()) != "End")
            {
                //"Drive <CarModel> <amountOfKm>". 
                string[] movementData = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car movingCar = cars.Find(x => x.Model == movementData[1]);
                int kilometers = int.Parse(movementData[2]);
                if (movingCar.CanTravelTheDistance(kilometers))
                {
                    movingCar.FuelAmount -= kilometers * movingCar.FuelConsumptionPerKilometer;
                    movingCar.TravelledDistance += kilometers;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            cars.ForEach(x => Console.WriteLine(x));
        }
    }
}
